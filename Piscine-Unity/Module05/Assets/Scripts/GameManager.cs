using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public int PlayerHP;
    [HideInInspector] public int PassedStageCnt;
    [HideInInspector] public int LeafPoint;
    [HideInInspector] public int LeafPointPool;
    [HideInInspector] public int DeadCounter;

    void Awake()
    {
        if (Instance == null)
        {
            // PlayerPrefs.DeleteAll(); // Erase whole save system
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

        PlayerPrefs.SetInt("DeadCounter", DeadCounter);
        PlayerPrefs.SetInt("PassedStageCounter", PassedStageCnt);

        UIManager.Instance.RefreshUIinGame = true;
    }

    public void Load()
    {
        PlayerHP = PlayerPrefs.GetInt("PlayerHP");

        LeafPoint = PlayerPrefs.GetInt("LeafPoint");
        LeafPointPool = PlayerPrefs.GetInt("LeafPointPool");

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
        LeafPoint = 0;
        PlayerHP = 3;
        ResetLeafs();
    }

    public void ResetVars()
    {
        PlayerHP = 3;
        PassedStageCnt = 1;
        LeafPoint = 0;
        LeafPointPool = 0;
        DeadCounter = 0;
        LeafController.nextID = 0;
    }

    void ResetLeafs()
    {
        LeafController.nextID = 0;
        for (int i = LeafController.leafsNumber - 1; i >= 0 ; i--)
            PlayerPrefs.DeleteKey(i + "Leaf");
    }
}
