using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rgb;
    private bool isOnTheGround = true;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    private bool focusTargets;
    private GameObject _camera;

    void Awake()
    {
        _camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        CharLock();
        Movement();
    }

    void CharLock()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            focusTargets = false;
            if (gameObject.name == "Thomas" && !focusTargets)
            {
                focusTargets = true;
                _rgb = GetComponent<Rigidbody>();
                _camera.transform.parent = _rgb.transform;
                _camera.transform.position = new Vector3(_rgb.transform.position.x,
                                                         _camera.transform.position.y,
                                                         _camera.transform.position.z);
            }
            if (gameObject.name == "John")
                _rgb = null;
            if (gameObject.name == "Claire")
                _rgb = null;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            focusTargets = false;
            if (gameObject.name == "Thomas")
                _rgb = null;
            if (gameObject.name == "John" && !focusTargets)
            {
                focusTargets = true;
                _rgb = GetComponent<Rigidbody>();
                _camera.transform.parent = _rgb.transform;
                _camera.transform.position = new Vector3(_rgb.transform.position.x,
                                                         _camera.transform.position.y,
                                                         _camera.transform.position.z);
            }
            if (gameObject.name == "Claire")
                _rgb = null;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            focusTargets = false;
            if (gameObject.name == "Thomas")
                _rgb = null;
            if (gameObject.name == "John")
                _rgb = null;
            if (gameObject.name == "Claire" && !focusTargets)
            {
                focusTargets = true;
                _rgb = GetComponent<Rigidbody>();
                _camera.transform.parent = _rgb.transform;
                _camera.transform.position = new Vector3(_rgb.transform.position.x,
                                                         _camera.transform.position.y,
                                                         _camera.transform.position.z);
            }
        }
    }

    void Movement()
    {
        if (_rgb != null)
        {
            float horizontalVal = Input.GetAxis("Horizontal");

            _rgb.velocity = new Vector3(horizontalVal * _speed, _rgb.velocity.y);
            if (Input.GetButtonDown("Jump") && isOnTheGround)
            {
                _rgb.velocity = Vector3.up * _jumpSpeed;
                isOnTheGround = false;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") ||
           other.gameObject.CompareTag("Thomas") ||
           other.gameObject.CompareTag("Claire") ||
           other.gameObject.CompareTag("John"))
            isOnTheGround = true;
    }
}