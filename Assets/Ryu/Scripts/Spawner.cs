using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform pool;
    [SerializeField] GameObject particleObj;

    public void Spawn()
    {
        StartCoroutine(Co_Spawn());
    }

    public IEnumerator Co_Spawn()
    {
        GameObject particle = Instantiate(particleObj);

        particle.transform.position = transform.position;

        yield return new WaitForSeconds(1);

        

        // �׸��� enemys�迭�ȿ� ranNum��° ģ���� '����' �Ѵ�.
        GameObject ranEnemy = Instantiate(SelectSpawnObj());
        
        // ������ ģ���� ���ʹ̽����ʿ� ������ ���´�
        ranEnemy.transform.position = transform.position;
        ranEnemy.transform.parent = pool;

        ranEnemy.GetComponent<SpawnComponent>().Spawn();
    }

    protected abstract GameObject SelectSpawnObj();
}