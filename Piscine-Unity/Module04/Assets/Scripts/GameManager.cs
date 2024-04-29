using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator _panelAnim;
    private PlayerController _playerController;
    public bool _isDefeated = false;

    void Awake()
    {
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
}
