using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Aduio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Aduio Clip ---------")]
    public AudioClip mainMenu_Music;
    public AudioClip button_click;

    private void Start()
    {
        musicSource.clip = mainMenu_Music;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
