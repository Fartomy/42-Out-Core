using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private int _spawnerChildCnt;
    private GameObject _spawner;
    private Transform[] _points;
    private int _indexOfPoints = 0;
    private float _HP = 3f;
    private GameManager _gameManager;

    void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _spawnerChildCnt = GameObject.Find("Spawner").gameObject.transform.childCount;
        _spawner = GameObject.Find("Spawner");
        _points = new Transform[_spawnerChildCnt];
        GetPoints();
        transform.position = _points[_indexOfPoints].position;
    }

    void Update()
    {
        MoveToPoint();
        CheckPathIsThere();
        CheckHP();
    }

    void GetPoints()
    {
        for (int i = 0; i < _spawnerChildCnt; i++)
            _points[i] = _spawner.transform.GetChild(i);
    }

    void MoveToPoint()
    {
        if (_spawner)
        {

            if (_indexOfPoints <= _points.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, _points[_indexOfPoints].transform.position, _moveSpeed * Time.deltaTime);

                if (transform.position == _points[_indexOfPoints].transform.position)
                    _indexOfPoints++;
            }
        }
    }

    void CheckPathIsThere()
    {
        if(!_spawner)
            Destroy(gameObject);
    }

    void CheckHP()
    {
        if(_HP <= 0)
        {
            _gameManager.energyReserve += 5f;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("tag_01_bullet"))
        {
            _HP -= 0.1f;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("tag_02_bullet"))
        {
            _HP -= 0.2f;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("tag_03_bullet"))
        {
            _HP -= 0.3f;
            Destroy(other.gameObject);
        }
    }
}
