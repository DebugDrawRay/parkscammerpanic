using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject OptionsPanel;
    public GameObject GameOverPanel;
    public GameObject StartScreenPanel;
    public GameObject[] Options;
    public Text CurrentTransactionScore;
    public Text TotalScore;

    private bool _hidden = true;
    private Text[] _optionButtonTexts;

    private void Awake()
    {
        Instance = this;
        
        _optionButtonTexts = new Text[Options.Length];
        for (int i = 0; i < Options.Length; i++)
        {
            _optionButtonTexts[i] = Options[i].GetComponentInChildren<Text>();
        }
        TotalScore.text = "$0.00";
    }

    public void UpdateScore(float score)
    {
        score = Mathf.Clamp(score, 0, Mathf.Infinity);
        TotalScore.text = "$" + (score * GameSettings.ValueToMoney).ToString()+".00";
        UpdateTransactionScore(0, 0);
    }

    public void UpdateTransactionScore(float score, float mod)
    {
        CurrentTransactionScore.text = score.ToString() + " (" + mod + ")";
    }

    public void UpdateOptions(int[] newWords)
    {
        if (_hidden)
        {
            _hidden = false;
            OptionsPanel.SetActive(true);
        }

        for (int i = 0; i < newWords.Length; i++)
        {
            _optionButtonTexts[i].text = WordDatabase.GetWordText(newWords[i]);
        }
    }

    public void HideOptions()
    {
        _hidden = true;
        OptionsPanel.SetActive(false);
    }

    public void HideStartScreen()
    {
        GameManager.Instance.StartGame();
        StartScreenPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }

    public void OnOptionClick(int optionId)
    {
        TransactionManager.Instance.ChooseOption(optionId);
    }

    public void OnReturnToMainMenuClick()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
