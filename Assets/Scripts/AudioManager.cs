using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Aduio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Aduio Clip ---------")]
    public AudioClip mainMenu_Music;
    public AudioClip Tutorial_Music;
    public AudioClip Tutorial_Extended;
    public AudioClip button_click;

    

    private void Start()
    {
        musicSource.clip = mainMenu_Music;
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
