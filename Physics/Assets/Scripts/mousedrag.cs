using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag : MonoBehaviour
{
    void OnMouseDrag()
    {
        if (this.gameObject.GetComponent<Rigidbody>() != null)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Input.GetAxis("Mouse X") * 5, Input.GetAxis("Mouse Y") * 5, 0);
        }
        else
        {
            transform.position += Vector3.right * Time.deltaTime * Input.GetAxis("Mouse X");
            transform.position += Vector3.up * Time.deltaTime * Input.GetAxis("Mouse Y");
        }
    }
}
