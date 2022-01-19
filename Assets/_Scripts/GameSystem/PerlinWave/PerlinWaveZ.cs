using UnityEngine;

public class PerlinWaveZ : PerlinWave3D
{
    protected override void CalculationMethod(int i, int j)
    {
        if (waves)
        {
            vertices[i].z = Mathf.PerlinNoise(
                Time.time / waveSpeed +
                (vertices[i].x + transform.position.x) / detailScale,
                Time.time / waveSpeed +
                (vertices[i].y + transform.position.y) / detailScale) * heightScale;

        }
        else if (!waves)
        {
            vertices[i].z = Mathf.PerlinNoise(
                (vertices[i].x + transform.position.x) / detailScale,
                (vertices[i].y + transform.position.y) / detailScale) * heightScale;

        }
        vertices[i].z -= j;
    }

}
