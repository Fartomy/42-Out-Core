using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public int PlayerHP;
    [HideInInspector] public int PassedStageCnt;
    [HideInInspector] public int CollecttedLeafs;
    [HideInInspector] public int LeafPoint;
    [HideInInspector] public int LeafPointPool;
    [HideInInspector] public int DeadCounter;

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
        PlayerPrefs.SetInt("PlayerHP", PlayerHP);

        PlayerPrefs.SetInt("LeafPoint", LeafPoint);
        PlayerPrefs.SetInt("LeafPointPool", LeafPointPool);
        PlayerPrefs.SetInt("CollectedLeafs", CollecttedLeafs);

        PlayerPrefs.SetInt("DeadCounter", DeadCounter);
        PlayerPrefs.SetInt("PassedStageCounter", PassedStageCnt);

        UIManager.Instance.RefreshUIinGame = true;
    }

    public void Load()
    {
        PlayerHP = PlayerPrefs.GetInt("PlayerHP");

        LeafPoint = PlayerPrefs.GetInt("LeafPoint");
        LeafPointPool = PlayerPrefs.GetInt("LeafPointPool");
        CollecttedLeafs = PlayerPrefs.GetInt("CollectedLeafs");
        
        DeadCounter = PlayerPrefs.GetInt("DeadCounter");
        PassedStageCnt = PlayerPrefs.GetInt("PassedStageCounter");

        UIManager.Instance.RefreshUIinGame = true;
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
            PrepareNextStage();
            Save();
            SceneManager.LoadScene(PassedStageCnt);
            Load();
        }
    }

    void PrepareNextStage()
    {
        PassedStageCnt++;
        CollecttedLeafs = 0;
        LeafPoint = 0;
        PlayerHP = 3;
        // Maybe reset leafs
    }

    public void ResetVars()
    {
        PlayerHP = 3;
        PassedStageCnt = 1;
        CollecttedLeafs = 0;
        LeafPoint = 0;
        LeafPointPool = 0;
        DeadCounter = 0;
    }
}
