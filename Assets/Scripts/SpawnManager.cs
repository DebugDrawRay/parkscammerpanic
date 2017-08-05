using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public SpawnGroup CustomerSpawnGroup;
    public SpawnGroup PoliceSpawnGroup;
    public SpawnGroup ItemSpawnGroup;

    public NavMeshAgent NavAgent;

    private void Awake()
    {
        Instance = this;
    }

    public void InitializeLevel()
    {
        Debug.Log("Initalizing Spawning");
        SpawnThings(CustomerSpawnGroup);
    }

    public void SpawnThings(SpawnGroup spawnGroup)
    {
        int spawnCount = 0;
        int loopCount = 0;
        while (spawnCount < spawnGroup.TargetCount)
        {         
            int spawnIndex = Random.Range(0, spawnGroup.SpawnPoints.Length);
            Vector3 position = spawnGroup.SpawnPoints[spawnIndex].SpawnTransform.position 
                + (Random.insideUnitSphere * spawnGroup.SpawnPoints[spawnIndex].SpawnRadius);
            position.y = 0;

            Debug.Log("Proposed Position: " + position);

            NavMeshPath path = new NavMeshPath();
            if (NavAgent.CalculatePath(position, path))
            {
                Debug.Log("Valid Position! Spawning Object");
                Instantiate(spawnGroup.Prefab, position, Quaternion.identity);
                spawnCount++;
            }

            loopCount++;
            if (loopCount > 1000)
            {
                Debug.LogWarning("Couldn't Find Spawn Position");
                break;
            }
        }
    }

    [System.Serializable]
    public class SpawnGroup
    {
        public int TargetCount;
        public SpawnPoint[] SpawnPoints;
        public GameObject Prefab;
    }

    [System.Serializable]
    public class SpawnPoint
    {
        public Transform SpawnTransform;
        public int SpawnRadius;
    }
}
