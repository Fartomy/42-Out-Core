using UnityEngine;

public class CactusController : MonoBehaviour
{
    [SerializeField] private GameObject _attackPoint;
    [SerializeField] private GameObject _jellyBullet;
    [SerializeField] private float _bulletSpeed;
    private bool _isItAppear = true;
    private Animator _animator;
    private Vector3 _lastPlayerPos;
    [SerializeField] private AudioClip _jellyThrowClip;
    private AudioManager _audioManager;

    void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {
        if (_attackPoint.activeSelf && _isItAppear)
        {
            _isItAppear = false;
            var _obj = Instantiate(_jellyBullet, _attackPoint.transform.position, _jellyBullet.transform.rotation);
            Rigidbody2D _rgb = _obj.GetComponent<Rigidbody2D>();
            _rgb.AddForce(_lastPlayerPos * _bulletSpeed * Time.deltaTime);
            _audioManager.PlayAudioClip(_jellyThrowClip, transform, 1);
            Destroy(_obj, 2);
        }
        else if (!_attackPoint.activeSelf)
            _isItAppear = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _lastPlayerPos = other.transform.position - transform.position;
            _animator.SetTrigger("Attack");
        }
    }
}
