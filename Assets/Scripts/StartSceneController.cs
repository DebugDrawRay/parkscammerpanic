using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(Scenes.Game.ToString());
    }
}
