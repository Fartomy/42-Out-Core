using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTheGameScreenController : MonoBehaviour
{
    public void Review()
    {
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(true);
    }
    public void BackToHome()
    {
        SceneManager.LoadScene(0);
    }
}
