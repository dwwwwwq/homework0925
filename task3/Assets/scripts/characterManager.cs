using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterManager : Singleton<characterManager>
{
    public RectTransform uiElement;  // UI元素的RectTransform
    public Transform selectedCharacter;  // 所选角色的Transform

    private float characterHeight = 1.3f;  // 角色头部的高度偏移

    void Update()
    {
        if (selectedCharacter != null && uiElement != null)
        {
            // 获取所选角色头部的世界坐标
            Vector3 characterHeadPosition = selectedCharacter.position + Vector3.up * characterHeight;

            // 将世界坐标转换为屏幕坐标
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(characterHeadPosition);

            // 更新UI元素的位置
            uiElement.anchoredPosition = screenPosition;
        }
    }
}



