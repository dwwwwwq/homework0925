using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class characterManager : Singleton<characterManager>
{
    public event Action<CharacterState> CharacterStateChanged;
    private CharacterState currentState;
    private Rigidbody rb;
    public CharacterState CurrentState
    {
        get { return currentState; }
    }

    public enum CharacterState
    {
        IsMoving,
        Standby
    }

    void Start()
    {
        // 初始化状态
        currentState = CharacterState.Standby;
    }

    void Update()
    {
        // 根据角色行为更新状态
        if (HasInput())
        {
            ChangeState(CharacterState.IsMoving);
            // Debug.Log("IsMoving");
        }
        else
        {
            ChangeState(CharacterState.Standby);
        }
    }

    void ChangeState(CharacterState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            CharacterStateChanged?.Invoke(newState);
            // EventManager.Instance.TriggerCharacterStateChangedEvent()
            // Debug.Log("CharacterStateChanged"+currentState);
        }
    }

    bool HasInput()
    {
        // 检测是否有输入
        return Input.GetButton("Horizontal") || Input.GetButton("Vertical");
        // Debug.Log("HasInput");
    }
    
}



