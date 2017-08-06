using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelColorRandomizer : MonoBehaviour
{
    public Material WindowsDoorsMaterial;
    public Material BillboardsMaterial;

    public Color[] WindowsDoorsColors;
    public Color[] BillboardColors;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        MeshRenderer[] meshRenderers = (MeshRenderer[])FindObjectsOfType<MeshRenderer>();
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            for (int m = 0; m < meshRenderers[i].sharedMaterials.Length; m++)
            {
                if (meshRenderers[i].materials[m].name.Contains(WindowsDoorsMaterial.name))
                {
                    int colorRandom = Random.Range(0, WindowsDoorsColors.Length);
                    Color color = WindowsDoorsColors[colorRandom];
                    meshRenderers[i].materials[m].SetColor("_EmissionColor", color);
                }
                else if (meshRenderers[i].materials[m].name.Contains(BillboardsMaterial.name))
                {
                    int colorRandom = Random.Range(0, BillboardColors.Length);
                    Color color = BillboardColors[colorRandom];
                    meshRenderers[i].materials[m].SetColor("_BG_Color", color);
                }
            }
        }
    }
}
