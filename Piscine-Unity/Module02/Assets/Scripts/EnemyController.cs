using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private int _spawnerChildCnt;
    private GameObject _spawner;
    private Transform[] _points;
    private int _indexOfPoints = 0;

    void Awake()
    {
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
}
