using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jmpSpeed;
    private int _playerHP = 3;
    private bool _isOnTheGround = true;
    private bool _isDefeated = false;
    private Rigidbody2D _rgbBody;

    [SerializeField] private AudioClip[] _audioClips;
    private Vector3 _startOfLevelPos;

    private CapsuleCollider2D _bodyColl;
    private BoxCollider2D _feetColl;
    private Animator _animator;

    private AudioManager _audioManager;
    private UIManager _uiManager;

    void Awake()
    {
        _rgbBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _bodyColl = GetComponent<CapsuleCollider2D>();
        _feetColl = transform.GetChild(1).GetComponent<BoxCollider2D>();

        _startOfLevelPos = transform.position;

        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        Movement();
        Defeat();
    }

    void Defeat()
    {
        if (_playerHP <= 0 && !_isDefeated)
        {
            _isDefeated = true;
            _animator.SetTrigger("Defeat");
            _uiManager._panelAnim.SetTrigger("Defeated");
            _audioManager.PlayAudioClip(_audioClips[2], transform, 1);
            Invoke("Respawn", 1);
        }
    }

    void Respawn()
    {
        transform.position = _startOfLevelPos + new Vector3(0, 5, 0);
        _uiManager._panelAnim.SetTrigger("Respawn");
        _animator.SetTrigger("Respawn");
        _audioManager.PlayAudioClip(_audioClips[3], transform, 1);
        _playerHP = 3;
        _isDefeated = false;
    }

    void Movement()
    {
        if (_rgbBody != null && _playerHP > 0)
        {
            float horizontalVal = Input.GetAxis("Horizontal");
            if (horizontalVal < 0 || horizontalVal > 0)
            {
                _animator.SetFloat("Walking", Mathf.Abs(horizontalVal));
                if (horizontalVal > 0)
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                else if (horizontalVal < 0)
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            _rgbBody.velocity = new Vector3(horizontalVal * _moveSpeed, _rgbBody.velocity.y);

            if (Input.GetButtonDown("Jump") && _isOnTheGround)
            {
                _rgbBody.velocity = Vector3.up * _jmpSpeed;
                _isOnTheGround = false;
                _animator.SetBool("isJumping", true);
                _bodyColl.direction = CapsuleDirection2D.Vertical;
                _audioManager.PlayAudioClip(_audioClips[0], transform, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool isTouchingGround = _feetColl.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (isTouchingGround == other.CompareTag("tag_ground"))
        {
            _isOnTheGround = true;
            _bodyColl.direction = CapsuleDirection2D.Horizontal;
            _animator.SetBool("isJumping", false);
        }

        if (other.CompareTag("tag_hitbox"))
        {
            _audioManager.PlayAudioClip(_audioClips[1], transform, 1);
            _animator.Play("Take_Damage");
            _playerHP--;
            Debug.Log("PlayerHP: " + _playerHP);
            if (other.name.StartsWith("Jelly"))
                Destroy(other.gameObject);
        }
    }
}
