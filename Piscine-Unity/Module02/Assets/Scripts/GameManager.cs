using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject _base;
    [SerializeField] private GameObject _spawner;

    private BaseController _baseCtrl;

    void Awake()
    {
        _baseCtrl = _base.GetComponent<BaseController>();
    }

    void Update()
    {
        BaseHPControl();
    }

    void BaseHPControl()
    {
        if (_baseCtrl._baseHP <= 0 && _base)
        {
            Destroy(_base);
            Destroy(_spawner);
            Debug.Log("Game Over");
        }
    }
}
