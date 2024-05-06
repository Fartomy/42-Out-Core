using UnityEngine;

public class ThornController : MonoBehaviour
{
    [SerializeField] private AudioClip _thornSoundClip;
    private Animator _animator;
    private AudioManager _audioManager;

    void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _animator.SetTrigger("Attack");
            _audioManager.PlayAudioClip(_thornSoundClip, transform, 1);
            Destroy(gameObject, 1.2f);
        }
    }
}
