using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;

    public GameObject pauseMenu;

    public GameObject endMenu;

    private void Awake()
    {
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
    }

    private void Start()
    {
        Time.timeScale = 0f;
        
    }

    public void ButtonStart()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);

    }

    public void ButtonPause() 
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ButtonResume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void ButtonQuit()
    {
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }
}
