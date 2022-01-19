using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class PerlinWaveY : PerlinWave3D
{
    protected override void CalculationMethod(int i, int j) {
        if (waves)
        {
            vertices[i].y = Mathf.PerlinNoise(
                Time.time / waveSpeed +
                (vertices[i].x + transform.position.x) / detailScale,
                Time.time / waveSpeed +
                (vertices[i].z + transform.position.z) / detailScale) * heightScale;

        }
        else if (!waves)
        {
            vertices[i].y = Mathf.PerlinNoise(
                (vertices[i].x + transform.position.x) / detailScale,
                (vertices[i].z + transform.position.z) / detailScale) * heightScale;

        }
        // vertices[i].y -= j;
    }
}
