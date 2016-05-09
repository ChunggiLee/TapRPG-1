using UnityEngine;
using System.Collections;

public class MonsterFSM : FSMBase
{
    public int no;
    public int stage;
    public int elite;
    public float maxHp;
    public float currentHp;
    public float moveSpeed;
    public string feature1;
    public float feature2;
    public float currentSP = 0.0f;
    public float maxSP=1.5f;
    public bool isKilled = false;
    public bool isSplit;
    public int monsterLevel =10;//edit
    public string monsterName;

    public Transform my;



    public string imagePath;


    public float knockbackSpeed = 2.0f;
    public float KnockbackTime = 0.1f;
    [HideInInspector]
    public MonsterData.Attribute _monsterData;
    public SpriteRenderer monsterSprite;

    private float colorModified = 1.0f;
    public  GameObject splitMonster;
    public float healHP;
    public bool isInvincible = false;
    //sdf

    public BoxCollider2D monsterCollider;
    public MonsterHUD monsterHUD;



    protected override void Awake()
    {


    }

    protected override void OnEnable()
    {
        my = gameObject.GetComponent<Transform>();
        monsterCollider = gameObject.GetComponent<BoxCollider2D>();


        _monsterData = DataManager.Instance.monsterData.list[no - 1];
        //monsterLevel = PlayerManager. playerlevel +- 5;
        maxHp = (_monsterData.maxHP)*monsterLevel*elite;
        monsterName = _monsterData.name;
        if (isSplit)
        {
            maxHp *= 0.5f;
            monsterName = monsterName + "Split";
        }
        currentHp = maxHp;
        moveSpeed = _monsterData.moveSpeed;//(elite);
        feature1 = _monsterData.feature1;
        feature2 = _monsterData.feature2;
        KnockbackTime /= elite;
        my.localScale *= elite;
        KnockbackTime /= (elite * elite);
        if (elite >= 3)
        {
            KnockbackTime = 0;
        }


        healHP = maxHp * feature2;






        currentSP = 0;



        monsterSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        base.OnEnable();
        StartCoroutine(MonsterAnimation());

        monsterHUD  = GameObject.FindGameObjectWithTag("MonsterUI").GetComponent<MonsterHUD>();

        imagePath = ("Monsters/Level" + elite.ToString() + "/monster_" + (no * 2).ToString()).ToString();

    }

    void Update()
    {

       

       // stamina += Time.deltaTime;
       


    }

    protected IEnumerator MonsterAnimation()
    {
        while (true)
        {
           
            monsterSprite.sprite = Resources.Load<Sprite>("Monsters/Level"+elite.ToString()+"/monster_" + (no * 2).ToString());
            currentSP += 0.1f;
            if (currentSP >= maxSP)
            {
                ProcessStamina();
            }
            yield return new WaitForSeconds(0.3f);

            monsterSprite.sprite = Resources.Load<Sprite>("Monsters/Level"+elite.ToString()+"/monster_" + ((no * 2) - 1).ToString());
            currentSP += 0.1f;
            if (currentSP >= maxSP)
            {
                ProcessStamina();
            }
            yield return new WaitForSeconds(0.3f);


           
        }
    }




    //function


    public void ProcessDamage(float _damage)
    {
        if (feature1 == "Block")
        {
            Block(_damage);
        }
        else if (isInvincible)
        {
            _damage = 0;
        }
       
        monsterHUD.SelectMonster(my.GetComponent<MonsterFSM>());






        currentHp -= _damage;



 
        SetState(CharacterState.BeHit);
      
    }



    public void ProcessStamina()
    {

        if (feature1 == "Heal")
        {
            Heal();

        }
        else if (feature1 == "Invincible")
        {

            Invincible();

        }
        else if (feature1 == "Blink")
        {

            Blink();
           
        }


        currentSP = 0;

    }







    public void Revive()
    {
        if (feature2 >= 0)//riviveable times
        {
            feature2--;
            currentHp = maxHp;

            colorModified *= 0.3f;
            monsterSprite.color = new Color(colorModified, colorModified, colorModified);

            SetState(CharacterState.Idle);
        }
        if (feature2 < 0)
        {
            Destroy(gameObject);
        }
       


    }

    public void Split()
    {
        Vector3 splitPos = transform.position;
        Vector3 storePos = splitPos;
        splitMonster.GetComponent <MonsterFSM>().no = no;
        splitMonster.GetComponent <MonsterFSM>().monsterLevel = monsterLevel;
        splitMonster.GetComponent<MonsterFSM>().elite = elite;
        for (int i = 0; i < 2; i++)
        {
            splitPos.x += ((-1.0f + ((float)i * 2.0f)) * (0.35f*(elite)));
   

            Instantiate(splitMonster, splitPos, transform.rotation);
            splitPos = storePos;
        }

    }


    public void Blink()//blink interval
    {
        float a = Random.Range(-2.5f, 2.5f);
        Vector3 blinkPos = new Vector3(a, my.position.y + 1.0f, 0.0f);
        transform.position = blinkPos;
        monsterSprite.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public void Heal()
    {
        if (currentHp < maxHp - healHP)
        {

            currentHp += healHP;
           
        }


    }

    public void Block(float __damage)
    {
        if (Random.Range(0.0f, 100.0f) >= feature2)
        {
            __damage *= 0.5f;

        }
           
    }

    //    public void Reflect() //in the bulletmoveScript
    //    {
    //
    //
    //
    //    }

    public void Invincible()
    {
        if (!isInvincible)
        {
            isInvincible = true;
            monsterSprite.color = new Color(0.3f, 0.3f, 0.8f, 0.8f);
            currentSP = (maxSP*2/3);


        }
        else if (isInvincible)
        {
            isInvincible = false;
            monsterSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    
        }


    }












    //






    //IEnumerator

    protected override IEnumerator Idle()
    {
        do
        {

            yield return null;

            SetState(CharacterState.Run);


        } while(state == CharacterState.Idle);

    }

    IEnumerator Run()
    {
        do
        {
            if (currentHp <= 0)
            {
                isKilled = true;
                SetState(CharacterState.Dead);

            }

            yield return null;

            transform.Translate(-transform.up * moveSpeed * Time.deltaTime);

         

        } while(state == CharacterState.Run);

    }

    IEnumerator BeHit()
    {
        float timeSpan = 0.0f;
        float checkTime = KnockbackTime;


        do
        {

            yield return null;

            timeSpan += Time.deltaTime;

            transform.Translate(transform.up * knockbackSpeed * Time.deltaTime);


        

            if (checkTime <= timeSpan)
            {
                //timeSpan = 0.0f;
  
                SetState(CharacterState.Run);

            }

         

        } while(state == CharacterState.BeHit);

    }

    IEnumerator Dead()
    {

        if (feature1 == "Revive")
        {

            Revive();
           
        }
        else if (feature1 == "Split")
        {
            if (!isSplit)
            {
                Split();
                isSplit = true;
            }
            else if (isSplit)
            {
                Destroy(gameObject);
            }
       
        }
        else
        {
       
            Destroy(gameObject);
        }
        yield return null;// new WaitForSeconds(3.0f);

       
    }

}