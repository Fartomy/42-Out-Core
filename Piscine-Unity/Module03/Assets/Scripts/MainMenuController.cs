using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("map01");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
