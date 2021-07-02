using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;

    public void Spawn()
    {
        enemyManager.aliveEnemys.Add(this.gameObject);
    }
}
