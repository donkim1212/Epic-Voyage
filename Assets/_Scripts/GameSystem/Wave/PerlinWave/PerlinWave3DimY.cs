using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class PerlinWave3DimY : PerlinWave3Dim
{
    protected override void CalculationMethod(int i, int j) {
        if (waves)
        {
            vertices[i].y = Mathf.PerlinNoise(
                Time.time / wavelength + (vertices[i].x) / detailScale,
                (random_seed ? rnd : 0)) * amplitude;

        }
        else if (!waves)
        {
            vertices[i].y = Mathf.PerlinNoise(
                (vertices[i].x) / detailScale,
                (random_seed ? rnd : 0)) * amplitude;

        }
        // vertices[i].y -= j;
    }
}
