using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Transform _platform;
    private Transform _startPos;
    private Transform _endPos;
    private int direction = 1; 
    [SerializeField] private float moveSpeed;

    void Awake()
    {
        _startPos = transform.Find("startPoint").transform;
        _endPos = transform.Find("endPoint").transform;
        _platform = transform.Find("platform").transform;
    }

    void Update()
    {
        MovePlatform();
    }

    void OnDrawGizmos()
    {
        if(_platform != null && _startPos != null && _endPos != null)
        {
            Gizmos.DrawLine(_platform.position, _startPos.position);
            Gizmos.DrawLine(_platform.position, _endPos.position);
        }
    }

    Vector3 currentMoveTarget()
    {
        if(direction == 1)
            return _startPos.position;
        else
            return _endPos.position;
    }

    void MovePlatform()
    {
        Vector3 target = currentMoveTarget();
        _platform.position = Vector3.Lerp(_platform.position, target, moveSpeed * Time.deltaTime);
        float distance = (target - (Vector3)_platform.position).magnitude;
        if(distance <= 0.1f)
            direction *= -1;
    }
}
