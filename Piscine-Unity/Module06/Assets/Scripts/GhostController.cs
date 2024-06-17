using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;

public class GhostController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private int _wayIndex;
    private Vector3 _target;
    private bool _isDetected = false;

    public Transform PlayerPos;

    [SerializeField] private AudioClip _playerDetectedSoundClip;
    [SerializeField] private Transform[] _wayPoints;

    [SerializeField] private PostProcessVolume postProcessVolume;
    private LensDistortion _lensDistortion;
    private ColorGrading _colorGrading;

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
            if (postProcessVolume.profile.TryGetSettings(out _lensDistortion) &&
                postProcessVolume.profile.TryGetSettings(out _colorGrading))
            {
                _lensDistortion.intensity.value = -75f;
                _colorGrading.colorFilter.value = Color.red;
            }

            while (elapsedTime < duration)
            {
                _navMeshAgent.SetDestination(PlayerPos.position);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _isDetected = false;
            GetComponent<AudioSource>().enabled = true;
            if (postProcessVolume.profile.TryGetSettings(out _lensDistortion) &&
                postProcessVolume.profile.TryGetSettings(out _colorGrading))
            {
                _lensDistortion.intensity.value = 35f;
                _colorGrading.colorFilter.value = Color.white;
            }
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
        {
            GetComponent<AudioSource>().enabled = false;
            AudioManager.Instance.PlayAudioClip(_playerDetectedSoundClip, transform, 1);
            PlayerDetected(3f);
        }
    }

    public void PlayerDetected(float duration)
    {
        _navMeshAgent.ResetPath();
        _isDetected = true;
        StartCoroutine(TryCatchToPlayer(duration));
    }
}
