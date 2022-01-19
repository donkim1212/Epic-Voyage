using UnityEngine;

public class PerlinWave2D : MonoBehaviour
{
    [Range(0.1f, 20.0f)]
    public float heightScale = 5.0f;
    [Range(0.1f, 20.0f)]
    public float detailScale = 5.0f;
    public float waveSpeed = 5.0f;
    public int width = 5;
    public bool isNegative = true;

    protected EdgeCollider2D myCollider;
    protected Vector2[] vertices;
    
    void Awake() {
        myCollider = GetComponent<EdgeCollider2D>();
        vertices = new Vector2[width + 1];
        for (int i = 0; i <= width; i++) {
            vertices[i] = new Vector2(
                (isNegative ? -i : i),
                0
            );
            // Debug.Log("i = " + vertices[i]);
        }
        
        myCollider.points = vertices;
    }

    void FixedUpdate() {
        GenerateWave();
    }

    protected void GenerateWave() {
        vertices = myCollider.points;

        int counter = 0;
        for (int i = 0; i <= width; i++) {
            CalculationMethod(counter);
            counter++;
        }

        myCollider.points = vertices;
    }

    private void CalculationMethod (int i) {
        vertices[i].y = Mathf.PerlinNoise(
            Time.time / waveSpeed + (vertices[i].x + transform.position.x) / detailScale,
            Time.time / waveSpeed + (vertices[i].y + transform.position.y) / detailScale
        ) * heightScale;
        // Debug.Log("i = " + vertices[i]);
    }
}
