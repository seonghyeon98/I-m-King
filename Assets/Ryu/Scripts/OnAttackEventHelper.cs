using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackEventHelper : MonoBehaviour
{
    EnemyFSM enemyFSM;
    private void Awake()
    {
        enemyFSM = transform.parent.GetComponent<EnemyFSM>();
    }
    public void OnMeleeAttack()
    {
        enemyFSM.OnMeleeAttack();
    }
    public void OnRangeAttack()
    {
        enemyFSM.OnRangeAttack();
    }
}
