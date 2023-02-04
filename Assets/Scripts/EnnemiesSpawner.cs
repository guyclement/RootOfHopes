using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnnemiesSpawner : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> ennemyList;
    public float offset = 10f;
    public float playerHeight = 1.5f;

    public LayerMask whatIsWall;

    public int minEnnemies = 2;
    public int maxEnnemies = 5;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            for (int i = 0; i < Random.Range(minEnnemies, maxEnnemies); i++)
            {
                GameObject ennemi = ennemyList[Random.Range(0, ennemyList.Count)];
            }
        }
    }
}
