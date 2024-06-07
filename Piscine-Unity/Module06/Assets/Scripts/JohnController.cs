using UnityEngine;
using UnityEngine.SceneManagement;

public class JohnController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator animator;
    private GhostController[] _ghosts;

    void Awake()
    {
        _ghosts = FindObjectsOfType<GhostController>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            animator.SetBool("isMoving", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }
        else
            animator.SetBool("isMoving", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ghost"))
        {
            animator.SetTrigger("Faint");
            Debug.Log("Restart!");
            //Time.timeScale = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(other.CompareTag("Gargoyle"))
        {
            for (int i = _ghosts.Length - 1; i >= 0 ; i--)
                _ghosts[i].PlayerDetected(10f);
        }
    }
}
