using UnityEngine;
using System.Collections;

public class HomingMove : MonoBehaviour
{

    public Transform my;
    public GameObject[] targetPool;
    public GameObject targetMonster;
    public int rotateSide;
    public PlayerManager playerManager;
    public float rotateSpeed = 480.0f;

    void OnEnable()
    {
        playerManager = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<PlayerManager>();
        rotateSide = Random.Range(0, 2);//0 :right 1:left


        
        my = transform;
    
        findMonster();
        if (!playerManager.isHoming)
        {
            gameObject.GetComponent<HomingMove>().enabled = false;

        }

    }

    void Update()
    {
        if (targetMonster == null||targetMonster.GetComponent<MonsterFSM>().state == CharacterState.Dead)
        {
            findMonster();
        }
        else
        {
            HomingBullet();

        }
    }

    public void findMonster()
    {
       
        if (GameObject.FindGameObjectWithTag("Monster") != null)
        {


            targetPool = GameObject.FindGameObjectsWithTag("Monster");
        
            targetMonster = targetPool[0];

            int storeNum = 0;
            for (int i = 0; i < targetPool.Length; i++)//가장 밑에 있는 적 탐색
            {

                if (targetMonster.transform.position.y >= targetPool[i].transform.position.y)
                {
                    storeNum = i;

                }

            }
            targetMonster = targetPool[storeNum];
        }


    }

    public void HomingBullet()
    {
        Vector3 moveDir = (targetMonster.transform.position - my.position).normalized;

        float dot = Vector3.Dot(moveDir, my.transform.up);//vector 내적


        if (dot < 0.95f)
        {
            if (rotateSide == 0)
            {
                gameObject.transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime); 


            }
            else
            {
                gameObject.transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime); 


            }

        }




    }





}