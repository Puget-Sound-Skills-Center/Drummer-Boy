using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Aduio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Aduio Clip ---------")]
    public AudioClip mainMenu_Music;
    public AudioClip Tutorial_Music;
    public AudioClip Win_Effect;
    public AudioClip Tutorial_Extended;
    public AudioClip button_click;

    

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if ( sceneName == "MainMenu")
            {
            musicSource.clip = mainMenu_Music;
            }
        else if (sceneName == "MainMenu")
        {
            musicSource.clip = Win_Effect;
        }

        // Retrieve the index of the scene in the project's build settings.
        int buildIndex = currentScene.buildIndex;

        // Check the scene name as a conditional.
        switch (buildIndex)
        {
            case 0:
                musicSource.clip = mainMenu_Music;
                break;
            case 2:
                musicSource.clip = Win_Effect;
                break;
        }
        musicSource.Play();
    }

    private void Update()
    {
       
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    private void Awake()
    {
           
    }
}
