using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateOptions(Word[] newWords)
    {
        Debug.LogWarning("YOU'VE HIT A STUB! YOU NEED TO CODE THIS STILL YOU SILLY GOOSE");
    }
}
