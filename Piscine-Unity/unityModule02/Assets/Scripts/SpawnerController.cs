using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _spawnedObj;
    [SerializeField] private float delayTime;
     
    void Start()
    {
        InvokeRepeating("Spawn", 1, delayTime);
    }

    void Spawn()
    {
        Instantiate(_spawnedObj, _spawnPoint.position, _spawnedObj.transform.rotation);  
    }

    void OnDrawGizmos()
    {
        for(int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
    }
}
