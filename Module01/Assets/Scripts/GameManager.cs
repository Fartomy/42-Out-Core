using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene _currentScene;
    private int _sceneCnt;
    private bool _once;
    private bool[] exitLockStat = new bool[3];
    [SerializeField] private GameObject[] _chars = new GameObject[3];

    void Awake()
    {
        _currentScene = SceneManager.GetActiveScene();
        _once = true;
        _sceneCnt =  SceneManager.sceneCountInBuildSettings;
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
        if (exitLockStat[0] && exitLockStat[1] && exitLockStat[2] && _once)
        {
            _once = false;
            Debug.Log("Stage is over!");
            if(_currentScene.buildIndex < _sceneCnt - 1)
                SceneManager.LoadScene(_currentScene.buildIndex + 1);
            else
                SceneManager.LoadScene(0);
        }
    }

    void ResetStage()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
            SceneManager.LoadScene(_currentScene.name);
        if (!_chars[0] || !_chars[1] || !_chars[2])
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(_currentScene.name);
        }
    }
}
