using UnityEngine;

public class LeafController : MonoBehaviour
{
    public static int nextIDCnt = 0;
    private bool _playerIsTouched = false;
    public int ID;

    void Awake()
    {
        ID = nextIDCnt++;
        if(GameManager.Instance._leafStatus.ContainsKey(ID))
            gameObject.SetActive(!GameManager.Instance._leafStatus[ID]);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            _playerIsTouched = true;
            GameManager.Instance.SetLeafStatus(ID, _playerIsTouched);
        }
    }
}
