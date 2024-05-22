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
        PlayerPrefs.SetInt("PlayerHP", PlayerController.Instance._playerHP);
        PlayerPrefs.SetInt("LeafPoint", PlayerController.Instance._leafPoint);
        PlayerPrefs.SetInt("CollectedLeaf", PlayerController.Instance._collecttedLeafs);
        PlayerPrefs.SetInt("PassedStageNumber", PassedStageCnt);
    }

    public void Load()
    {
        PlayerController.Instance._playerHP = PlayerPrefs.GetInt("PlayerHP");
        PlayerController.Instance._leafPoint = PlayerPrefs.GetInt("LeafPoint");
        PlayerController.Instance._collecttedLeafs = PlayerPrefs.GetInt("CollectedLeaf");
    }

    public void SetLeafStatus(int leafID, bool leafStatus)
    {
        _leafStatus.Add(leafID, leafStatus);
    }

    public void NextStage()
    {
        PassedStageCnt++;
        ResetLeafs();
        SceneManager.LoadScene(PassedStageCnt);
    }

    public void ResetLeafs()
    {
        _leafStatus.Clear();
        LeafController.nextIDCnt = 0;
        PlayerPrefs.SetInt("CollectedLeaf", 0);
    }
}
