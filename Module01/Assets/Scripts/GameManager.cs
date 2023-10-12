using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene currentScene;
    private bool[] exitLockStat = new bool[3];
    [SerializeField] private GameObject[] _chars = new GameObject[3];

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        ResetStage();
        IsStageFinished();
    }

    void IsStageFinished()
    {
        exitLockStat[0] = _chars[0].GetComponent<PlayerController>().exitLock;
        exitLockStat[1] = _chars[1].GetComponent<PlayerController>().exitLock;
        exitLockStat[2] = _chars[2].GetComponent<PlayerController>().exitLock;
        if (exitLockStat[0] && exitLockStat[1] && exitLockStat[2])
            Debug.Log("Stage is over!");
    }

    void ResetStage()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
            SceneManager.LoadScene(currentScene.name);
        if (!_chars[0] || !_chars[1] || !_chars[2])
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
