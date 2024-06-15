using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && JohnController.Instance.keyCounter > 2)
            _animator.SetTrigger("Open");
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            _animator.SetTrigger("Close");
    }
}
