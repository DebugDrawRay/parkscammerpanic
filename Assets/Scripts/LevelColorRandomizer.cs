﻿using UnityEngine;
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
            if (meshRenderers[i].sharedMaterial == WindowsDoorsMaterial)
            {
                int colorRandom = Random.Range(0, WindowsDoorsColors.Length);
                Color color = WindowsDoorsColors[colorRandom];
                meshRenderers[i].material.SetColor("_EmissionColor", color);
            }

            if (meshRenderers[i].sharedMaterial == BillboardsMaterial)
            {
                int colorRandom = Random.Range(0, BillboardColors.Length);
                Color color = BillboardColors[colorRandom];
                meshRenderers[i].material.SetColor("BG_Color", color);
            }
        }
    }
}
