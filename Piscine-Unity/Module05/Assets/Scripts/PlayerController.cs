using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jmpSpeed;
    private bool _isOnTheGround = true;
    private bool _isDefeated = false;
    private Rigidbody2D _rgbBody;

    [SerializeField] private AudioClip[] _audioClips;

    private Transform _startPoint;

    private CapsuleCollider2D _bodyColl;
    private BoxCollider2D _feetColl;

    private Animator _animator;

    void Awake()
    {
        if(Instance == null)
            Instance = this;

        _rgbBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _bodyColl = GetComponent<CapsuleCollider2D>();
        _feetColl = transform.GetChild(1).GetComponent<BoxCollider2D>();

        _startPoint = GameObject.FindGameObjectWithTag("start_point").transform;
        transform.position = _startPoint.position + new Vector3(0, 1, 0);
    }

    void Update()
    {
        Movement();
        Defeat();
    }

    void Defeat()
    {
        if (GameManager.Instance.PlayerHP <= 0 && !_isDefeated)
        {
            _isDefeated = true;
            GameManager.Instance.DeadCounter++;
            _rgbBody.velocity = Vector2.zero;
            _animator.SetFloat("Walking", 0);
            _animator.SetTrigger("Defeat");
            UIManager.Instance._panelAnim.SetTrigger("Defeated");
            AudioManager.Instance.PlayAudioClip(_audioClips[2], transform, 1);
            Invoke("Respawn", 1);
        }
    }

    void Respawn()
    {
        transform.position = _startPoint.position + new Vector3(0, 1, 0);
        UIManager.Instance._panelAnim.SetTrigger("Respawn");
        _animator.SetTrigger("Respawn");
        AudioManager.Instance.PlayAudioClip(_audioClips[3], transform, 1);
        GameManager.Instance.PlayerHP = 3;
        _isDefeated = false;
        GameManager.Instance.Save();
    }

    void Movement()
    {
        if (_rgbBody != null && GameManager.Instance.PlayerHP > 0)
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
                AudioManager.Instance.PlayAudioClip(_audioClips[0], transform, 1);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("end_point"))
        {
            if (GameManager.Instance.LeafPoint >= 25)
                GameManager.Instance.NextStage();
            else
                other.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("end_point"))
            other.transform.GetChild(1).gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool isTouchingGround = _feetColl.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (isTouchingGround)
        {
            _isOnTheGround = true;
            _bodyColl.direction = CapsuleDirection2D.Horizontal;
            _animator.SetBool("isJumping", false);
        }

        if (other.CompareTag("tag_hitbox"))
        {
            AudioManager.Instance.PlayAudioClip(_audioClips[1], transform, 1);
            _animator.Play("Take_Damage");
            GameManager.Instance.PlayerHP--;
            GameManager.Instance.Save();
            if (other.name.StartsWith("Jelly"))
                Destroy(other.gameObject);
        }
    }
}
