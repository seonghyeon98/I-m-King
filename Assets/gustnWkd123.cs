using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gustnWkd123 : MonoBehaviour
{
    IEnumerator Start()
    {
        while (true)
        {

            for (int i = 0; i < 100; i++)
            {
                GameObject obj = SpawnType();
                obj.AddComponent<Rigidbody>();
                obj.GetComponent<Renderer>().material.color = Color.cyan;
                obj.transform.parent = transform;
                Destroy(obj, 10);
            }
            yield return new WaitForSeconds(1);
        }
    }

    private GameObject SpawnType()
    {
        switch (Random.Range(0, 4))
        {
            case 0: return GameObject.CreatePrimitive(PrimitiveType.Cube);
            case 1: return GameObject.CreatePrimitive(PrimitiveType.Capsule);
            case 2: return GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            case 3: return GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
        return null;
    }
}
