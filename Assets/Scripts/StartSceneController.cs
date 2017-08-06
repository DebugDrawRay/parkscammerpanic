using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartSceneController : MonoBehaviour
{
    [Header("Main Screens")]
    public RectTransform StartScreen;
    public RectTransform LevelSelectScreen;

    [Header("Level Select")]
    public LevelSelection[] LevelSelections;
    public RectTransform LevelDisplay;
    public Text LevelNameText;
    public Image LevelDisplayImage;

    private int _selectedLevel = 0;

    private int _offscreen = 2000;
    private float _scrollSpeed = 0.6f;

    private void Start()
    {
        UpdateLevelDisplay();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(LevelSelections[_selectedLevel].SceneName);
    }

    public void ShowLevelSelect()
    {
        StartScreen.DOAnchorPos(new Vector3(-_offscreen, 0, 0), _scrollSpeed / 2f).SetEase(Ease.OutBounce);
        LevelSelectScreen.DOAnchorPos(new Vector3(0, 0, 0), _scrollSpeed).SetEase(Ease.OutBounce);
    }

    public void NextLevel()
    {
        LevelDisplay.DOAnchorPos(new Vector3(-_offscreen, 0, 0), _scrollSpeed/2f).OnComplete(() => CompleteNextLevelMovement()).SetEase(Ease.InCubic);
    }

    public void CompleteNextLevelMovement()
    {
        _selectedLevel = _selectedLevel == LevelSelections.Length - 1 ? 0 : _selectedLevel + 1;
        UpdateLevelDisplay();

        LevelDisplay.anchoredPosition = new Vector3(_offscreen, 0, 0);
        LevelDisplay.DOAnchorPos(new Vector3(0, 0, 0), _scrollSpeed).SetEase(Ease.OutBounce);
    }

    public void PreviousLevel()
    {
        LevelDisplay.DOAnchorPos(new Vector3(_offscreen, 0, 0), _scrollSpeed/2f).OnComplete(() => CompletePreviousLevelMovement()).SetEase(Ease.InCubic);
    }

    public void CompletePreviousLevelMovement()
    {
        _selectedLevel = _selectedLevel == 0 ? LevelSelections.Length - 1 : _selectedLevel - 1;
        UpdateLevelDisplay();

        LevelDisplay.anchoredPosition = new Vector3(-_offscreen, 0, 0);
        LevelDisplay.DOAnchorPos(new Vector3(0, 0, 0), _scrollSpeed).SetEase(Ease.OutBounce);
    }

    public void UpdateLevelDisplay()
    {
        LevelNameText.text = LevelSelections[_selectedLevel].LevelName;
        LevelDisplayImage.sprite = LevelSelections[_selectedLevel].LevelImage;
    }

    [System.Serializable]
    public class LevelSelection
    {
        public Sprite LevelImage;
        public string LevelName;
        public string SceneName;
    }
}
