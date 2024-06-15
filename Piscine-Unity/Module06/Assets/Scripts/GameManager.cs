using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if(JohnController.Instance._isFaint)
            StartCoroutine(RestartStage());
        if(UIManager.isWon)
            StartCoroutine(WonStage());
    }

    IEnumerator RestartStage()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator WonStage()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("Back to Main Menu");
    }
}
