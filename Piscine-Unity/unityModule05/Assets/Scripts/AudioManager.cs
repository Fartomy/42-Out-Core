using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _audioSourceObj;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
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
