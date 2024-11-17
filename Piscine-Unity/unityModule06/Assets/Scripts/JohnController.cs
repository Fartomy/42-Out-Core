using System.Collections;
using Cinemachine;
using UnityEngine;

public class JohnController : MonoBehaviour
{
    public static JohnController Instance;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator animator;

    [SerializeField] private CinemachineFreeLook _tpsCamera;
    [SerializeField] private CinemachineVirtualCamera _fpsCamera;
    
    [SerializeField] private SkinnedMeshRenderer _johnMeshRndr; 

    [SerializeField] private AudioSource _footsteps;

    [SerializeField] private AudioClip _gargoyleDetectSoundClip;

    [HideInInspector] public bool _isFaint = false;
    private bool canSwitchCamera = true;

    private GhostController[] _ghosts;
    private bool isFPSMode = false;
    private Vector3 direction;

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
        if (Input.GetKeyUp(KeyCode.C) && canSwitchCamera)
            StartCoroutine(SwitchCameraMode());
    }

    IEnumerator SwitchCameraMode()
    {
        isFPSMode = !isFPSMode;
        animator.SetBool("isMoving", false);
        _footsteps.enabled = false;
        canSwitchCamera = false;

        if (isFPSMode)
        {
            _fpsCamera.enabled = true;
            _tpsCamera.enabled = false;
            yield return new WaitForSeconds(2);
            _johnMeshRndr.enabled = false;
        }
        else
        {
            _tpsCamera.enabled = true;
            _fpsCamera.enabled = false;
            _johnMeshRndr.enabled = true;
            yield return new WaitForSeconds(2);
        }
        canSwitchCamera = true;
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0, vertical).normalized;
        if (!isFPSMode)
            TPSMove();
        else
            FPSMove();
    }

    void TPSMove()
    {
        if (direction.magnitude >= 0.1f)
            CalcDirectAndMove();
        else
        {
            animator.SetBool("isMoving", false);
            _footsteps.enabled = false;
        }
    }

    void FPSMove()
    {
        if (Input.GetKey(KeyCode.Z))
            CalcDirectAndMove();
        if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool("isMoving", false);
            _footsteps.enabled = false;
        }
    }

    void CalcDirectAndMove()
    {
        animator.SetBool("isMoving", true);
        _footsteps.enabled = true;

        // Kameraya göre yönü hesaplamak:
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        targetAngle += Camera.main.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);

        // Karakteri döndürmek:
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
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

        if (other.gameObject.CompareTag("Wardrobe"))
        {
            UIManager.Instance.isWon = true;
            StartCoroutine(GameManager.Instance.WonStage());
        }
    }
}
