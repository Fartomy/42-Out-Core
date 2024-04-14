using UnityEngine;
using TMPro;

public class BarPanelController : MonoBehaviour
{
    private BaseController _baseCtrl;
    private GameManager _gameManager;
    private TextMeshPro _baseHPtext;
    private TextMeshPro _eneryReserveText;
    private DragController _dragCtrl;
    private GameObject _touretInfos;
    private GameObject _draggableTouret;

    void Awake()
    {
        _baseCtrl = GameObject.FindGameObjectWithTag("tag_base").GetComponent<BaseController>();
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _dragCtrl = GameObject.FindGameObjectWithTag("tag_drag_controller").GetComponent<DragController>();
        _baseHPtext = transform.GetChild(1).GetComponent<TextMeshPro>();
        _eneryReserveText = transform.GetChild(2).GetComponent<TextMeshPro>();
        _touretInfos = transform.GetChild(0).transform.GetChild(3).gameObject;
        _draggableTouret = transform.GetChild(0).gameObject;
    }

    void LateUpdate()
    {
        _baseHPtext.text = "base hp" + "\n" + _baseCtrl._baseHP;
        _eneryReserveText.text = "energy reserve" + "\n" + _gameManager.energyReserve.ToString("F" + 1);
        TouretInfos();
        IsEnoughEnergy();
    }

    void TouretInfos()
    {
        if(_dragCtrl.touretTagName != "")
        {
            if(_dragCtrl.touretTagName == "tag_draggable_touret_01")
            {
                _touretInfos.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Cost: " + "10€";
                _touretInfos.transform.GetChild(1).GetComponent<TextMeshPro>().text = "Damage: " + "0.1₯";
                _touretInfos.transform.GetChild(2).GetComponent<TextMeshPro>().text = "Cooldown: " + "0.3₵";
            }
            if(_dragCtrl.touretTagName == "tag_draggable_touret_02")
            {
                _touretInfos.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Cost: " + "25€";
                _touretInfos.transform.GetChild(1).GetComponent<TextMeshPro>().text = "Damage: " + "0.2₯";
                _touretInfos.transform.GetChild(2).GetComponent<TextMeshPro>().text = "Cooldown: " + "0.5₵";
            }
            if(_dragCtrl.touretTagName == "tag_draggable_touret_03")
            {
                _touretInfos.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Cost: " + "40€";
                _touretInfos.transform.GetChild(1).GetComponent<TextMeshPro>().text = "Damage: " + "0.3₯";
                _touretInfos.transform.GetChild(2).GetComponent<TextMeshPro>().text = "Cooldown: " + "0.1₵";
            }
        }
    }

    void IsEnoughEnergy()
    {
        if(_gameManager.energyReserve < 10f)
            _draggableTouret.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        else
            _draggableTouret.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        if(_gameManager.energyReserve < 25f)
            _draggableTouret.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.red;
        else
            _draggableTouret.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        if(_gameManager.energyReserve < 40f)
            _draggableTouret.transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.red;
        else
            _draggableTouret.transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.white;
    }
}
