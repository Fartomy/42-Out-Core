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
            InvokeRepeating("LianaAttack", 0, 1);
    }

    void LianaAttack()
    {
        _animator.SetTrigger("Attack");
        AudioManager._instance.PlayAudioClip(_lianaHitClip, transform, 1);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        CancelInvoke("LianaAttack");
    }
}
