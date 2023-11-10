using UnityEngine;
using UnityEngine.UI;

public class UISceneSwitchCounter : MonoBehaviour
{
    public MySceneManager mySceneManager; 
    public Text switchCounterText;
    public int SceneSwitchCount;
     // 这里可以将MySceneManager脚本拖拽到这个字段上
    

    void Start()
    {
        if (switchCounterText == null)
        {
            Debug.LogError("switchCounterText is not assigned!");
        }

        if (mySceneManager == null)
        {
            mySceneManager = FindObjectOfType<MySceneManager>();
        }

        // if (sceneSwitchCount == null)
        // {
        //     Debug.LogError("sceneSwitchCount is  assigned!"+sceneSwitchCount);
        // }
    }
    private void Update()
    {
        int SceneSwitchCount = PlayerPrefs.GetInt("SceneSwitchCount", 0);
        switchCounterText.text = "sceneswitchcount " + SceneSwitchCount;
        // switchCounterText.text="sceneswitchcount"+SceneSwitchCount;
    }
}