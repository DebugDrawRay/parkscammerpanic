using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Mesh[] ItemMeshes;
    private MeshFilter _meshFilter;

    private void Awake()
    {
        _meshFilter = GetComponentInChildren<MeshFilter>();
        int meshIndex = Random.Range(0, ItemMeshes.Length);
        _meshFilter.mesh = ItemMeshes[meshIndex];
    }
}
