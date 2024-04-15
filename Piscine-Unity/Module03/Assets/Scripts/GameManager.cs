using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject _gamePauseMenuPanel;
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
        PauseGame();
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
        if(_baseCtrl._baseHP > 0)
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

    /*****************************************[ UI SECTION ]***********************************************/
    void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _gamePauseMenuPanel.SetActive(true);
        }
    }

    public void ContinueToGame()
    {
        Time.timeScale = 1;
        _gamePauseMenuPanel.SetActive(false);
    }

    public void ExitToGame()
    {
        for (int i = 0; i <= 3; i++)
            _gamePauseMenuPanel.transform.GetChild(i).gameObject.SetActive(false);
        _gamePauseMenuPanel.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void ExitSecondWindowNo()
    {
        for (int i = 0; i <= 3; i++)
            _gamePauseMenuPanel.transform.GetChild(i).gameObject.SetActive(true);
        _gamePauseMenuPanel.transform.GetChild(3).gameObject.SetActive(false);
    }

    public void ExitSecondWindowYes()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
