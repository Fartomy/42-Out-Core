using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Animator _panelAnim;
    [HideInInspector] public bool isRefreshGameInUI = false;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameIn;
    [SerializeField] private GameObject _diary;
    [SerializeField] private TextMeshProUGUI _playerHPText;
    [SerializeField] private TextMeshProUGUI _leafPointText;
    [SerializeField] private TextMeshProUGUI _diaryLeafPointPoolText;
    [SerializeField] private TextMeshProUGUI _diaryDeadCounter;
    [SerializeField] private GameObject _diaryUnlockStages;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        _playerHPText.text = "3";
        _leafPointText.text = "0";
        transform.Find("EventSystem").gameObject.SetActive(true); // solution for "There can be only one active Event System." warning message from unity
    }

    void Update()
    {
        if (isRefreshGameInUI)
        {
            _playerHPText.text = PlayerPrefs.GetInt("PlayerHP").ToString();
            _leafPointText.text = PlayerPrefs.GetInt("LeafPoint").ToString();
            isRefreshGameInUI = false;
        }
    }

    public void MainMenu()
    {
        if (SceneManager.GetActiveScene().name == "Diary")
        {
            SceneManager.LoadScene("MainMenu");
            SetVisibleUI(false, true, false);
        }
        else
        {
            GameManager.Instance.Save();
            LeafController.nextIDCnt = 0;
            SceneManager.LoadScene("MainMenu");
            SetVisibleUI(false, true, false);
        }
    }

    public void Resume()
    {
        if (GameManager.Instance.PassedStageCnt > 0)
        {
            SceneManager.LoadScene(GameManager.Instance.PassedStageCnt);
            SetVisibleUI(true, false, false);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        GameManager.Instance.Reset();
        GameManager.Instance.PassedStageCnt = 1;
        PlayerPrefs.SetInt("LeafPointPool", 0);
        PlayerPrefs.SetInt("DeadCounter", 0);
        isRefreshGameInUI = true;
        for (int i = _diaryUnlockStages.transform.childCount - 1; i >= 1 ; i--)
            _diaryUnlockStages.transform.GetChild(i).GetComponent<Image>().color = Color.red;
        SceneManager.LoadScene(1);
        SetVisibleUI(true, false, false);
    }

    public void Diary()
    {
        SceneManager.LoadScene("Diary");
        SetVisibleUI(false, false, true);
        if (GameManager.Instance.PassedStageCnt > 0)
        {
            _diaryLeafPointPoolText.text = PlayerPrefs.GetInt("LeafPointPool").ToString();
            _diaryDeadCounter.text = PlayerPrefs.GetInt("DeadCounter").ToString();
            for (int i = 1; i < GameManager.Instance.PassedStageCnt; i++)
                _diaryUnlockStages.transform.GetChild(i).GetComponent<Image>().color = Color.green;
        }
        else
        {
            _diaryLeafPointPoolText.text = "0";
            _diaryDeadCounter.text = "0";
        }
    }

    void SetVisibleUI(bool visGameIn, bool visMainMenu, bool visDiary)
    {
        _gameIn.SetActive(visGameIn);
        _mainMenu.SetActive(visMainMenu);
        _diary.SetActive(visDiary);
    }
}
