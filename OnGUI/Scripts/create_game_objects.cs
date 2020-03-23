using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_game_objects : MonoBehaviour
{
    public GameObject myObj;                // prefab

    public GameObject cube;                 // cube对象
    public int transSpeed = 100;
    public float rotaSpeed = 10.5f;
    public float scale = 3;

    void OnGUI()                            // gui绘制和功能
    {
        // 以下每个if对应一个按钮
        if (GUI.Button(new Rect(500, 100, 100, 50), "hello"))
        {
            print("Button Clicked!");
        }
        if (GUILayout.Button("Instantiate", GUILayout.Height(50)))
        {   // 创建我们自制的prefab对象
            GameObject myobjins = Instantiate(myObj, transform.position, transform.rotation);
            myobjins.AddComponent<Rigidbody>();
            myobjins.GetComponent<Renderer>().material.color = Color.blue;
            myobjins.transform.position = new Vector3(0, 10, 0);
        }
        if (GUILayout.Button("CreatePrimitive-Cube", GUILayout.Height(50)))
        {   // 创建内建的cube
            GameObject m_cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            m_cube.AddComponent<Rigidbody>();
            m_cube.GetComponent<Renderer>().material.color = Color.blue;
            m_cube.transform.position = new Vector3(0, 10, 0);
        }
        if (GUILayout.Button("CreatePrimitive-Sphere", GUILayout.Height(50)))
        {   // 创建内建的sphere
            GameObject m_cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            m_cube.AddComponent<Rigidbody>();
            m_cube.GetComponent<Renderer>().material.color = Color.red;
            m_cube.transform.position = new Vector3(0, 10, 0);
        }
        if (GUILayout.Button("移动立方体", GUILayout.Height(50)))
        {   // 移动cube
            cube.transform.Translate(Vector3.forward * transSpeed * Time.deltaTime, Space.World);
        }
        if (GUILayout.Button("旋转立方体", GUILayout.Height(50)))
        {   // 旋转cube
            cube.transform.Rotate(Vector3.up * rotaSpeed, Space.World);
        }
        if (GUILayout.Button("缩放立方体", GUILayout.Height(50)))
        {   // 缩放cube
            cube.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
