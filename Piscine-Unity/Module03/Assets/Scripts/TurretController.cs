using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;

    [Header("Properties")]
    [SerializeField] private float _detectionZoneRadius;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _shotDelaySec;

    private Collider2D _closestEnemy;

    void Start()
    {
        InvokeRepeating("ShootToEnemy", 0, _shotDelaySec);
    }

    void FixedUpdate()
    {
        FindClosestEnemy();
    }

    void ShootToEnemy()
    {
        if (_closestEnemy)
        {
            GameObject blt = Instantiate(_bullet, _shootPoint.transform.position, _bullet.transform.rotation);
            TagToBullet(ref blt);
            Rigidbody2D bltRgb = blt.GetComponent<Rigidbody2D>();
            Vector2 targetDist = _closestEnemy.transform.position - transform.position;
            bltRgb.AddForce(targetDist * _moveSpeed * Time.deltaTime);
            Destroy(blt, 2);
        }
    }

    void TagToBullet(ref GameObject blt)
    {
        if(transform.tag == "tag_turret_01")
            blt.tag = "tag_01_bullet";
        else if(transform.tag == "tag_turret_02")
            blt.tag = "tag_02_bullet";
        else if(transform.tag == "tag_turret_03")
            blt.tag = "tag_03_bullet";
    }

    void FindClosestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _detectionZoneRadius, LayerMask.GetMask("Enemy"));
        if (enemies.Length > 0)
        {
            float mindist = Mathf.Infinity;
            foreach (Collider2D enemy in enemies)
            {
                float dist = Vector2.Distance(enemy.transform.position, transform.position);
                if (dist < mindist)
                {
                    mindist = dist;
                    _closestEnemy = enemy;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (gameObject)
            Gizmos.DrawWireSphere(transform.position, _detectionZoneRadius);
    }
}
