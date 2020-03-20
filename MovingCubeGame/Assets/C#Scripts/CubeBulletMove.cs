using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBulletMove : MonoBehaviour
{
    // Start is called before the first frame update

    private const float bulletSpeed = 200;      // 子弹速度
    private const float bulletLiveTime = 3;     // 子弹存活时间
    public Rigidbody bulletRigid;               // 给子弹初始一个力，子弹是刚体，此后会自动掉落
    public GameObject bulletFragment;           // 子弹碎片

    void Start()
    {
        Destroy(gameObject, bulletLiveTime);                            // bulletLiveTime后销毁
        bulletRigid.velocity = (this.transform.forward) * bulletSpeed;  // 子弹初始受力
    }

    private void OnCollisionEnter(Collision collision)                  // 击中敌人，对其造成伤害
    {
        if ("Enemy" == collision.gameObject.tag)
        {
            collision.gameObject.GetComponent<CubeEnemy>().beAttacked(20);
        }
        if ("MoveObject" != collision.gameObject.tag)                   // 不允许子弹击中自己
        {
            GameObject bulletFragmentObj = GameObject.Instantiate(bulletFragment, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
