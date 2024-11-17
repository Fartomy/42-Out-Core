using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _audioObject;

    void Awake()
    {
        if( Instance == null )
            Instance = this;
    }

    public void PlayAudioClip(AudioClip audioClip, Transform spawnPosition, float volume)
    {
        AudioSource audioSource = Instantiate(_audioObject, spawnPosition.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}