using UnityEngine;
using System.Collections;

public delegate void GameStateChangedHandler(GameState state);
public delegate void GameEscalateHandler();

public enum GameState { Paused, Playing }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public int AdditionalCops = 0;
    [HideInInspector]
    public float AdditionalCopSpeed = 2f;
    [HideInInspector]
    public int AdditionalCopMoney = 2;

    public static GameStateChangedHandler GameStateChanged;
    private GameState _currentState = GameState.Paused;
    public GameState CurrentState
    {
        get { return _currentState; }
        set
        {
            Debug.Log("Setting state to " + value.ToString());
            _currentState = value;
            if (GameStateChanged != null)
            {
                Debug.Log("Invoking Game State Change");
                GameStateChanged.Invoke(_currentState);
            }
        }
    }

    public static GameEscalateHandler GameEscalated;

    private int _score = 0;
    public int Score
    {
        get
        {
            return _score;
        }
    }

    private float _countdownToNextLevel;

    private void Awake()
    {
        Instance = this;
        _countdownToNextLevel = GameSettings.TimeBetweenLevels;
    }

    private void Start()
    {
        SpawnManager.Instance.InitializeLevel();
    }

    private void Update()
    {
        if (_currentState == GameState.Playing)
        {
            if (_countdownToNextLevel <= 0)
            {
                Debug.Log("ESCALATE");
                _countdownToNextLevel = GameSettings.TimeBetweenLevels;
                if (GameEscalated != null)
                {
                    AdditionalCops += GameSettings.CopNumberIncrement;
                    AdditionalCopMoney += GameSettings.CopMoneyIncrement;
                    AdditionalCopSpeed += GameSettings.CopSpeedIncrement;

                    GameEscalated.Invoke();
                }
            }
            else
            {
                _countdownToNextLevel -= Time.deltaTime;
            }
        }
    }

    public void AddToScore(int score)
    {
        _score += score;
        UIManager.Instance.UpdateScore(_score);
    }

    public void StartGame()
    {
        CurrentState = GameState.Playing;
    }

    public void GameOver()
    {
        CurrentState = GameState.Paused;

        if (Score > GameSettings.HighScore)
        {
            GameSettings.HighScore = Score;
        }

        UIManager.Instance.ShowGameOverPanel(Score, GameSettings.HighScore);
    }
}
