using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene currentScene;
    [SerializeField] private GameObject[] _chars = new GameObject[3];

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();    
    }

    void Update()
    {
        ResetStage();    
    }

    void ResetStage()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
            SceneManager.LoadScene(currentScene.name);
        if(!_chars[0] || !_chars[1] || !_chars[2])
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
