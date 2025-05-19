using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
   
    public void PlaySFX()
    {
        audioManager.PlaySFX(audioManager.button_click);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Gameplay 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
