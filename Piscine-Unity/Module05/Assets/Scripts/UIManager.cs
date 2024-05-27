using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Animator _panelAnim;
    [HideInInspector] public bool RefreshUIinGame = false;
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
        transform.Find("EventSystem").gameObject.SetActive(true); // solution for "There can be only one active Event System." warning message from unity
    }

    void Update()
    {
        if (RefreshUIinGame)
        {
            RefreshUIinGame = false;
            _playerHPText.text = PlayerPrefs.GetInt("PlayerHP").ToString();
            _leafPointText.text = PlayerPrefs.GetInt("LeafPoint").ToString();
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
            SceneManager.LoadScene("MainMenu");
            SetVisibleUI(false, true, false);
        }
    }

    public void Resume()
    {
        if (PlayerPrefs.HasKey("PassedStageCounter"))
        {
            LeafController.nextID = 0;
            GameManager.Instance.Load();
            SceneManager.LoadScene(PlayerPrefs.GetInt("PassedStageCounter"));
            SetVisibleUI(true, false, false);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        GameManager.Instance.ResetVars();
        GameManager.Instance.Save();
        UnlockStagesSetColor(_diaryUnlockStages.transform.childCount, Color.red);
        SceneManager.LoadScene(1);
        SetVisibleUI(true, false, false);
    }

    public void Diary()
    {
        //GameManager.Instance.Load();
        SceneManager.LoadScene("Diary");
        SetVisibleUI(false, false, true);
        if (PlayerPrefs.HasKey("LeafPointPool"))
        {
            _diaryLeafPointPoolText.text = PlayerPrefs.GetInt("LeafPointPool").ToString();
            _diaryDeadCounter.text = PlayerPrefs.GetInt("DeadCounter").ToString();
            if (PlayerPrefs.GetInt("PassedStageCounter") > 1)
                UnlockStagesSetColor(PlayerPrefs.GetInt("PassedStageCounter"), Color.green);
        }
    }

    void UnlockStagesSetColor(int nbr, Color clr)
    {
        for (int i = 1; i < nbr; i++)
            _diaryUnlockStages.transform.GetChild(i).GetComponent<Image>().color = clr;
    }

    void SetVisibleUI(bool visGameIn, bool visMainMenu, bool visDiary)
    {
        _gameIn.SetActive(visGameIn);
        _mainMenu.SetActive(visMainMenu);
        _diary.SetActive(visDiary);
    }
}
