using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 살아있는 객체 관리
public class AliveEnemyManager : MonoBehaviour
{
    List<GameObject> aliveEnemys = new List<GameObject>();
    [SerializeField] SpawnerManager spawnerManager;

    public void Add(GameObject obj)
    {
        aliveEnemys.Add(obj);
    }

    public void Remove(GameObject obj)
    {
        aliveEnemys.Remove(obj);

        if (AliveCount() == 0)
        {
            spawnerManager.Spawn();
        }
    }

    public int AliveCount()
    {
        return aliveEnemys.Count;
    }
}