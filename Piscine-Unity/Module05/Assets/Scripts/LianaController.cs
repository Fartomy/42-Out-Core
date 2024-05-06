using UnityEngine;

public class LianaController : MonoBehaviour
{
    [SerializeField] private AudioClip _lianaHitClip;
    private Animator _animator;
    private AudioManager _audioManager;

    void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
        _audioManager.PlayAudioClip(_lianaHitClip, transform, 1);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        CancelInvoke("LianaAttack");
    }
}
