using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeBetweenVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public float GetMoveSpeed() { return moveSpeed; }

    public Transform GetStartingWaypoint() { return pathPrefab.GetChild(0); }

    public int GetEnemyCount() { return enemyPrefabs.Count; }

    public GameObject GetEnenyPrefab(int index) { return enemyPrefabs[index]; }

    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(
            timeBetweenEnemySpawns - spawnTimeBetweenVariance,
            timeBetweenEnemySpawns + spawnTimeBetweenVariance);

        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
