using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool isOverTheSlot = false;
    public Vector3 slotPosition;
    public string DraggableTouretTagName;
    public GameObject _TouretSquareAround;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("tag_square_around"))
        {
            isOverTheSlot = true;
            slotPosition = other.transform.position;
            DraggableTouretTagName = transform.tag;
            _TouretSquareAround = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("tag_square_around"))
            isOverTheSlot = false;
    }
}
