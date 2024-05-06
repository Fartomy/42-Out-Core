using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [SerializeField] private Animator _panelAnim;
    [SerializeField] private TextMeshProUGUI _leafPointText;
    [SerializeField] private TextMeshProUGUI _playerHPText;
    private PlayerController _playerController;
    [HideInInspector] public bool _isDefeated = false;

    void Awake()
    {
        if (_instance == null)
            _instance = this;

        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();    
    }

    void Update()
    {
        if(_playerController._playerIsDead && !_isDefeated)
        {
            _isDefeated = true;
            _panelAnim.SetTrigger("Defeated");
            _panelAnim.SetTrigger("Respawn");
        }
    }

    void LateUpdate()
    {
        _leafPointText.text = _playerController._collectedLeafs.ToString();
        _playerHPText.text = _playerController._playerHP.ToString();
    }

    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
