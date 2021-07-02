using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;

    public void Death()
    {
        enemyManager.aliveEnemys.Remove(this.gameObject);
    }
}
