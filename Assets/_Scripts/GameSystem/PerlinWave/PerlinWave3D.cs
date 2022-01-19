using UnityEngine;

public abstract class PerlinWave3D : PerlinWave
{
    protected Mesh myMesh;
    protected MeshCollider myCollider;
    protected Vector3[] vertices;
    // Start is called before the first frame update
    private void Awake() {
        myMesh = this.GetComponent<MeshFilter>().mesh;
        myCollider = GetComponent<MeshCollider>();
    }

    protected override void GenerateWave() {
        vertices = myMesh.vertices;

        int counter = 0; // i
        int yLevel = 0; // j
        
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                CalculationMethod(counter, yLevel);
                counter++;
            }
            yLevel++;
        }

        myMesh.vertices = vertices;
        myMesh.RecalculateBounds();
        myMesh.RecalculateNormals();

        if (collider_on) {
            myCollider.sharedMesh = null;
            myCollider.sharedMesh = myMesh;
        }
        else {
            Destroy(gameObject.GetComponent<MeshCollider>());
        }

    }
}
