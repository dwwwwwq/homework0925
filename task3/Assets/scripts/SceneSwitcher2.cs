namespace Scene2 {
    

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string destinationScene = "Scene1"; // 目标场景名称
    public float delayBeforeSwitch = 1.0f; // 切换场景前的延迟时间

    private bool isSwitching = false;

   private void OnTriggerEnter(Collider other)
{
    Debug.Log("OnTriggerEnter called with object: " + other.name);
    if (other.CompareTag("Player") && !isSwitching)
    {
        Debug.Log("Player entered the trigger!");
        isSwitching = true;
        StartCoroutine(LoadScene(destinationScene));
    }
}

    private IEnumerator LoadScene(string sceneName)
{
    Debug.Log("LoadScene called with scene name: " + sceneName);

    // 等待一定时间
    yield return new WaitForSeconds(delayBeforeSwitch);
    Debug.Log("Delay time is over, switching scene.");

    // 加载目标场景
    SceneManager.LoadScene(sceneName);
}
}
}
