using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        Debug.Log("Loading...");
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting...");
        Application.Quit();

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        Debug.Log("Restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("Loading...");
        SceneManager.LoadScene("Mainmanu");
        Time.timeScale = 1f;
    }
}
