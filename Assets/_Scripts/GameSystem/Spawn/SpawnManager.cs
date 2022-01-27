using System;
using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private enum SpawnerSortingMethod {
        LeftToRight, RightToLeft, CenterRightLeft
    }
    [SerializeField]
    private SpawnerSortingMethod method = SpawnerSortingMethod.LeftToRight;
    private Vector3[] front_spawns;

    private ISpawner front_spawner;
    private Vector3[] back_spawns;
    private ISpawner back_spawner;
    [SerializeField]
    private int spawn_count = 3;
    [SerializeField]
    private Vector3 origin = new Vector3(0f, 1f, 0f);
    [SerializeField]
    private Vector3 offset = new Vector3(4f, 0.2f, 0f);
    
    void Awake() {
        // spawn_positions = new Vector3[spawn_count];
        // InitSpawnPositions();
        front_spawns = SortSpawn(SetSpawnVector(true));
        front_spawner = new BasicSpawner();
        front_spawner.SetSpawnerPosition(front_spawns, true);
        back_spawns = SortSpawn(SetSpawnVector(false));
        back_spawner = new BasicSpawner();
        back_spawner.SetSpawnerPosition(back_spawns, false);
    }

    public Vector3[] SetSpawnVector (bool front) {
        Vector3[] spawns = new Vector3[spawn_count];
        float yOff = front ? origin.y : origin.y + offset.y;
        float zOff = front ? origin.z : origin.z + offset.z;
        float start = 
            (spawn_count % 2 == 0) ?
            (offset.x / 2f) - (spawn_count / 2 * offset.x):
            0 - ((spawn_count - 1) / 2 * offset.x);
        for (int i = 0; i < spawn_count; i++) {
            spawns[i] = new Vector3 (
                start + offset.x * i,
                yOff,
                zOff
            );
        }
        
        return spawns;
    }

    private Vector3[] InitSpawnSimplified (int length, bool front) {
        return new Vector3[length];
    }

    private Vector3[] SortSpawn (Vector3[] arr) {
        if (method == SpawnerSortingMethod.LeftToRight) return arr;
        Vector3[] ret = new Vector3[arr.Length];
        if (method == SpawnerSortingMethod.CenterRightLeft) {
            int left = 0;
            int right = arr.Length - 1;
            int index = ret.Length - 1;
            while (left < right) {
                ret[index--] = arr[left++];
                if (left >= right) break;
                ret[index--] = arr[right--];
            }
        }
        else if (method == SpawnerSortingMethod.RightToLeft) {
            for (int i = arr.Length - 1; i >= 0; i--) {
                ret[arr.Length - 1 - i] = arr[i];
            }
        }
        return ret;
        
        
    }

    public void Spawn() {
        
    }
}
