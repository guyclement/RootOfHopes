using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EasierContainer : MonoBehaviour
{
    private bool isDropped = false;
    public GameObject itself;
    private bool isAround = false;

    public KeyCode keyInteraction;

    public void Update()
    {
                if (Input.GetKeyDown(keyInteraction) && isAround == false)
                {
                    Debug.Log("dropped It");
                    isAround = true;
                    isDropped = true;
                    RaycastHit groundPos;
                    Physics.Raycast(transform.position, Vector3.down, out groundPos);
                    GameObject dropContainer = Instantiate(itself, groundPos.point, Quaternion.identity);
                    dropContainer.GetComponent<dropContainer>().bodyContainer = gameObject;
                    gameObject.SetActive(false);
                }
    }
}
