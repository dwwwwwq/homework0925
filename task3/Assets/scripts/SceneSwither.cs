 namespace Scene1 {
    

using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public string nextSceneName = "scene2"; // 指定要切换到的下一个场景

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 当玩家进入触发区域时，触发场景切换事件
            EventManager.Instance.TriggerSceneSwitchEvent(nextSceneName);
            // EventManager.Instance.TriggerSceneSwitchAudioPlayEvent();
            
            // Debug.Log("scene2");
        
        }
    }
}
}