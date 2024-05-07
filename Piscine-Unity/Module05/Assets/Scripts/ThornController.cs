using UnityEngine;

public class ThornController : MonoBehaviour
{
    [SerializeField] private AudioClip _thornSoundClip;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _animator.SetTrigger("Attack");
            AudioManager._instance.PlayAudioClip(_thornSoundClip, transform, 1);
            Destroy(gameObject, 1.2f);
        }
    }
}
