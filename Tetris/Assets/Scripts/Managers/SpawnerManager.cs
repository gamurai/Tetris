using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : GenericSingleton<SpawnerManager>
{
    [SerializeField]
    private GameObject[] Groups;
    [SerializeField]
    private Transform SpawnPoint;

    public delegate void GroupSpawned(Group group);
    public static event GroupSpawned OnGroupSpawned;

    public Group Spawn()
    {
        var index = Random.Range(0, Groups.Length);
        var newObject = Instantiate(Groups[index], SpawnPoint.position, Quaternion.identity);
        var group = newObject.GetComponent<Group>();

        OnGroupSpawned(group);

        return group;
    }
}
