using UnityEngine;

public class MeshGenerator
{
    /// <summary>
    /// Returns mesh with vertices sorted from left to right, from bottom to up.
    /// Its triangles are in clockwise.
    /// <value>width and height : integer greater than or equal to 1.</value>
    /// </summary>
    public static Mesh GeneratePlane(int width, int height, string name) {
        Mesh mesh = new Mesh();
        mesh.name = name;
        if (width <= 0 || height <= 0) return mesh;
        int v_count = (width + 1) * (height + 1);
        int t_count = width * height * 6;
        Vector3[] vertices = new Vector3[v_count];

        int row = 0, col = 0;
        for (int i = 0; i < v_count; i++) {
            vertices[i] = new Vector3(col++, 0 , row);
            if (col > width) {
                col = 0;
                row ++;
            }
        }

        int[] triangles = new int[t_count];
        col = 0; row = 1;
        int v_index = width + 1, t_index = 0;
        while (t_index < t_count) {
            for (int i = 0; i < width; i++) {
                // full rect (2 triangles)
                triangles[t_index++] = v_index; // current
                triangles[t_index++] = v_index - width; // +1 column, -1 row
                triangles[t_index++] = v_index - width - 1; // same column, -1 row
                triangles[t_index++] = v_index + 1; // +1 column, same row
                triangles[t_index++] = v_index - width; // +1 column -1 row
                triangles[t_index++] = v_index; // current
                v_index ++;
            }
            v_index++; // skip last index of a row
        }

        Vector2[] uvs = new Vector2[vertices.Length];
        for (int i = 0; i < uvs.Length; i++) {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        return mesh;
    }
}
