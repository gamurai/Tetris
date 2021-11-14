using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : GenericSingleton<SpawnerManager>
{
    [SerializeField]
    private GameObject[] Groups;
    [SerializeField]
    private Transform SpawnPoint;

    public void Spawn()
    {
        var index = Random.Range(0, Groups.Length);
        Instantiate(Groups[index], SpawnPoint.position, Quaternion.identity);
    }
}
