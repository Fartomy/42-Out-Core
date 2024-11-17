using UnityEngine;

public class LianaController : MonoBehaviour
{
    [SerializeField] private AudioClip _lianaHitClip;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            LianaAttack();
    }

    void LianaAttack()
    {
        _animator.SetTrigger("Attack");
        AudioManager.Instance.PlayAudioClip(_lianaHitClip, transform, 1);
    }
}
