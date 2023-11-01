using UnityEditor;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;

    [Header("Properties")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _shotDelaySec;

    private bool _shotLock = false;

    void ShotToTarget(ref Collider2D col)
    {
        if (_shotLock)
            return;
        var blt = Instantiate(_bullet, _shootPoint.transform.position, _bullet.transform.rotation);
        Vector3 enemyPos = col.transform.position;
        Vector3 targetDist = (enemyPos - _shootPoint.transform.position).normalized;
        Debug.Log("Distance: " + (enemyPos - _shootPoint.transform.position));
        Rigidbody2D bltRgb = blt.GetComponent<Rigidbody2D>();
        bltRgb.AddForce((targetDist * _moveSpeed) * Time.deltaTime);
        Destroy(blt, 3);
        _shotLock = true;
        Invoke("ShotDelay", _shotDelaySec);
    }

    void ShotDelay()
    {
        _shotLock = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("tag_enemy"))
            ShotToTarget(ref other);
    }
}
