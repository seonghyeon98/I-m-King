using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    [SerializeField]float delay;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
