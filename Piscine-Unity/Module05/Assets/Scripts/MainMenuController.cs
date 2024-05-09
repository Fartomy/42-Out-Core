using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Resume()
    {
        if(GameManager._instance != null)
            SceneManager.LoadScene(PlayerController._instance.passedStageNbr + 1);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }

    public void Diary()
    {

    }
}
