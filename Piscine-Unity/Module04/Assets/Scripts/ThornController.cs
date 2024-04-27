using UnityEngine;

public class ThornController : MonoBehaviour
{
    [SerializeField] private GameObject _attackArea;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            _animator.SetTrigger("Attack");
    }
}
