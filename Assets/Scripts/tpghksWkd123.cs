using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// (10,0,10)��ǥ ���� 1 �� ����� 100���� �Ҷ�����������������~
// �����ϰ� �ʹ�


public class tpghksWkd123 : MonoBehaviour
{
    public GameObject cube;

    //����ð�
    float curruntTime;
    public float createTime = 5;

    // Start is called before the first frame update
    
    void CubeBomb()
    {
        for (int i = 1; i < 11; i++)
        {
            for (int j = 1; j < 11; j++)
            {
                GameObject cubes = Instantiate(cube, new Vector3(i * 0.5f, 0, j * 0.5f), Quaternion.identity);
                cubes.AddComponent<Rigidbody>();
                cubes.GetComponent<Renderer>().material.color = Color.red;
                print(i + "," + j);
            }

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        curruntTime += Time.deltaTime;
        if (curruntTime > createTime)
        {
            CubeBomb();
            curruntTime = 0;
        }
    }
}
