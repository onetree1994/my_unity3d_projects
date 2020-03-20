using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeViewRotate : MonoBehaviour
{
    public float cubeViewRotateSpeed;
    public Transform cubeTransform;
    private float cubeUpAngle;


    // Start is called before the first frame update
    void Start()
    {
        // 锁定鼠标位置
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // 获取鼠标偏移量，并限制纵向角度范围
        float x, y;
        x = Input.GetAxis("Mouse X") * cubeViewRotateSpeed * Time.deltaTime;
        y = Input.GetAxis("Mouse Y") * cubeViewRotateSpeed * Time.deltaTime;
        cubeUpAngle -= y;
        cubeUpAngle = Mathf.Clamp(cubeUpAngle, -80, 80);

        // 像机偏转 - 垂直方向
        this.transform.localRotation = Quaternion.Euler(cubeUpAngle, 0, 0);

        // MoveObject旋转 - 水平方向
        cubeTransform.Rotate(Vector3.up * x);
    }
}
