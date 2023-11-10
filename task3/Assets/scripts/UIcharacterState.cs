using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcharacterState : MonoBehaviour
{
    public Text stateText; // 引用显示状态的UI文本

    private void Awake()
    {
        // 订阅状态变化事件
        characterManager.Instance.CharacterStateChanged += UpdateStateText;
        stateText.text="Current State: standby";

    }

    private void OnDestroy()
    {
        // 取消订阅事件以防止内存泄漏
        characterManager.Instance.CharacterStateChanged -= UpdateStateText;
    }

    // 事件处理方法，用于更新UI文本
    private void UpdateStateText(characterManager.CharacterState newState)
    {
        Debug.Log(newState);
        stateText.text = "Current State: " + newState.ToString();
    }
}
