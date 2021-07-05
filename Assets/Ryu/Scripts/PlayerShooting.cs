using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �÷��̾ �ڱ� �ڽſ��� �Ѿ��� �����ϰ� �ʹ�
//f)
//	bullets
//	fireTr
//	attackSpeed

//m)
//	Shoot()

[System.Serializable]
public class Bullet
{
    public GameObject prefab;
    public int amount;
}

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Bullet[] bullets;
    [SerializeField] Transform fireTr;
    [SerializeField] float shootDelay;
    float currentTime = 0;

    private void Start()
    {
        StartCoroutine(Co_Shoot());
    }

    IEnumerator Co_Shoot()
    {
        while (true)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                yield return new WaitForSeconds(shootDelay);
            }
            else yield return null;
        }
    }  

    void Shoot()
    {
        // 2. �Ѿ˰��忡�� �Ѿ��� ����
        GameObject bullet = Instantiate(bullets[0].prefab);

        // 3. �ѱ� ��ġ�� ������ ���� �ʹ�.
        bullet.transform.position = fireTr.transform.position;
        bullet.transform.forward = transform.forward;
    }
}
