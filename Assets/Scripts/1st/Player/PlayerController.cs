using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	PlayerInput input;
	Rigidbody rigidBody;
	[SerializeField] GameObject bullet;
    [SerializeField] Animator animator;
	[SerializeField] public float turnSpeed = 100f;
	[SerializeField] public float moveSpeed = 50f;
    [SerializeField] public float walkSpeed = 50f;
    [SerializeField] public float runSpeed = 100f;
	[SerializeField] public float fireSpeed = 100f;
	[SerializeField] private float shootSpeed = 3f;
	[SerializeField] private Transform camTransform;
	[SerializeField] private Transform handTransform;
	[SerializeField] private Transform muzzle;
	public Vector3 lookDirection;
	private bool isCreatingBullet = false;


	void Awake()
	{
		input = GetComponent<PlayerInput>();
		rigidBody = GetComponent<Rigidbody>();
	}

	void Start()
	{
		input.EnableGameplayInput();
	}

	void Update()
	{
		if (input.Fire && !isCreatingBullet)
		{
			StartCoroutine(CreatBullet());
		}
		
	}

	private void FixedUpdate()
	{
		PlayerRotation();
		SetVelocity();
	}

	public void SetVelocity()
	{
		if(input.Fire)
		{
			animator.SetBool("isFire", true);
		}
		else
		{
			animator.SetBool("isFire", false);
		}


		if (input.Move)
		{
			float ms = input.Run ? runSpeed : walkSpeed;

			if(input.Fire)
			{
				ms = fireSpeed;
			}

			// Debug.Log(input.Run);
			if (input.Run)
			{
				animator.SetBool("isWalking", false);
				animator.SetBool("isRunning", true);
			}
			else
			{
				animator.SetBool("isWalking", true);
				animator.SetBool("isRunning", false);
			}
			//取得相機的Forward並歸零Y軸只考慮Z軸與X軸的向量
			Vector3 camForwardProjection = new Vector3(camTransform.forward.x, 0, camTransform.forward.z).normalized;
			Vector3 moveDirection = camForwardProjection * input.AxisY * ms * Time.fixedDeltaTime + camTransform.right * input.AxisX * ms * Time.fixedDeltaTime;
			rigidBody.velocity = moveDirection;
		}
		else
		{
			rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
            animator.SetBool("isWalking",false);
            animator.SetBool("isRunning",false);
			return;
		}
	}

	public void PlayerRotation()
	{
		// 取得相機的forward向量
		Vector3 cameraDirection = camTransform.forward;

		// 旋轉至目標角度
		//Debug.Log(Quaternion.Euler(cameraDirection));
		transform.rotation = Quaternion.Euler(cameraDirection);
	}


	//協程
	IEnumerator CreatBullet()
	{
		//避免重複啟用
		isCreatingBullet = true;
		//創建子彈(很耗效能)
		while (input.Fire)
		{
			//等待時間避免快速生成太多子彈
			Instantiate(bullet, muzzle.position,camTransform.rotation);
			yield return new WaitForSeconds(shootSpeed);
		}
		isCreatingBullet = false;
	}
}
