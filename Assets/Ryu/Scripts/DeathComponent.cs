using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    [SerializeField] AliveEnemyManager aliveEnemyManager;

    void Awake()
    {
        aliveEnemyManager = GameObject.Find("EnemyManager").GetComponent<AliveEnemyManager>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);

        Death();
    }

    public void Death()
    {
        aliveEnemyManager.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
