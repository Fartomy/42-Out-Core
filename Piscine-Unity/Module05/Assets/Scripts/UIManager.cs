using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    [SerializeField] private TextMeshProUGUI _collectedLeafText;
    [SerializeField] private TextMeshProUGUI _playerHPText;
    [SerializeField] private Animator _panelAnim;

    [HideInInspector] public bool _isDefeated = false;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    void LateUpdate()
    {
        if (PlayerController._instance != null)
        {
            _playerHPText.text = PlayerController._instance._playerHP.ToString();
            _collectedLeafText.text = PlayerController._instance.LeafPoints.ToString();
            if (PlayerController._instance._playerIsDead && !_isDefeated)
            {
                _isDefeated = true;
                _panelAnim.SetTrigger("Defeated");
                _panelAnim.SetTrigger("Respawn");
            }
        }
    }

    public void BackMainMenu()
    {
        GameManager._instance.Save();
        SceneManager.LoadScene(0);
    }
}
