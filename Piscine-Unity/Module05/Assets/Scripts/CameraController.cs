using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothTime = 0.25f;
    private Vector3 _velocity = Vector3.zero;
    private Transform _playerTransorm;

    void Start()
    {
        _playerTransorm = PlayerController._instance.GetComponent<Transform>();
    }

    void LateUpdate()
    {
        Vector3 targetPos = _playerTransorm.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, _smoothTime); 
    }
}
