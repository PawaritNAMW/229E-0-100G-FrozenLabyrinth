using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
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

    public void Retry()
    {
        Debug.Log("Restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Loading...");
        SceneManager.LoadScene("Mainmanu");
    }
}
