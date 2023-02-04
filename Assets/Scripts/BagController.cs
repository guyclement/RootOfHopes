using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public GameObject bodyCapsule;
    public bool canRetrieve = false;
    public GameObject dropCapsule;
    public KeyCode key;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            canRetrieve = true;
            RaycastHit groundPos;
            Physics.Raycast(transform.position, Vector3.down, out groundPos);
            GameObject dropContainer = Instantiate(dropCapsule, groundPos.point, Quaternion.identity);
        }
    }
}
