using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    private List<GameObject[]> _foregroundObjs;
    private BaseController _baseCtrl;

    public float energyReserve;

    void Awake()
    {
        _foregroundObjs = new List<GameObject[]>();
        _baseCtrl = GameObject.FindGameObjectWithTag("tag_base").GetComponent<BaseController>();
    }

    void Start()
    {
        InvokeRepeating("EnergyReserveRegenaration", 0, 1);
    }

    void Update()
    {
        BaseHPControl();
    }

    void BaseHPControl()
    {
        if (_baseCtrl._baseHP <= 0 && _baseCtrl)
        {
            FindAndDestroyForegroundObjects();
            Debug.Log("Game Over");
        }
    }

    void EnergyReserveRegenaration()
    {
        energyReserve += 0.1f;
    }

    void FindAndDestroyForegroundObjects()
    {
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_base"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_spawner"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_turret_01"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_turret_02"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_turret_03"));

        for(int i = 0; i < _foregroundObjs.Count; i++)
        {
            for(int j = 0; j < _foregroundObjs[i].Length; j++)
                Destroy(_foregroundObjs[i][j]);
        }
    }
}
