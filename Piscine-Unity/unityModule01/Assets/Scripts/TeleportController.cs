using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private GameObject telOUT;

    void OnDrawGizmos()
    {
        if(telOUT != null)
        {
            Gizmos.DrawLine(transform.position, telOUT.transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Thomas") || other.CompareTag("Claire") || other.CompareTag("John"))
            other.gameObject.transform.position = telOUT.transform.position;
    }
}
