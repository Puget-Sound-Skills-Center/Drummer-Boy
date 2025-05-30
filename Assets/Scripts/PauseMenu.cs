using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public KeyCode KeyToPress;

    public KeyCode KeyToPause;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        
        Time.timeScale = 0;
    
     
            AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }

    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
      
            AudioSource[] audios = FindObjectsOfType<AudioSource>();


            foreach (AudioSource a in audios)
            {
                a.Play();
            }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyToPress))
        {
            Restart();
        }
        if (Input.GetKeyUp(KeyToPause))
        {
            Pause();
        }
    }
}
