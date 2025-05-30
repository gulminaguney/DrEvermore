using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("DrEvermore"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
