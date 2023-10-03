using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpd;

    void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * speed);
        if(Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * speed);
        if(Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back * speed);
        if(Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * speed);
        if(Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpSpd);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}