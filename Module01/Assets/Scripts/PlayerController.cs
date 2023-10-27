using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rgb;
    private GameObject _camera;
    private bool[] _lockKey = new bool[3];
    public bool exitLock; 
    private bool isOnTheGround = true;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

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
        if (Input.GetKeyDown(KeyCode.Alpha1) && !_lockKey[0])
        {
            _lockKey[0] = true;
            _lockKey[1] = false;
            _lockKey[2] = false;
            if (gameObject.name == "Thomas")
            {
                _rgb = GetComponent<Rigidbody>();
                _camera.transform.parent = _rgb.transform;
                _camera.transform.position = new Vector3(_rgb.transform.position.x,
                                                         _rgb.transform.position.y + 2f,
                                                         _camera.transform.position.z);
            }
            if (gameObject.name == "John")
                _rgb = null;
            if (gameObject.name == "Claire")
                _rgb = null;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !_lockKey[1])
        {
            _lockKey[0] = false;
            _lockKey[1] = true;
            _lockKey[2] = false;
            if (gameObject.name == "Thomas")
                _rgb = null;
            if (gameObject.name == "John")
            {
                _rgb = GetComponent<Rigidbody>();
                _camera.transform.parent = _rgb.transform;
                _camera.transform.position = new Vector3(_rgb.transform.position.x,
                                                         _rgb.transform.position.y + 2f,
                                                         _camera.transform.position.z);
            }
            if (gameObject.name == "Claire")
                _rgb = null;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !_lockKey[2])
        {
            _lockKey[0] = false;
            _lockKey[1] = false;
            _lockKey[2] = true;
            if (gameObject.name == "Thomas")
                _rgb = null;
            if (gameObject.name == "John")
                _rgb = null;
            if (gameObject.name == "Claire")
            {
                _rgb = GetComponent<Rigidbody>();
                _camera.transform.parent = _rgb.transform;
                _camera.transform.position = new Vector3(_rgb.transform.position.x,
                                                         _rgb.transform.position.y + 2f,
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
        if (other.gameObject.CompareTag("Trap"))
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") ||
                   other.gameObject.CompareTag("Thomas") ||
                   other.gameObject.CompareTag("Claire") ||
                   other.gameObject.CompareTag("John"))
            isOnTheGround = true;
        if(other.gameObject.CompareTag("hole"))
        {
            _camera.transform.SetParent(null);
            Destroy(gameObject, 3);
        }
        if(other.gameObject.CompareTag("bullet"))
            Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("exit_red"))
        {
            if(gameObject.name == "Thomas")
                exitLock = true;
        }
        if(other.gameObject.CompareTag("exit_yellow"))
        {
            if(gameObject.name == "John")
                exitLock = true;
        }
        if(other.gameObject.CompareTag("exit_blue"))
        {
            if(gameObject.name == "Claire")
                exitLock = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("exit_red"))
        {
            if(gameObject.name == "Thomas")
                exitLock = false;
        }
        if(other.gameObject.CompareTag("exit_yellow"))
        {
            if(gameObject.name == "John")
                exitLock = false;
        }
        if(other.gameObject.CompareTag("exit_blue"))
        {
            if(gameObject.name == "Claire")
                exitLock = false;
        }    
    }
}