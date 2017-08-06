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

    public Transform[] PolicePatrolPoints;

    public NavMeshAgent NavAgent;

    private void Awake()
    {
        Instance = this;
    }

    public void InitializeLevel()
    {
        Debug.Log("Initalizing Spawning");
        SpawnThings(CustomerSpawnGroup);
        SpawnThings(ItemSpawnGroup);
        SpawnThings(PoliceSpawnGroup);
    }

    public void SpawnThings(SpawnGroup spawnGroup)
    {
        int loopCount = 0;
        while (spawnGroup.CurrentCount < spawnGroup.TargetCount)
        {         
            int spawnIndex = Random.Range(0, spawnGroup.SpawnPoints.Length);
            Vector3 position = spawnGroup.SpawnPoints[spawnIndex].SpawnTransform.position 
                + (Random.insideUnitSphere * spawnGroup.SpawnPoints[spawnIndex].SpawnRadius);
            position.y = 0.5f;

            NavMeshPath path = new NavMeshPath();
            if (NavAgent.CalculatePath(position, path))
            {
                Instantiate(spawnGroup.Prefab, position, Quaternion.identity);
                spawnGroup.CurrentCount++;
            }

            loopCount++;
            if (loopCount > 1000)
            {
                Debug.LogWarning("Couldn't Find Spawn Position");
                break;
            }
        }
    }

    public void RemovedItem()
    {
        ItemSpawnGroup.CurrentCount--;
        SpawnThings(ItemSpawnGroup);
    }

    public void RemovedCustomer()
    {
        CustomerSpawnGroup.CurrentCount--;
        SpawnThings(CustomerSpawnGroup);
    }

    public void RemovedPolice()
    {
        PoliceSpawnGroup.CurrentCount--;
        SpawnThings(PoliceSpawnGroup);
    }

    public Transform[] GetPolicePatrolPoints()
    {
        return PolicePatrolPoints;
    }

    [System.Serializable]
    public class SpawnGroup
    {
        public int TargetCount;
        public SpawnPoint[] SpawnPoints;
        public GameObject Prefab;

        [HideInInspector]
        public int CurrentCount = 0;
    }

    [System.Serializable]
    public class SpawnPoint
    {
        public Transform SpawnTransform;
        public int SpawnRadius;
    }
}
