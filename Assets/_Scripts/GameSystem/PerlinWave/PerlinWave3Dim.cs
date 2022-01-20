using UnityEngine;

public class PerlinWave3Dim : PerlinWave
{
    protected MeshFilter myFilter;
    protected Mesh myMesh;
    protected MeshCollider myCollider;
    protected Vector3[] vertices;
    // Start is called before the first frame update
    public bool custom_mesh_enabled = false;
    private bool cme_fixed;
    [Range(1, 30)]
    public int initial_mesh_width = 1;
    [Range(1, 10)]
    public int initial_mesh_height = 1;
    private void Awake() {
        rnd = Random.Range(0f, 100f);
        myFilter = GetComponent<MeshFilter>();
        myCollider = GetComponent<MeshCollider>();
        cme_fixed = custom_mesh_enabled;
        if (!cme_fixed) {
            initial_mesh_width = 10;
            initial_mesh_height = 10;
        }
        if (cme_fixed) {
            myMesh = MeshGenerator.GeneratePlane(initial_mesh_width, initial_mesh_height, "wave");
            myFilter.mesh = myMesh;
            myCollider.sharedMesh = myMesh;
        } else {
            myMesh = myFilter.mesh;
        }
    }

    protected override void GenerateWave() {
        vertices = myMesh.vertices;

        int counter = 0; // i
        int yLevel = 0; // j
        
        for (int i = 0; i < initial_mesh_height + 1; i++)
        {
            for (int j = 0; j < initial_mesh_width + 1; j++)
            {
                CalculationMethod(counter, yLevel);
                counter++;
            }
            yLevel++;
        }

        myMesh.vertices = vertices;
        myMesh.RecalculateBounds();
        myMesh.RecalculateNormals();
        if (cme_fixed) myFilter.mesh = myMesh;
        if (collider_on) {
            
            myCollider.sharedMesh = myMesh;
        }
        else {
            myCollider.sharedMesh = null;
        }

    }

    protected override void CalculationMethod(int i, int j)
    {
        if (waves)
        {
            vertices[i].z = Mathf.PerlinNoise(
                Time.time / wavelength + (vertices[i].x) / detailScale,
                (random_seed ? rnd : 0)
            ) * amplitude;

        }
        else if (!waves)
        {
            vertices[i].z = Mathf.PerlinNoise(
                (vertices[i].x) / detailScale,
                (random_seed ? rnd : 0)
            ) * amplitude;

        }
        vertices[i].z += cme_fixed ? j : -j;
    }

}
