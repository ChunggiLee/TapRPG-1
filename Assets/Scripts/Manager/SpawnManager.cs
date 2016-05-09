using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPivot;
    public Transform[] spawnPoints;
 
    public GameObject spawningMonster;
    public float sqawnInterval=2.0f;


    public int a=0;

    void Awake()
    {
        spawnPoints = spawnPivot.GetComponentsInChildren<Transform>();


        InvokeRepeating("Spawn", 0.0f, sqawnInterval);
    }



    public void Spawn()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

 
        spawningMonster.GetComponent<MonsterFSM>().no = a;

        Instantiate(spawningMonster, point.position, point.rotation);


//        a++;
//        if (a > 34)
//        {
//            a = 1;
//
//        }
       
    }

}
