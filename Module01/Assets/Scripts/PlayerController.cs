using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rgb;
    private GameObject _camera;
    private const float speed = 2f;
    private const float jumpSpeed = 200f;
    //private bool isOnTheGround = true;

    void Awake()
    {
        _camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        CharFocus();
    }

    void CharFocus()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && gameObject.name == "Thomas")
        {
            _camera.transform.parent = gameObject.transform;
            _camera.transform.position = new Vector3(gameObject.transform.position.x,
                                                     gameObject.transform.position.y + 2.5f,
                                                     _camera.transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && gameObject.name == "John")
        {
            _camera.transform.parent = gameObject.transform;
            _camera.transform.position = new Vector3(gameObject.transform.position.x,
                                                     gameObject.transform.position.y + 2.5f,
                                                     _camera.transform.position.z);

        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && gameObject.name == "Claire")
        {
            _camera.transform.parent = gameObject.transform;
            _camera.transform.position = new Vector3(gameObject.transform.position.x,
                                                     gameObject.transform.position.y + 2.5f,
                                                     _camera.transform.position.z);
        }
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.A))
            _rgb.AddForce(Vector3.left * speed);
        if(Input.GetKey(KeyCode.D))
            _rgb.AddForce(Vector3.right * speed);
        if(Input.GetKeyDown(KeyCode.Space))//&& isOnTheGround)
        {
            _rgb.AddForce(Vector3.up * jumpSpeed);
            //isOnTheGround = false;
        }
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     if(other.gameObject.CompareTag("Ground"))
    //         isOnTheGround = true;
    // }
}