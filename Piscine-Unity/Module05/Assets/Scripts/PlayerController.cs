using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jmpSpeed;
    [SerializeField] private AudioClip[] _audioClips;
    private CapsuleCollider2D _capsuleColl;
    [HideInInspector] public int _playerHP = 3;
    [HideInInspector] public int LeafPoints = 0;
    [HideInInspector] public int CollectedLeafs = 0;
    [HideInInspector] public int passedStageNbr = 0;
    [HideInInspector] public bool _playerIsDead = false;
    private Rigidbody2D _rgbBody;
    private bool _isOnTheGround = true;
    private Animator _animator;
    private Vector3 _startOfLevelPos;
    public static PlayerController _instance;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        _startOfLevelPos = transform.position;
        _capsuleColl = GetComponent<CapsuleCollider2D>();
        _rgbBody = GetComponent<Rigidbody2D>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        if(PlayerPrefs.HasKey("PlayerHP"))
        {
            GameManager._instance.Load();
            CollectedLeafs = 0;
        }
    }

    void Update()
    {
        Movement();
        Defeat();
    }

    void Defeat()
    {
        if (_playerHP <= 0 && !_playerIsDead)
        {
            _playerIsDead = true;
            _animator.SetBool("isDead", true);
            AudioManager._instance.PlayAudioClip(_audioClips[2], transform, 1);
            _rgbBody.constraints = RigidbodyConstraints2D.FreezeAll;
            _capsuleColl.enabled = false;
            Invoke("Respawn", 1);
        }
    }

    void Respawn()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        _animator.SetBool("isDead", false);
        transform.position = _startOfLevelPos;
        _rgbBody.constraints = RigidbodyConstraints2D.None;
        _capsuleColl.enabled = true;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        _animator.SetTrigger("Respawn");
        AudioManager._instance.PlayAudioClip(_audioClips[3], transform, 1);
        _playerHP = 3;
        _playerIsDead = false;
        UIManager._instance._isDefeated = false;
    }

    void Movement()
    {
        if (_rgbBody != null && !_playerIsDead)
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
                AudioManager._instance.PlayAudioClip(_audioClips[0], transform, 1);
                #region Capsule Collider Properties Change Section
                _capsuleColl.direction = CapsuleDirection2D.Vertical;
                _capsuleColl.offset = new Vector2(0, 1.25f);
                _capsuleColl.size = new Vector2(2, 3);
                #endregion
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("tag_ground"))
        {
            _isOnTheGround = true;
            _animator.SetBool("isJumping", false);
            #region Capsule Collider Properties Change Section
            _capsuleColl.direction = CapsuleDirection2D.Horizontal;
            _capsuleColl.offset = new Vector2(0, 0f);
            _capsuleColl.size = new Vector2(3.2f, 0.7f);
            #endregion
            if (other.gameObject.name == "EndOfStagePoint")
            {
                if (CollectedLeafs >= 5)
                    GameManager._instance.NextStage();
                else
                    other.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("tag_ground"))
            if (other.gameObject.name == "EndOfStagePoint")
                other.transform.GetChild(0).gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tag_hitbox"))
        {
            AudioManager._instance.PlayAudioClip(_audioClips[1], transform, 1);
            _animator.SetTrigger("TakeDamage");
            _playerHP--;
            GameManager._instance.Save();
            if (other.name.StartsWith("Jelly"))
                Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("tag_leaf"))
        {
            LeafPoints += 5;
            CollectedLeafs++;
            GameManager._instance.Save();
            AudioManager._instance.PlayAudioClip(_audioClips[4], transform, 1);
            other.gameObject.SetActive(false);
        }
    }
}
