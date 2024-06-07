using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _wayPoints;
    private int _wayIndex;
    private Vector3 _target;
    private bool _isDetected = false;
    public Transform PlayerPos;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Patrolling();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _target) < 1)
        {
            IteratePointIndex();
            Patrolling();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        for (int i = _wayPoints.Length - 1; i >= 0; i--)
            Gizmos.DrawLine(transform.position, _wayPoints[i].position);
    }

    IEnumerator TryCatchToPlayer(float duration)
    {
        if (_isDetected)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                _navMeshAgent.SetDestination(PlayerPos.position);
                Debug.Log("Coroutine çalişiyor. Geçen süre: " + elapsedTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            Debug.Log("Coroutine tamamlandi.");
            _isDetected = false;
            Patrolling();
        }
    }

    void IteratePointIndex()
    {
        _wayIndex++;
        if (_wayIndex == _wayPoints.Length)
            _wayIndex = 0;
    }

    void Patrolling()
    {
        if (!_isDetected)
        {
            _target = _wayPoints[_wayIndex].position;
            _navMeshAgent.SetDestination(_target);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PlayerDetected(3f);
    }

    public void PlayerDetected(float duration)
    {
        _navMeshAgent.ResetPath();
        _isDetected = true;
        StartCoroutine(TryCatchToPlayer(duration));
    }
}
