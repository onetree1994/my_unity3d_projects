using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTerrain : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cubeEnemy;        // 敌人对象
    public int cubeEnemyNum = 1000;     // 敌人数量

    void Start()
    { // 随机创建敌人对象
        for (int i = cubeEnemyNum; i > 0; i--)
        {
            Vector3 cubeEnemyObjPos;
            cubeEnemyObjPos.x = Random.Range(200f, 800f);
            cubeEnemyObjPos.y = Random.Range(1.6f, 1.7f);
            cubeEnemyObjPos.z = Random.Range(200f, 800f);
            Vector3 cubeEnemyObjAng;
            cubeEnemyObjAng.x = 0f;
            cubeEnemyObjAng.y = Random.Range(0f, Mathf.PI);
            cubeEnemyObjAng.z = 0f;
            GameObject cubeEnemyObj = GameObject.Instantiate(cubeEnemy, cubeEnemyObjPos, Quaternion.Euler(cubeEnemyObjAng));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
