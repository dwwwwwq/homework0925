using System;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    
    public event Action<string> SceneSwitchEvent;
    // public event Action SceneSwitchAudioPlayEvent;
    // public event Action<int> SceneSwitchCountEvent;
    

    public void TriggerSceneSwitchEvent(string nextSceneName)
    {
        SceneSwitchEvent?.Invoke(nextSceneName);
        // Debug.Log("Event"+nextSceneName);
    }

    // public void 

    // public void TriggerSceneSwitchAudioPlayEvent()
    // {
    //     SceneSwitchAudioPlayEvent?.Invoke();
    // }

    

    
}
