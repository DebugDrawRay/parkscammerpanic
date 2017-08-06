using UnityEngine;

[RequireComponent(typeof(GameSettings))]
[RequireComponent(typeof(LevelColorRandomizer))]
public class PersistentScripts : MonoBehaviour
{
    private static PersistentScripts instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
