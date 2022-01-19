using UnityEngine;

public abstract class PerlinWave : MonoBehaviour
{
    [Range(0.1f, 20.0f)]
    public float heightScale = 5.0f;
    [Range(0.1f, 40.0f)]
    public float detailScale = 5.0f;

    // protected Mesh myMesh;
    // protected MeshCollider myCollider;
    // protected Vector3[] vertices;

    public bool waves = false;
    public float waveSpeed = 5.0f;
    public bool collider_on;

    protected void Update()
    {
        GenerateWave();
    }

    protected abstract void GenerateWave();

    protected abstract void CalculationMethod(int i, int j);
}
