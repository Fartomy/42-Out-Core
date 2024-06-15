using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _wonImage;
    [SerializeField] private GameObject _caughtImage;
    [SerializeField] private GameObject _faintImage;

    [HideInInspector] public static bool isCaught = false;
    [HideInInspector] public static bool isWon = false;

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
