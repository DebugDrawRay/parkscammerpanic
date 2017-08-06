using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void GameStateChangedHandler(GameState state);
public enum GameState { Paused, Playing }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    private float _score = 0;
    public float Score
    {
        get
        {
            return _score;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnManager.Instance.InitializeLevel();
        StartGame();
    }

    public void AddToScore(float score)
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
        UIManager.Instance.ShowGameOverPanel();
    }
}
