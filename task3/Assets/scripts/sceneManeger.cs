using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MySceneManager : Singleton<MySceneManager>
{
    private int sceneSwitchCount;
     // Initialize count to 0
     public int SceneSwitchCount;

    private void Awake()
    {
        sceneSwitchCount = PlayerPrefs.GetInt("SceneSwitchCount", 0);
        // sceneSwitchCount=0;
        base.Awake();
        Debug.Log(SceneSwitchCount);
        if (EventManager.Instance != null)
        {
            EventManager.Instance.SceneSwitchEvent += OnSceneSwitch;
            // Debug.Log("OnEnable");
        }
    }

    private void OnDisable()
    {
        EventManager.Instance.SceneSwitchEvent -= OnSceneSwitch;
        // Debug.Log("OnDisable");
    }

    private void OnSceneSwitch(string nextSceneName)
    {
        sceneSwitchCount++;
        // Debug.Log(sceneSwitchCount);

        SceneManager.LoadScene(nextSceneName); // 直接加载场景
        PlayerPrefs.SetInt("SceneSwitchCount", sceneSwitchCount);
        PlayerPrefs.Save(); // 保存计数
        // Debug.Log("loading");
        SceneSwitchCount=sceneSwitchCount; 
        // Debug.Log(SceneSwitchCount);
    }

    
}