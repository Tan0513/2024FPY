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
	[SerializeField] public float turnSpeed = 100f;
	[SerializeField] public float moveSpeed = 50f;
	[SerializeField] private Transform camTransform;
	[SerializeField] private Transform handTransform;
	public Vector3 lookDirection;

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

	}

	private void FixedUpdate()
	{
		PlayerRotation();
		SetVelocity();
	}

	public void SetVelocity()
	{
		if (input.Move)
		{
			//取得相機的Forward並歸零Y軸只考慮Z軸與X軸的向量
			Vector3 camForwardProjection = new Vector3(camTransform.forward.x, 0, camTransform.forward.z).normalized;
			Vector3 moveDirection = camForwardProjection * input.AxisY * moveSpeed * Time.fixedDeltaTime + camTransform.right * input.AxisX* moveSpeed * Time.fixedDeltaTime;
			rigidBody.velocity = moveDirection;
		}
		else
		{
			rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
			return;
		}
	}

	public void PlayerRotation()
	{
		// 取得相機的forward向量
		Vector3 cameraDirection = camTransform.forward;

		// 旋轉至目標角度
		Debug.Log(Quaternion.Euler(cameraDirection));
		transform.rotation = Quaternion.Euler(cameraDirection);
	}
}
