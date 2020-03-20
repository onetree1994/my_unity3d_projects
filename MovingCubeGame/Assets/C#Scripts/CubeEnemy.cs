using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    public int enemyHp = 100;                       // 敌人血量
    public float enemyTurnInterval = 10;            // 未发现自己时，敌人转弯周期
    public CharacterController enemyController;     // 敌人移动控制器
    private float enemyLastTurnTime = 0;            // 上次转弯时刻
    private float enemyMoveAngle = 0;               // 运动角度
    private const float enemySpeed = 5;             // 敌人移动速度
    Vector3 dirVec;                                 // 自己与敌人相对位置
    Vector3 enemyMoveVec;                           // 敌人移动方向
    public Rigidbody enemyRigid;                    // 敌人刚体

    private void Start()                            // 初始化
    {
        enemyLastTurnTime = -100;
        enemyMoveVec = transform.forward * Mathf.Sin(enemyMoveAngle) + transform.right * Mathf.Cos(enemyMoveAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHp <= 0) Destroy(gameObject);      // 没血就销毁

        // 一下一段控制如果敌人发现与自己距离达到一定范围，就去攻击自己，否则就随机乱走
        float dis = 100000000;
        GameObject cubeObject = GameObject.FindGameObjectWithTag("MoveObject");                                 // 获取自己的引用
        if (cubeObject != null)                     // 计算相对方位
        {
            dirVec = cubeObject.transform.position - transform.position;
            dirVec.y = 0;
            dis = Vector3.Distance(cubeObject.transform.position, transform.position);
        }
        if (dis < 50)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirVec), 0.3f);
            transform.position += dirVec.normalized * enemySpeed * Time.deltaTime * 2;

            //enemyRigid.velocity = dirVec.normalized * enemySpeed;
        }
        else if (dis < 200)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirVec), 0.3f);
            transform.position += dirVec.normalized * enemySpeed * Time.deltaTime * 0.5f;

            //enemyRigid.velocity = dirVec.normalized * enemySpeed * 2;
        }
        else // 随机移动
        {
            if (enemyTurnInterval <= (Time.time - enemyLastTurnTime))
            {
                enemyLastTurnTime = Time.time;
                enemyMoveAngle = Random.value * Mathf.PI;

                enemyMoveVec = transform.forward * Mathf.Sin(enemyMoveAngle) + transform.right * Mathf.Cos(enemyMoveAngle);
            }
            // print(transform.position);
            if (transform.position.x > 950 || transform.position.x < 50 || transform.position.z > 950 || transform.position.z < 50)
            { // 防止出界
                enemyMoveVec = transform.position;
                enemyMoveVec.x = 500 - enemyMoveVec.x;
                enemyMoveVec.z = 500 - enemyMoveVec.z;
                enemyMoveVec.y = 0;
            }
            transform.position += enemyMoveVec.normalized * enemySpeed * Time.deltaTime;

            // enemyRigid.velocity = enemyMoveVec.normalized * enemySpeed;
        }
    }

    private void OnTriggerEnter(Collider other)  // 击中自己时，扣除自己血量
    {
        // print(collision.gameObject.tag);
        if ("MoveObject" == other.gameObject.tag)
        {
            // print(collision.gameObject.tag);
            other.gameObject.GetComponent<CubeMove>().beAttacked(10);
        }
    }


    public void beAttacked(int hpHurt)                  // 被击中时的反应
    {
        enemyHp -= hpHurt;
    }
}
