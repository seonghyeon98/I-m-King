using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 플레이어가 자기 자신에게 총알을 생성하고 싶다
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
        // 2. 총알공장에서 총알을 만들어서
        GameObject bullet = Instantiate(bullets[0].prefab);

        // 3. 총구 위치에 가져다 놓고 싶다.
        bullet.transform.position = fireTr.transform.position;
        bullet.transform.forward = transform.forward;
    }
}
