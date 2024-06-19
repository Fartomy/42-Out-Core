using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI _keyStatusText;
    [SerializeField] private GameObject _wonImage;
    [SerializeField] private GameObject _caughtImage;
    [SerializeField] private GameObject _faintImage;

    [HideInInspector] public bool isCaught = false;
    [HideInInspector] public bool isWon = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        if (GameManager.Instance != null && _keyStatusText != null)
        {
            _keyStatusText.text = GameManager.Instance.keyCounter.ToString() + " / 3";
            if (GameManager.Instance.keyCounter >= 3)
                _keyStatusText.color = Color.green;
        }
    }

    void Update()
    {
        if (isWon)
        {
            isWon = false;
            _wonImage.SetActive(true);
            _faintImage.SetActive(true);
        }
        if (isCaught)
        {
            isCaught = false;
            _caughtImage.SetActive(true);
            _faintImage.SetActive(true);
        }
    }

    public void Continue()
    {
        if (PlayerPrefs.HasKey("KeyCounter"))
        {
            Key.nextID = 0;
            GameManager.Instance.Load();
            SceneManager.LoadScene(1);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        GameManager.Instance.keyCounter = 0;
        GameManager.Instance.Save();
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        EditorApplication.isPlaying = false;
    }

    public void MainMenu()
    {
        GameManager.Instance.Save();
        SceneManager.LoadScene(0);
    }

    public void ChangeKeyStatus()
    {
        _keyStatusText.text = GameManager.Instance.keyCounter.ToString() + " / 3";
        if (GameManager.Instance.keyCounter >= 3)
            _keyStatusText.color = Color.green;
    }
}
