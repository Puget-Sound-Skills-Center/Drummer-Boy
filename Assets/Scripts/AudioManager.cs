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
    public AudioClip miss_note_sfx;

    private static AudioManager audioInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (audioInstance == null)
        {
            audioInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the index of the scene in the project's build settings.
        int buildIndex = currentScene.buildIndex;

        // Check the scene name as a conditional.
        switch (buildIndex)
        {
            case 0:
                musicSource.Stop();
                musicSource.clip = mainMenu_Music;
                musicSource.Play();
                break;
            case 1:
                musicSource.Stop();
                break;
            case 2:
                musicSource.Stop();
                break;
        }
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void MissSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(miss_note_sfx);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}