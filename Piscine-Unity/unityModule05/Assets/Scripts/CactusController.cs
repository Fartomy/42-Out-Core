using UnityEngine;

public class CactusController : MonoBehaviour
{
    [SerializeField] private GameObject _attackPoint;
    private bool _isItAppear = false;
    private Vector3 _lastPlayerPos;

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _jellyBullet;
    [SerializeField] private AudioClip _jellyThrowClip;

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {

        if (_attackPoint.activeSelf && !_isItAppear)
        {
            _isItAppear = true;
            var _obj = Instantiate(_jellyBullet, _attackPoint.transform.position, _jellyBullet.transform.rotation);
            var blltRgb = _obj.GetComponent<Rigidbody2D>();
            blltRgb.AddForce(_lastPlayerPos * _bulletSpeed * Time.deltaTime);
            AudioManager.Instance.PlayAudioClip(_jellyThrowClip, transform, 1);
            Destroy(_obj, 2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("Attack");
            _lastPlayerPos = other.transform.position - transform.position;
        }
    }
}
