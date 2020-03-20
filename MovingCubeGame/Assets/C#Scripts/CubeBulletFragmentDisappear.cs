using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBulletFragmentDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.3f);      // 0.3秒后自动消失
    }
}
