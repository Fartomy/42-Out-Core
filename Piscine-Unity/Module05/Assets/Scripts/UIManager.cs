using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Animator _panelAnim;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void MainMenu()
    {
        GameManager.Instance.Save();
        LeafController.nextIDCnt = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        if(GameManager.Instance.PassedStageCnt > 0)
            SceneManager.LoadScene(GameManager.Instance.PassedStageCnt);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        GameManager.Instance.ResetLeafs();
        GameManager.Instance.PassedStageCnt = 1;
        SceneManager.LoadScene(1);
    }

    public void Diary()
    {
        //
    }
}
