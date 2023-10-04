using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameObject[] obj = new GameObject[3];
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody[] _rb = new Rigidbody[3];
    private bool[] _lock = new bool[3];
    private GameObject _camera;
    private bool objIsOnGround = true;

    void Awake()
    {
        obj[0] = GameObject.FindWithTag("Thomas").gameObject;
        obj[1] = GameObject.FindWithTag("John").gameObject;
        obj[2] = GameObject.FindWithTag("Claire").gameObject;
        _rb[0] = obj[0].GetComponent<Rigidbody>();
        _rb[1] = obj[1].GetComponent<Rigidbody>();
        _rb[2] = obj[2].GetComponent<Rigidbody>();
        _camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        CharacterActive();
        ResetGame();
        if(_lock[0])
            Movement(_rb[0], this.jumpSpeed, this.speed);
        if(_lock[1])
            Movement(_rb[1], this.jumpSpeed, this.speed);
        if(_lock[2])
            Movement(_rb[2], this.jumpSpeed, this.speed);
    }

    void CharacterActive()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _camera.transform.parent = obj[0].transform;
            _camera.transform.position = new Vector3(obj[0].transform.position.x, 
                                        obj[0].transform.position.y + 1.5f, _camera.transform.position.z);
            _lock[0] = true;
            _lock[1] = false;
            _lock[2] = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _camera.transform.parent = obj[1].transform;
            _camera.transform.position = new Vector3(obj[1].transform.position.x, 
                                        obj[0].transform.position.y + 1.5f, _camera.transform.position.z);
            _lock[1] = true;
            _lock[0] = false;
            _lock[2] = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            _camera.transform.parent = obj[2].transform;
            _camera.transform.position = new Vector3(obj[2].transform.position.x,
                                        obj[0].transform.position.y + 1.5f, _camera.transform.position.z);
            _lock[2] = true;
            _lock[0] = false;
            _lock[1] = false;
        }
    }

    void Movement(Rigidbody rgb, float jumpSpeed, float speed)
    {
        if(Input.GetKey(KeyCode.A))
            rgb.AddForce(Vector3.left * speed);
        if(Input.GetKey(KeyCode.D))
            rgb.AddForce(Vector3.right * speed);
        if(Input.GetKeyDown(KeyCode.Space) && objIsOnGround)
        {
            rgb.velocity = new Vector3(0, 5, 0);
            objIsOnGround = false;
        }
    }

    void ResetGame()
    {
        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("Stage1");
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
            objIsOnGround = true;
    }
}