using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    
    public Animator _panelAnim;
}
