using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _smoothing;
    [SerializeField] private Vector3 _offset;
    private Vector3 _velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (_playerTransform)
            transform.position = Vector3.SmoothDamp(transform.position + _offset * Time.deltaTime, _playerTransform.position, ref _velocity, _smoothing);
    }
}
