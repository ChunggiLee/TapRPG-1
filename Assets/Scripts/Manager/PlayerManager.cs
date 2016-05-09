using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public WeaponState wState = WeaponState.arrow;
    public bool isMelee = false;
    public bool isHoming = false;
    public MonsterFSM monsterFSM;
    public GameObject[] bullets = new GameObject[50];
    public GameObject bullet;
    public GameObject weapon;
    public float player_BaseDamage = 10.0f;
    public float attackSpeed = 0.8f;


    public int playerLevel;
    public uint gold = 0;
    public uint earnedGold = 0;
    public int a = 0;
    //weapon number
    //init


    void OnEnable()
    {
//        bullet = GameObject.FindGameObjectWithTag("Bullet") as GameObject;
//        for (int i = 0; i < bullets.Length; i++)
//        {
//            bullets[i] = bullet;
//
//        }
        StartCoroutine(InputMouse());
    }

    public IEnumerator InputMouse()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            {

                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 clickPos = pos;
                Ray2D ray = new Ray2D(pos, Vector2.zero);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 15.0f);

                if (hit.collider)
                {
                    monsterFSM = hit.collider.GetComponent <MonsterFSM>();
                    if (isMelee)
                    {

                        meleeAttack(clickPos);

                    }
                    else
                    {
                        rangeAttack(clickPos);
                    }

                }
                else if (isMelee)
                {
                    meleeAttack(clickPos);
                }
                else if (!isMelee)
                {
                    rangeAttack(clickPos);

                }

                // a++;
                if (a > 36)
                {
                    a = 1;

                } 



            }

            yield return new WaitForSeconds(1 / attackSpeed); 
        }


    }

    //update
 




  


    //logic
    //attackprocess
    public void meleeAttack(Vector3 _pos)
    {
        Instantiate(weapon, _pos, Quaternion.Euler(0, 0, 0));


    }

    public void rangeAttack(Vector3 _pos)
    {
        
        Instantiate(bullet, _pos, Quaternion.Euler(0, 0, 0));


    }

    public void PlayerAttack()
    {
        monsterFSM.ProcessDamage(CalCulateDamage());

    }

    public float CalCulateDamage()
    {
        int criticalParcent = Random.Range(0, 100);
        float finalPlayerDamage;
        float doCritical = 1;

        if (criticalParcent <= 30.0f)
        {
            doCritical = 2;

        }



        finalPlayerDamage = ((player_BaseDamage) * doCritical);

        return finalPlayerDamage;

    }










}
