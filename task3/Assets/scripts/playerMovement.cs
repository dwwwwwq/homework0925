using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float maxRotationAngle = 90f; // 最大旋转角度
    private Rigidbody rb;
    private Transform cameraTransform; // 摄像机的Transform

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 不允许物理引擎旋转角色

        // 获取主摄像机的Transform
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 获取玩家输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 将玩家输入从世界坐标系转换为摄像机坐标系
        Vector3 moveDirection = cameraTransform.TransformDirection(new Vector3(horizontalInput, 0f, verticalInput));
        moveDirection.y = 0f; // 不考虑上下方向的移动
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            // 计算目标旋转方向
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            // 限制旋转角度不超过最大角度
            float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);
            if (angleDifference > maxRotationAngle)
            {
                targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);
            }

            // 平滑旋转角色
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    void FixedUpdate()
    {
        // 移动角色
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 将玩家输入从世界坐标系转换为摄像机坐标系
        Vector3 moveDirection = cameraTransform.TransformDirection(new Vector3(horizontalInput, 0f, verticalInput));
        moveDirection.y = 0f; // 不考虑上下方向的移动
        moveDirection.Normalize();

        rb.velocity = moveDirection * moveSpeed;
    }
}