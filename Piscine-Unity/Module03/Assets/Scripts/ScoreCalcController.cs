using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class ScoreCalcController : MonoBehaviour
{
    [SerializeField]
    private GameObject _endOfTheMapScren;

    void Start()
    {
        if(PlayerPrefs.GetInt("WinningOrLosing") == 1)
            WinningScreen();
        else
            LosingScreen();
    }

    void WinningScreen()
    {
        if(PlayerPrefs.GetInt("WinningOrLosing") == 1)
        {
            _endOfTheMapScren.SetActive(true);
            _endOfTheMapScren.GetComponent<UnityEngine.UI.Image>().color = new Color(0f, 0f, 1f, 100f / 255f);
            _endOfTheMapScren.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "you are win!";
            _endOfTheMapScren.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.yellow;
            _endOfTheMapScren.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text =
            "Score" + "\n" + PlayerPrefs.GetFloat("Score").ToString("F" + 1);
            _endOfTheMapScren.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text 
            = "The Rank: " + "'" + PlayerPrefs.GetString("RankLetter") + "'" + "\n" + "\"" + PlayerPrefs.GetString("RankTitle") + "\"";
            _endOfTheMapScren.transform.GetChild(4).gameObject.SetActive(true);
        }
    }

    void LosingScreen()
    {
        if(PlayerPrefs.GetInt("WinningOrLosing") == 0)
        {
            _endOfTheMapScren.SetActive(true);
            _endOfTheMapScren.GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 0f, 0f, 100f / 255f);
            _endOfTheMapScren.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "you are lose";
            _endOfTheMapScren.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
            _endOfTheMapScren.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = 
            "Score" + "\n" + PlayerPrefs.GetFloat("Score").ToString("F" + 1);
            _endOfTheMapScren.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text 
            = "The Rank: " + "'" + PlayerPrefs.GetString("RankLetter") + "'" + "\n" + "\"" + PlayerPrefs.GetString("RankTitle") + "\"";
            _endOfTheMapScren.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneNumber"));
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneNumber") + 1);
    }
}
