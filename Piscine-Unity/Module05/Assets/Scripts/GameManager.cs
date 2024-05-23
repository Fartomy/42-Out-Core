using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public int PassedStageCnt = 0;
    [HideInInspector] public Dictionary<int, bool> _leafStatus = new Dictionary<int, bool>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void Save()
    {
        UIManager.Instance.isRefreshGameInUI = true;
        PlayerPrefs.SetInt("PlayerHP", PlayerController.Instance._playerHP);
        PlayerPrefs.SetInt("LeafPoint", PlayerController.Instance._leafPoint);
        PlayerPrefs.SetInt("CollectedLeaf", PlayerController.Instance._collecttedLeafs);
        PlayerPrefs.SetInt("PassedStageNumber", PassedStageCnt);
        PlayerPrefs.SetInt("LeafPointPool", PlayerController.Instance.LeafPointPool);
        PlayerPrefs.SetInt("DeadCounter", PlayerController.Instance.DeadCounter);
    }

    public void Load()
    {
        PlayerController.Instance._playerHP = PlayerPrefs.GetInt("PlayerHP");
        PlayerController.Instance._leafPoint = PlayerPrefs.GetInt("LeafPoint");
        PlayerController.Instance._collecttedLeafs = PlayerPrefs.GetInt("CollectedLeaf");
        PlayerController.Instance.LeafPointPool = PlayerPrefs.GetInt("LeafPointPool");
        PlayerController.Instance.DeadCounter = PlayerPrefs.GetInt("DeadCounter");
    }

    public void SetLeafStatus(int leafID, bool leafStatus)
    {
        _leafStatus.Add(leafID, leafStatus);
    }

    public void NextStage()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 2)
        {
            Save();
            SceneManager.LoadScene("Diary");
            UIManager.Instance.Diary();
        }
        else
        {
            PassedStageCnt++;
            Save();
            Reset();
            SceneManager.LoadScene(PassedStageCnt);
        }
    }

    public void Reset()
    {
        _leafStatus.Clear();
        LeafController.nextIDCnt = 0;
        PlayerPrefs.SetInt("PlayerHP", 3);
        PlayerPrefs.SetInt("LeafPoint", 0);
        PlayerPrefs.SetInt("CollectedLeaf", 0);
    }
}
