using UnityEngine;

public class LeafController : MonoBehaviour
{
    [SerializeField] private AudioClip _leafTakingClip;
    public static int nextID = 0;
    public static int leafsNumber;
    [SerializeField] private int ID;

    void Awake()
    {
        /*  We used "Resources" because we should find active and inactive objects.
            Also we use "- 1" because this function also counts this component (LeafController) since it exists in the prefab, 
            which is not on the stage.
        */
        leafsNumber = Resources.FindObjectsOfTypeAll<LeafController>().Length - 1;
        ID = nextID++;
        if(PlayerPrefs.HasKey(ID + "Leaf"))
        {
            if(PlayerPrefs.GetInt(ID + "Leaf") == 1)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
        else
            PlayerPrefs.SetInt(ID + "Leaf", 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.LeafPoint += 5;
            GameManager.Instance.LeafPointPool += 5;
            PlayerPrefs.SetInt(ID + "Leaf", 1);
            GameManager.Instance.Save();
            AudioManager.Instance.PlayAudioClip(_leafTakingClip, transform, 1);
            gameObject.SetActive(false);
        }
    }
}
