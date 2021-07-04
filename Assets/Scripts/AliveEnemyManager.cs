using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����ִ� ��ü ����
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