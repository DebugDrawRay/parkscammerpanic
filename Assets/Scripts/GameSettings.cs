using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public static int _highScore = 0;
    public static int HighScore
    {
        get
        {
            if (_highScore == 0)
            {
                _highScore = PlayerPrefs.GetInt("HighScore", 0);
            }
            return _highScore;
        }
        set
        {
            _highScore = value;
            PlayerPrefs.SetInt("HighScore", value);
        }
    }


    public static float ValueToMoney = 10.0f;

    //Level Escalation Stuff
    public static float TimeBetweenLevels = 30.0f;
    public static int CopNumberIncrement = 1;
    public static float CopSpeedIncrement = 0.5f;
    public static int CopMoneyIncrement = 2;

    private GameInfo _currentGame;

    private void Awake()
    {
        Instance = this;
    }

    public void NewGame()
    {
        _currentGame = new GameInfo();
    }

    public void AddMoney(float money)
    {
        if (_currentGame != null)
        {
            _currentGame.MoneyEarned += money;
        }
    }
}

public class GameInfo
{
    public float MoneyEarned = 0;
    
    //Items Sold
    //Highest Price Sold
}
