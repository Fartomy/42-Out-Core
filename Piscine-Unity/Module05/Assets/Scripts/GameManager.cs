using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    [SerializeField] private GameObject _leafs; 

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            Destroy(_leafs);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(_leafs);
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("PlayerHP", PlayerController._instance._playerHP);
        PlayerPrefs.SetInt("LeafPoints", PlayerController._instance.LeafPoints);
        PlayerPrefs.SetInt("PassedStageNumber", PlayerController._instance.passedStageNbr);
    }

    public void Load()
    {
        PlayerController._instance._playerHP = PlayerPrefs.GetInt("PlayerHP");
        PlayerController._instance.LeafPoints = PlayerPrefs.GetInt("LeafPoints");
        PlayerController._instance.passedStageNbr = PlayerPrefs.GetInt("PassedStageNumber");
    }

    public void NextStage()
    {
        PlayerController._instance.passedStageNbr++;
        Save();
        for (int i = _leafs.transform.childCount - 1; i >= 0 ; i--)
            _leafs.transform.GetChild(i).gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
