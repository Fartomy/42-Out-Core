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

    void FixedUpdate()
    {
        Movement(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    void Update()
    {
        if((transform.position.x >= 30 || transform.position.x <= -30) ||
           (transform.position.z >= 30 || transform.position.z <= -30) ||
           (transform.position.y >= 45))
           {
            transform.position = new Vector3(0, 7, 0);
            rb.velocity = Vector3.zero;
           }
        if(Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpSpd);
    }

    void Movement(Vector3 direction)
    {
        rb.AddForce(direction * speed);
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