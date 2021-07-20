using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    float currentTime;
    float delayTime = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= delayTime)
        {
            Destroy(gameObject);
        }
    }
}
