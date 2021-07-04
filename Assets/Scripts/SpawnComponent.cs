using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] AliveEnemyManager aliveEnemyManager;

    void Awake()
    {
        aliveEnemyManager = GameObject.Find("EnemyManager").GetComponent<AliveEnemyManager>();
    }

    public void Spawn()
    {
        aliveEnemyManager.Add(this.gameObject);

        // ��ƼŬ
        // �ִϸ��̼�
        // ����
        // ü�� �ʱ�ȭ
    }
}
