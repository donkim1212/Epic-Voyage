using UnityEngine;

public class BasicSpawner : ISpawner
{
    private GameObject[] spawner;
    private bool occupied = false;

    public void SetSpawnerPosition (Vector3[] pos, bool isFront) {
        GameObject spawners = new GameObject("Spawners " + (isFront ? "front" : "back"));
        // spawners.transform.position = Vector3.zero;
        
        spawner = new GameObject[pos.Length];
        for (int i = 0; i < pos.Length; i++) {
            spawner[i] = new GameObject("Spawner " + i);
            spawner[i].transform.parent = spawners.transform;
            spawner[i].transform.position = pos[i];
            // spawner[i].transform.localScale = new Vector3(1,1,1);
        }
        
        if (!isFront) spawners.transform.localScale = new Vector3(0.8f, 0.8f, 1);
    }

    public void Spawn() {
        // 
    }

    public void Despawn () {
        
    }
}
