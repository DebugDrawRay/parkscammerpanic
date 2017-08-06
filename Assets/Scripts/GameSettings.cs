using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

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
