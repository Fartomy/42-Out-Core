using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _doorAudioClip;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && JohnController.Instance.keyCounter > 2)
        {
            _animator.SetTrigger("Open");
            AudioManager.Instance.PlayAudioClip(_doorAudioClip, transform, 1);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _animator.SetTrigger("Close");
            AudioManager.Instance.PlayAudioClip(_doorAudioClip, transform, 1);
        }
    }
}
