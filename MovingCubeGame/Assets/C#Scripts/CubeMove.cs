using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // Update is called once per frame
    public float speed;                         // 速度，外部赋值
    public CharacterController cubeController;  // 移动控制器，外部赋值
    public float cubeJumpSpeed = 5;             // 跳起时速度，外部可修改
    public int cubeHp = 100;                    // 自身血量

    private const float g = 10;                 // 重力加速度
    private Vector3 cubeMoveVec;                // 计算移动量，注意 transform.right 和 transform.forward 是 Vector3

    // 每帧都会调用 Update 函数
    void Update()
    {
        // 如果hp已经没了，那么就死掉吧
        if (cubeHp <= 0)
        {
            Destroy(gameObject);
        }
        // 获取键盘移动操作输入
        float x = 0, z = 0;

        if (cubeController.isGrounded)          // 跳起来就不允许控制了
        {
            x = Input.GetAxis("Horizontal");    // 获取水平方向两个控制量
            z = Input.GetAxis("Vertical");

            // 合成控制量，并转换到local坐标系
            cubeMoveVec = (transform.right * x + transform.forward * z) * speed;
            if (Input.GetKey(KeyCode.LeftShift))// 如果按下了左侧Shift则跑动
            {
                cubeMoveVec *= 2.5f;
            }

            if (1 == Input.GetAxis("Jump"))     // 如果按下了Space则跳起来，设置cubeJumpSpeed的跳起速度
            {
                cubeMoveVec.y = cubeJumpSpeed;
            }
        }
        else                                    // 如果不在地面，则逐渐让物体降下来
        {                                       
            cubeMoveVec.y -= g * Time.deltaTime;
        }

        // 执行移动命令
        cubeController.Move(cubeMoveVec * Time.deltaTime);
    }

    public void beAttacked(int hpHurt)          // 被攻击到掉血
    {
        cubeHp -= hpHurt;
    }
}
