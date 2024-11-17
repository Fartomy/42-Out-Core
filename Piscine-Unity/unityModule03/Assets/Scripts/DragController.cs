using UnityEngine;

public class DragController : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] _Tourets = new GameObject[3];
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;
    private Vector3 _initialPosition;
    private GameObject _TouretSquareAround;
    private GameManager _gameManager;

    public string touretTagName;
    

    void Awake()
    {
        _TouretSquareAround = this.transform.GetChild(0).gameObject;
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1)
            Destroy(gameObject);
    }

    void Update()
    {
        if(_isDragActive)
        {
            if(Input.GetMouseButtonUp(0))
            {
                Drop();
                return;
            }
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else
            return;

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if(_isDragActive)
            Drag();
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    _lastDragged = draggable;
                    touretTagName = draggable.transform.tag;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        _initialPosition = _lastDragged.transform.position;
        _TouretSquareAround.SetActive(true);
        _isDragActive = true;
    }

    void Drag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    void Drop()
    {
        if(_lastDragged.isOverTheSlot)
        {
            if(_lastDragged.DraggableTouretTagName == "tag_draggable_touret_01" && _gameManager.energyReserve >= 10f)
            {
                _gameManager.energyReserve -= 10.3f;
                Instantiate(_Tourets[0], _lastDragged.slotPosition, Quaternion.identity);
                Destroy(_lastDragged._TouretSquareAround);
            }
            else if(_lastDragged.DraggableTouretTagName == "tag_draggable_touret_02" && _gameManager.energyReserve >= 25f)
            {
                _gameManager.energyReserve -= 25.6f;
                Instantiate(_Tourets[1], _lastDragged.slotPosition, Quaternion.identity);
                Destroy(_lastDragged._TouretSquareAround);
            }
            else if(_lastDragged.DraggableTouretTagName == "tag_draggable_touret_03" && _gameManager.energyReserve >= 40f)
            {
                _gameManager.energyReserve -= 40.7f;
                Instantiate(_Tourets[2], _lastDragged.slotPosition, Quaternion.identity);
                Destroy(_lastDragged._TouretSquareAround);
            }
        }
        _isDragActive = false;
        _lastDragged.transform.position = _initialPosition;
        _TouretSquareAround.SetActive(false);
    }
}
