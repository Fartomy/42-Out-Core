using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject _wonImage;
    [SerializeField] private GameObject _caughtImage;
    [SerializeField] private GameObject _faintImage;

    [HideInInspector] public bool isCaught = false;
    [HideInInspector] public bool isWon = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        if (isWon)
        {
            isWon = false;
            _wonImage.SetActive(true);
            _faintImage.SetActive(true);
        }
        if (isCaught)
        {
            isCaught = false;
            _caughtImage.SetActive(true);
            _faintImage.SetActive(true);
        }
    }
}
