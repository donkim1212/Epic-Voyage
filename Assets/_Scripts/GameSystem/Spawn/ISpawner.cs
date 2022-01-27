using UnityEngine;

public interface ISpawner
{
    void SetSpawnerPosition(Vector3[] pos, bool isFront);
    void Spawn();
    void Despawn();
}
