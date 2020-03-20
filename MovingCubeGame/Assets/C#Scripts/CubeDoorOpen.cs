using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDoorOpen : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if ("MoveObject" == other.gameObject.tag)
        {
            bool x = door.GetComponent<Animator>().GetBool("opendoor");

            x = !x;

            door.GetComponent<Animator>().SetBool("opendoor", x);
        }
    }

}
