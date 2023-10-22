using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip footstepSound; // 脚步声音频剪辑

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 获取玩家的移动输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 判断玩家是否在移动
        bool isMoving = Mathf.Abs(horizontalInput) > 0.01f || Mathf.Abs(verticalInput) > 0.01f;

        // 输出调试信息
        // Debug.Log("Is Moving: " + isMoving);
        // Debug.Log("Horizontal Input: " + horizontalInput);
        // Debug.Log("Vertical Input: " + verticalInput);

        // 如果玩家在移动，播放脚步声
        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = footstepSound;
                audioSource.Play();
            }
        }
        else
        {
            // 如果不在移动，停止脚步声
            audioSource.Stop();
        }
    }
}