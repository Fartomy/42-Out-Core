using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene currentScene;

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
    }
}
