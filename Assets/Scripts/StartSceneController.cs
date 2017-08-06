using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public InputField LevelInput;
    public int MaxLevel = 1;

    public void StartGame()
    {
        int randomLevel = Random.Range(1, MaxLevel + 1);
        StartGameAtLevel(randomLevel);
    }

    public void StartGameAtLevelButton()
    {
        if (LevelInput.text != null)
        {
            int level = System.Convert.ToInt32(LevelInput.text);
            StartGameAtLevel(level);
        }
    }

    private void StartGameAtLevel(int level)
    {
        SceneManager.LoadScene("Level" + level.ToString());
    }
}
