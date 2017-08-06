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

        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }
}
