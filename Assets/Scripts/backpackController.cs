using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class backpackController : MonoBehaviour
{
    public enum Etat{PORTE, POSE, WAIT}
    public float range;
    public GameObject capsuleContainer;
    public GameObject itself;
    public Camera camera;
    public float textPosY;
    public float playerHeight;

    public KeyCode inputInteraction;
    public float decalage;
    public float offestRot;

    private Boolean playerInSightRange;
    public LayerMask whatIsPlayer;
    
    public Etat etat;

    private int numberFrameWait = 10;
    private int startFrame;

    private Etat nextEtat;

    // Start is called before the first frame update
    void Start()
    {
        this.etat = Etat.PORTE;
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.etat)
        {

            case Etat.PORTE:
                UnityEngine.Debug.Log("doit poser");
                transform.position = new Vector3(transform.position.x, playerHeight, transform.position.z);
                if (Input.GetKeyDown(inputInteraction))
                {
                    dropItem();
                }
                break; 
            case Etat.POSE:
                UnityEngine.Debug.Log("doit récupérer");
                
                playerInSightRange = Physics.CheckSphere(transform.position, range, whatIsPlayer);
                if (playerInSightRange && Input.GetKeyDown(inputInteraction))
                {
                        ramasser();
                }
                break;
            case Etat.WAIT:
                UnityEngine.Debug.Log("attends");
                if (Time.frameCount >= startFrame + numberFrameWait)
                {
                    this.etat = nextEtat;
                }
                break;
        }
    }

    public void dropItem()
    {
        RaycastHit groundPos;
        Physics.Raycast(transform.position, Vector3.down, out groundPos);
        startFrame = Time.frameCount;
        this.etat = Etat.WAIT;
        this.nextEtat = Etat.POSE;
        Instantiate(itself, groundPos.point, Quaternion.identity);
        itself.SetActive(false);
    }
    
    public void ramasser()
    {   
        startFrame = Time.frameCount;
        this.etat = Etat.WAIT;
        this.nextEtat = Etat.PORTE;
        Destroy(gameObject);
        itself.SetActive(true);
    }
    
    

    public bool isOnGround()
    {
        if (this.etat == Etat.PORTE)
        {
            return false;
        }else
        {
            return true;
        }
    }
}