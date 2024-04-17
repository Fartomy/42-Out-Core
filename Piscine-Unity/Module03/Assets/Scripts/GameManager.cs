using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject _gamePauseMenuPanel;
    private List<GameObject[]> _foregroundObjs;
    private BaseController _baseCtrl;
    private SpawnerController _spawnerCtrl;
    private int _totalEnemiesNumber;
    
    private int _isWinningOrLosing = 2;

    public float energyReserve;
    [HideInInspector]
    public int _deadOfEnemyNbr = 0;

    void Awake()
    {
        _spawnerCtrl = GameObject.FindGameObjectWithTag("tag_spawner").GetComponent<SpawnerController>();
        _foregroundObjs = new List<GameObject[]>();
        _baseCtrl = GameObject.FindGameObjectWithTag("tag_base").GetComponent<BaseController>();
        _totalEnemiesNumber = _spawnerCtrl._numberOfSpawn;
    }

    void Start()
    {
        InvokeRepeating("EnergyReserveRegenaration", 0, 1);
    }

    void Update()
    {
        BaseHPControl();
        PauseGame();
        AreEnemiesDeadAll();
    }

    void BaseHPControl()
    {
        if (_baseCtrl._baseHP <= 0 && _baseCtrl)
        {
            FindAndDestroyForegroundObjects();
            _isWinningOrLosing = 0;
            ScoreCalculator();
            RankCalculator();
            PlayerPrefs.SetInt("WinningOrLosing", _isWinningOrLosing);
            PlayerPrefs.SetInt("SceneNumber", SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Game Over");
            SceneManager.LoadScene("Score");
        }
    }

    void EnergyReserveRegenaration()
    {
        if(_isWinningOrLosing == 2)
            energyReserve += 0.1f;
    }

    void AreEnemiesDeadAll()
    {
        if(_totalEnemiesNumber == _deadOfEnemyNbr)
        {
            _totalEnemiesNumber = 9999;
            FindAndDestroyForegroundObjects();
            _isWinningOrLosing = 1;
            ScoreCalculator();
            RankCalculator();
            PlayerPrefs.SetInt("WinningOrLosing", _isWinningOrLosing);
            PlayerPrefs.SetInt("SceneNumber", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Score");
        }
    }

    void ScoreCalculator()
    {
        if(energyReserve > 0)
            PlayerPrefs.SetFloat("Score" , (energyReserve + _baseCtrl._baseHP) - (Time.time / 10.0f));
        else
            PlayerPrefs.SetFloat("Score", _baseCtrl._baseHP - (Time.time / 10.0f));
    }

    void RankCalculator()
    {
        PlayerPrefs.SetInt("Rank", Convert.ToInt32(energyReserve + _baseCtrl._baseHP));
        if(PlayerPrefs.GetInt("Rank") < 50)
        {
            PlayerPrefs.SetString("RankLetter", "F");
            PlayerPrefs.SetString("RankTitle", "The Woodendome");
        }
        else if(PlayerPrefs.GetInt("Rank")  >= 50 && PlayerPrefs.GetInt("Rank") < 100)
        {
            PlayerPrefs.SetString("RankLetter", "B");
            PlayerPrefs.SetString("RankTitle", "The Gatekeeper");
        }
        else
        {
            PlayerPrefs.SetString("RankLetter", "S");
            PlayerPrefs.SetString("RankTitle", "The Shield of Welkin");
        }
    }

    void FindAndDestroyForegroundObjects()
    {
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_base"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_spawner"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_turret_01"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_turret_02"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_turret_03"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_01_bullet"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_02_bullet"));
        _foregroundObjs.Add(GameObject.FindGameObjectsWithTag("tag_03_bullet"));

        for(int i = 0; i < _foregroundObjs.Count; i++)
        {
            for(int j = 0; j < _foregroundObjs[i].Length; j++)
                Destroy(_foregroundObjs[i][j]);
        }
    }

    /*****************************************[ Pause Menu UI SECTION ]***********************************************/
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
