using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGunShoot : MonoBehaviour
{
    public GameObject bullet;               // 子弹对象
    public int cubeGunShootInterval = 10;   // 射击间隔
    private int cubeGunShootCnt = 0;        // 射击间隔辅助
    public AudioSource cubeGunShootAs;      // 射击音效

    // Update is called once per frame
    void Update()
    {
        if (1 == Input.GetAxis("Fire1") && 0 >= cubeGunShootCnt)
        {   // 射击
                GameObject bulletObj = GameObject.Instantiate(bullet, transform.position + Vector3.forward * 0.1f, transform.rotation);
                cubeGunShootCnt = cubeGunShootInterval;
                cubeGunShootAs.Play();
        }
        cubeGunShootCnt--;
    }
}
