using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform pool;

    public void Spawn()
    {
        // �׸��� enemys�迭�ȿ� ranNum��° ģ���� '����' �Ѵ�.
        GameObject ranEnemy = Instantiate(SelectSpawnObj());

        // ������ ģ���� ���ʹ̽����ʿ� ������ ���´�
        ranEnemy.transform.position = transform.position;
        ranEnemy.transform.parent = pool;

        ranEnemy.GetComponent<SpawnComponent>().Spawn();
    }

    protected abstract GameObject SelectSpawnObj();
}