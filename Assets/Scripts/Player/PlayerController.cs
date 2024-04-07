using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;

    Rigidbody rigidBody;
    private Transform playerTransform;

    private CharacterController _controller;

    [SerializeField]public float turnSpeed = 100f;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Transform handTransform;
    public Vector3 lookDirection;
    private bool hasMoveInput;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        playerTransform = transform;
        input.EnableGameplayInput();
    }

    void Update()
    {
        // PlayerRotation();
    }
    

    public void SetVelocity(float speed)
    {
        Vector3 inputDirection = new Vector3(input.axes.x, 0.0f, input.axes.y).normalized;

        if (input.axes != Vector2.zero)
        {
            inputDirection = camTransform.right * input.axes.x + camTransform.forward * input.axes.y;
        }

        // _controller.Move(inputDirection.normalized * (speed * Time.deltaTime));

        // Vector3 move = new Vector3(input.moveInput.x * camTransform.forward.x, 0f, input.moveInput.z * camTransform.forward.z).normalized;
        rigidBody.velocity = inputDirection.normalized * (speed * Time.deltaTime);
        // Debug.Log(rigidBody.velocity);
    }

    public void PlayerRotation()
    {
        if (input.axes == Vector2.zero)
        {
            return;
        }

        // 取得相機的forward向量
        Vector3 cameraDirection = camTransform.forward;
        cameraDirection.y = 0f;

        // 取得玩家前進方向的向量
        Vector3 playerDirection = playerTransform.forward;
        playerDirection.y = 0f;

        // 計算相機與玩家前進方向的夾角
        // float angle = Vector3.Angle(cameraDirection, playerDirection);

        // // 計算目標旋轉角度
        // Vector3 moveDirection = new Vector3(input.axes.x, 0f, input.axes.y);
        // moveDirection = Quaternion.LookRotation(cameraDirection) * moveDirection;
        // moveDirection.y = 0f;
        // Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

        // 旋轉至目標角度
        playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, Quaternion.LookRotation(cameraDirection, Vector3.up), turnSpeed * Time.deltaTime);
    }
}
