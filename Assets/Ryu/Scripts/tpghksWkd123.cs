using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// (10,0,10)ÁÂÇ¥ ³»¿¡ 1 ¾¿ ¶ç¿ö¼­ 100°³¸¦ ÂÒ¶ó¶ó¶ó¶ó¶ö¶ó¶ó¶ö¶ó¶ó¶ö¶ö¶ó~
// ³ª¿­ÇÏ°í ½Í´Ù


public class tpghksWkd123 : MonoBehaviour
{
    public GameObject cube;

    //ÇöÀç½Ã°£
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
