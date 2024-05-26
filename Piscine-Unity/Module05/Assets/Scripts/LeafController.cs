using UnityEngine;

public class LeafController : MonoBehaviour
{
    [SerializeField] private AudioClip _leafTakingClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.CollecttedLeafs++;
            GameManager.Instance.LeafPoint += 5;
            GameManager.Instance.LeafPointPool += 5;
            GameManager.Instance.Save();
            AudioManager.Instance.PlayAudioClip(_leafTakingClip, transform, 1);
            gameObject.SetActive(false);
        }
    }
}
