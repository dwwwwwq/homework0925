using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // 玩家的Transform
    public float smoothSpeed = 5.0f; // 平滑过渡的速度
    public float distance = 5.0f; // 摄像机与玩家的距离
    public float height = 5.1f; // 摄像机的高度

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // 计算目标位置
            Vector3 targetPosition = playerTransform.position - playerTransform.forward * distance + Vector3.up * height;

            // 平滑过渡到目标位置
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            // 让摄像机一直看着玩家
            transform.LookAt(playerTransform);
        }
    }
}
