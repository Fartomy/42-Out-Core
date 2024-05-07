using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceObj;
    public static AudioManager _instance;

    void Awake()
    {
        if(_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayAudioClip(AudioClip clip, Transform spawnTform, float vol)
    {
        AudioSource audioSrc = Instantiate(_audioSourceObj, spawnTform.position, Quaternion.identity);
        audioSrc.clip = clip;
        audioSrc.volume = vol;
        audioSrc.Play();
        float clipLength = audioSrc.clip.length;
        Destroy(audioSrc.gameObject, clipLength);
    }
}
