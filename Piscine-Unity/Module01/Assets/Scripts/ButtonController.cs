using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private GameObject _parentObject;
    private GameObject _door;
    private GameObject _openedDoorPoint;
    private Renderer _switchRndr;
    private Renderer _doorRndr;
    private bool _isWhiteButton;
    private bool _isColorButton;
    private bool _isPltfClrChangerBtn;

    void Awake()
    {
        _switchRndr = transform.GetComponent<Renderer>();
        _parentObject = transform.parent.gameObject;
        _door = _parentObject.transform.Find("Door").gameObject;
        _doorRndr = _door.GetComponent<Renderer>();
        _openedDoorPoint = _door.transform.Find("openedDoorPoint").gameObject;
        ButtonType();
    }

    void ButtonType()
    {
        if(_parentObject.transform.tag == "whiteButton")
            _isWhiteButton = true;
        else if(_parentObject.transform.tag == "colorButton")
            _isColorButton = true;
        else if(_parentObject.transform.tag == "platformColorChangerButton")
        {
            _isPltfClrChangerBtn = true;
            _openedDoorPoint = null;
        }
    }

    void WhiteButton(ref Collision col)
    {
        string layerName = LayerMask.LayerToName(_door.layer);

        if(col.gameObject.tag == "Thomas" && layerName == "Red")
        {
            _door.transform.position = _openedDoorPoint.transform.position;
            _isWhiteButton = false;
            ChangeColor(ref _switchRndr, Color.green);
        }
        else if(col.gameObject.tag == "John" && layerName == "Yellow")
        {
            _door.transform.position = _openedDoorPoint.transform.position;
            _isWhiteButton = false;
            ChangeColor(ref _switchRndr, Color.green);
        }
        else if(col.gameObject.tag == "Claire" && layerName == "Blue")
        {
            _door.transform.position = _openedDoorPoint.transform.position;
            _isWhiteButton = false;
            ChangeColor(ref _switchRndr, Color.green);
        }
    }

    void ColorButton(ref Collision col)
    {
        string layerName = LayerMask.LayerToName(transform.gameObject.layer);

        if(col.gameObject.tag == "Thomas" && layerName == "Red")
        {
            _door.transform.position = _openedDoorPoint.transform.position;
            _isColorButton = false;
            ChangeColor(ref _switchRndr, Color.green);
        }
        else if(col.gameObject.tag == "John" && layerName == "Yellow")
        {
            _door.transform.position = _openedDoorPoint.transform.position;
            _isColorButton = false;
            ChangeColor(ref _switchRndr, Color.green);
        }
        else if(col.gameObject.tag == "Claire" && layerName == "Blue")
        {
            _door.transform.position = _openedDoorPoint.transform.position;
            _isColorButton = false;
            ChangeColor(ref _switchRndr, Color.green);
        }
    }

    void PlatformColorChangerButton(ref Collision col)
    {
        ChangeColor(ref _switchRndr, Color.green);
        if(col.gameObject.tag == "Thomas")
        {
            _door.layer = LayerMask.NameToLayer("Red");
            ChangeColor(ref _doorRndr, Color.red);
            _isPltfClrChangerBtn = false;
        }
        else if(col.gameObject.tag == "John")
        {
            _door.layer = LayerMask.NameToLayer("Yellow");
            ChangeColor(ref _doorRndr, Color.yellow);
            _isPltfClrChangerBtn = false;
        }
        else if(col.gameObject.tag == "Claire")
        {
            _door.layer = LayerMask.NameToLayer("Blue");
            ChangeColor(ref _doorRndr, Color.blue);
            _isPltfClrChangerBtn = false;
        }
    }

    void OnDrawGizmos()
    {
        if(_door != null)
            Gizmos.DrawLine(_door.transform.position, transform.position);
    }
    
    void ChangeColor(ref Renderer obj, Color newClr)
    {
        Material newMat = new Material(obj.sharedMaterial);
        newMat.color = newClr;
        obj.material = newMat; 
    }

    void OnCollisionEnter(Collision other)
    {
        if(_isWhiteButton)
            WhiteButton(ref other);
        if(_isColorButton)
            ColorButton(ref other);
        if(_isPltfClrChangerBtn)
            PlatformColorChangerButton(ref other);
    }
}
