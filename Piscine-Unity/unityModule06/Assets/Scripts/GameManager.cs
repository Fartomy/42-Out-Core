using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private AudioClip[] _audioClips = new AudioClip[2];
    [HideInInspector] public int keyCounter = 0;

    void Awake()
    {
        if(Instance == null)
        {
            // PlayerPrefs.DeleteAll();
            Instance = this;    
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("KeyCounter", keyCounter);
    }

    public void Load()
    {
        keyCounter = PlayerPrefs.GetInt("KeyCounter");
    } 

    public IEnumerator RestartStage()
    {
        AudioManager.Instance.PlayAudioClip(_audioClips[0], transform, 1);
        yield return new WaitForSeconds(4);
        Key.nextID = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator WonStage()
    {
        AudioManager.Instance.PlayAudioClip(_audioClips[1], transform, 1);
        yield return new WaitForSeconds(4);
        Save();
        SceneManager.LoadScene(0);
    }
}
