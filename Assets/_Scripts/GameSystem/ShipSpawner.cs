using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3[] spawn_positions;
    [SerializeField]
    private int spawn_count = 3;
    [SerializeField]
    private float spawn_x = 0f;
    [SerializeField]
    private float spawn_x_offset = 2f;
    [SerializeField]
    private float spawn_y = 1f;
    [SerializeField]
    private float spawn_y_offset = 0.2f;
    [SerializeField]
    private float spawn_z = 0f;
    [SerializeField]
    private float spawn_z_offset = 5f;
    
    void Awake() {
        spawn_positions = new Vector3[spawn_count];
        // spawn_positions[0] = new Vector3(spawn_x, spawn_y, spawn_z);
        SetSpawnPositions();
    }

    void SetSpawnPositions() {
        spawn_positions[0] = new Vector3(spawn_x, spawn_y, spawn_z);
        int count = 0; float x_off_mult = 1f;
        for (int i = 1; i < spawn_count; i++) {
            if (i % 2 == 0) { // on even, go left
                spawn_positions[i] = new Vector3(
                    spawn_x - spawn_x_offset * x_off_mult,
                    (count % 2 == 0 ? spawn_y + spawn_y_offset : spawn_y),
                    (count % 2 == 0 ? spawn_z + spawn_z_offset : spawn_z)
                );
                x_off_mult++;
            } else {
                spawn_positions[i] = new Vector3(
                    spawn_x + spawn_x_offset * x_off_mult,
                    (count % 2 == 0 ? spawn_y + spawn_y_offset : spawn_y),
                    (count % 2 == 0 ? spawn_z + spawn_z_offset : spawn_z)
                );
            }
            count++;
        }
    }
}
