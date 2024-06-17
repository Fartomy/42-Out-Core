using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private AudioClip[] _audioClips = new AudioClip[2];

    void Awake()
    {
        if(Instance == null)
            Instance = this;    
    }

    public IEnumerator RestartStage()
    {
        AudioManager.Instance.PlayAudioClip(_audioClips[0], transform, 1);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator WonStage()
    {
        AudioManager.Instance.PlayAudioClip(_audioClips[1], transform, 1);
        yield return new WaitForSeconds(4);
        Debug.Log("Back to Main Menu");
    }
}
