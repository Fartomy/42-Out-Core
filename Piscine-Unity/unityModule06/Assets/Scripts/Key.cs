using UnityEngine;

public class Key : MonoBehaviour
{
    public static int nextID = 0;
    [SerializeField] private AudioClip _collectKeyAudioClip;
    [SerializeField] private int ID;

    void Awake()
    {
        ID = nextID++;
        if(PlayerPrefs.HasKey(ID + "Key"))
        {
            if(PlayerPrefs.GetInt(ID + "Key") == 1)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
        else
            PlayerPrefs.SetInt(ID + "Key", 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.keyCounter++;
            UIManager.Instance.ChangeKeyStatus();
            PlayerPrefs.SetInt(ID + "Key", 1);
            GameManager.Instance.Save();
            AudioManager.Instance.PlayAudioClip(_collectKeyAudioClip, transform, 1);
            gameObject.SetActive(false);
        }
    }
}
