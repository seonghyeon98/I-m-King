using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-> � ���� �����Ұ��� ���� ����
//-> �� �������� �����ͼ� �ڱ� ��ġ�� �����Ѵ�

//Spawn() ���� �ڱ� ��ġ(EnemySpawner)�� ������ ���´�
//	RandomSpawn() SelectSpawnObj()

//  Ȯ���� �̾Ƽ� ���� �������� ���� ��� ���Ÿ��� ���� ���  ���� �׿� �´� �ַ� �����Ѵ�

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;

    public void Spawn()
    {
        // ���ʹ� �迭 ���̸�ŭ �������� ���� �ϳ� �̾�
        int ranNum = Random.Range(0, enemys.Length);
        // �׸��� enemys�迭�ȿ� ranNum��° ģ���� '����' �Ѵ�.
        GameObject ranEnemy = Instantiate(enemys[ranNum]);
        // ������ ģ���� ���ʹ̽����ʿ� ������ ���´�
        ranEnemy.transform.position = transform.position;
    }
}
