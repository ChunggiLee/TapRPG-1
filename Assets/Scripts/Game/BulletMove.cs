using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour
{
    
    public float bulletSpeed = 5.0f;
    public float bulletLifeTime = 3.0f;
    public float currentTime=0.0f;
    public int bulletCount = 1;
    public float rotateSpeed = 400.0f;


    private int colCount = 0;
    private Transform arrowBullet;
    private Transform starBullet;
    private Transform my;
    public PlayerManager playerManager;
    public string arrowPath;
    public string starPath;
    public bool isMiss = false;


    public Vector3 view;


    void OnEnable()
    {
        my = gameObject.GetComponent <Transform>();
        playerManager = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<PlayerManager>();


        arrowPath = "Weapon/Arrow/Arrow" + playerManager.a.ToString();
        starPath = "Weapon/Star/Star" + playerManager.a.ToString();

        arrowBullet = my.FindChild("Arrow");
        starBullet = my.FindChild("Star");




        arrowBullet.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(arrowPath);
        starBullet.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(starPath);

        starBullet.gameObject.SetActive(false);
        arrowBullet.gameObject.SetActive(false);



        if (playerManager.wState == WeaponState.arrow)
        {
            arrowBullet.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.star)
        {
            starBullet.gameObject.SetActive(true);
        }









    }

    void OnDisable()
    {


    }

    void Update()
    {
        
        my.Translate(0, bulletSpeed * Time.deltaTime, 0);
        if (playerManager.wState == WeaponState.star)
        {
            starBullet.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        view = Camera.main.WorldToViewportPoint(my.position);
        if (view.y > 1.2f || view.y < -0.8f||view.x > 1.2f||view.x<-0.8f)
        {
            currentTime += Time.deltaTime;
            if (bulletLifeTime <= currentTime)
            {
                gameObject.SetActive(false);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D _hit)
    {
        isMiss = false;

        playerManager.monsterFSM = _hit.GetComponent<MonsterFSM>();
        if (playerManager.monsterFSM.feature1 == "Reflect")
        {
            if (Random.Range(0.0f, 100.0f) <= playerManager.monsterFSM.feature2)
            {
                my.Rotate(0, 0, Random.Range(0.0f, 360.0f));
                isMiss = true;
            }

        }
        if (!isMiss)
        {

            playerManager.monsterFSM.ProcessDamage(playerManager.CalCulateDamage());
            colCount++;
            if (colCount >= bulletCount)
            {
                if (playerManager.wState == WeaponState.arrow)
                {
                    my.SetParent(_hit.transform);
                    my.GetComponent<BoxCollider2D>().enabled=false;
                    my.GetComponent<BulletMove>().enabled=false;
                    my.GetComponent<HomingMove>().enabled=false;

                }
                else
                {
                
                    gameObject.SetActive(false);

                }
            }
        }

    }

   

}