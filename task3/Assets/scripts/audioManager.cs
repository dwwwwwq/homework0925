using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    // 单例模式
    public static AudioManager instance;

    private AudioSource audioSource;
    // public AudioClip sceneSwitchSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 保持 AudioManager 不被销毁
        }
        else
        {
            Destroy(gameObject);
        }

        // base.Awake();
        // if (EventManager.Instance != null)
        // {
        //     EventManager.Instance.SceneSwitchAudioPlayEvent += OnSceneSwitchAudioPlay;
            
        // }

        
        // Debug.Log("getaudio");
    }

    // private void OnDisable()
    // {
    //     EventManager.Instance.SceneSwitchAudioPlayEvent -= OnSceneSwitchAudioPlay;
        
    // }

    // private void OnSceneSwitchAudioPlay()
    // {
    //     audioSource = GetComponent<AudioSource>();
    //     audioSource.clip=sceneSwitchSound;
    //     audioSource.Play();
    // }


   
}