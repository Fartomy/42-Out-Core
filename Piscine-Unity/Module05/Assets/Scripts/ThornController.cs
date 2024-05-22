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
            AudioManager.Instance.PlayAudioClip(_thornSoundClip, transform, 1);
        }
    }
}
