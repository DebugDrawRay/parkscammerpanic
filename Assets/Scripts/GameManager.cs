using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

	public void AddToScore(float score)
    {
        _score += score;
        UIManager.Instance.UpdateScore(_score);
    }
}
