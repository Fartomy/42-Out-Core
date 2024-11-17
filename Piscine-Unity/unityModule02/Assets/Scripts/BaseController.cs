using UnityEngine;

public class BaseController : MonoBehaviour
{
    public int _baseHP;

    void Awake()
    {
        Debug.Log("Base HP: " + _baseHP);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("tag_enemy") && _baseHP > 0)
        {
            _baseHP--;
            Debug.Log("Base HP: " + _baseHP);
            Destroy(other.gameObject);
        }
    }
}
