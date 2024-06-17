using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class JohnController : MonoBehaviour
{
    public static JohnController Instance;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator animator;
    
    [SerializeField] private CinemachineFreeLook _tpsCamera;
    [SerializeField] private CinemachineVirtualCamera _fpsCamera;
    [SerializeField] private Camera _camera;

    [SerializeField] private AudioSource _footsteps;

    [SerializeField] private AudioClip _getkeySoundClip;
    [SerializeField] private AudioClip _gargoyleDetectSoundClip;

    [HideInInspector] public int keyCounter = 0;
    [HideInInspector] public bool _isFaint = false;

    private GhostController[] _ghosts;
    private bool isFPSMode = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        _ghosts = FindObjectsOfType<GhostController>();
    }

    void Update()
    {
        if (!_isFaint)
            Movement();
        if (Input.GetKeyUp(KeyCode.C))
            StartCoroutine(SwitchCameraMode());
        if (isFPSMode && Input.GetKeyUp(KeyCode.Z))
        {
            CinemachinePOV pov = _fpsCamera.GetCinemachineComponent<CinemachinePOV>();
            pov.m_VerticalAxis.Value = 0;
            pov.m_HorizontalAxis.Value = 0;
        }
    }

    IEnumerator SwitchCameraMode()
    {
        isFPSMode = !isFPSMode;

        if (isFPSMode)
        {
            _fpsCamera.enabled = true;
            _tpsCamera.enabled = false;
            yield return new WaitForSeconds(2);
            _camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
        }
        else
        {
            _tpsCamera.enabled = true;
            _fpsCamera.enabled = false;
            _camera.cullingMask |= (1 << LayerMask.NameToLayer("Player"));
        }
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isMoving", true);
            _footsteps.enabled = true;

            // Kameraya göre yönü hesaplamak için:
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            targetAngle += Camera.main.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Karakteri döndürmek:
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);

            // Karakteri yönüne göre hareket ettirmek:
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.position += moveDirection * _moveSpeed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("isMoving", false);
            _footsteps.enabled = false;
        }
    }

    void JohnCaught()
    {
        UIManager.Instance.isCaught = true;
        _isFaint = true;
        _footsteps.enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(GameManager.Instance.RestartStage());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
            JohnCaught();

        if (other.CompareTag("Gargoyle"))
        {
            AudioManager.Instance.PlayAudioClip(_gargoyleDetectSoundClip, transform, 1);
            for (int i = _ghosts.Length - 1; i >= 0; i--)
                _ghosts[i].PlayerDetected(10f);
        }

        if (other.CompareTag("Key"))
        {
            keyCounter++;
            Debug.Log("Keys: " + keyCounter);
            AudioManager.Instance.PlayAudioClip(_getkeySoundClip, transform, 1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Wardrobe"))
        {
            UIManager.Instance.isWon = true;
            StartCoroutine(GameManager.Instance.WonStage());
        }
    }
}
