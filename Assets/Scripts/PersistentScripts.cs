using UnityEngine;

[RequireComponent(typeof(GameSettings))]
public class PersistentScripts : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
