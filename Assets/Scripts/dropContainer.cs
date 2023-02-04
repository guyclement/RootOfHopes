using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropContainer : MonoBehaviour
{
    public KeyCode keyInteraction;
    public EasierContainer EasierContainer;

    public void Start()
    {
        EasierContainer = GetComponent<EasierContainer>;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("get it");
            if (Input.GetKeyDown(keyInteraction))
            {
                Destroy(collider);
                bodyContainer.GetComponent("TreeCapsule");
                
            }
        }
    }
}
