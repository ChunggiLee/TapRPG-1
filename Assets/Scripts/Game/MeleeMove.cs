using UnityEngine;
using System.Collections;

public class MeleeMove : MonoBehaviour {
    public float weaponLifeTime= 0.35f;

    public float brandishSpeed = 650.0f;
    public float stabSpeed;

    public PlayerManager playerManager;
    public float timeSpan = 0.0f;



    private Transform my;

    private Transform axeWeapon;
    private Transform boweWeapon;
    private Transform clawWeapon;
    private Transform daggerWeapon;
    private Transform katarWeapon;
    private Transform maceWeapon;
    private Transform spearWeapon;
    private Transform staffWeapon;
    private Transform swordWeapon;
    private Transform wandWeapon;
    private Transform shieldWeapon;

    private string axePath;
    private string bowPath;
    private string clawPath;
    private string daggerPath;
    private string katarPath;
    private string macePath;
    private string spearPath;
    private string staffPath;
    private string swordPath;
    private string wandPath;
    private string shieldPath;

    void OnEnable()
    {
        my = gameObject.GetComponent <Transform>();
        playerManager = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<PlayerManager>();
       
        InitialiseWeapon();

        my.rotation = Quaternion.Euler(0, 0, -90.0f);

     
    }

    void Update()
    {
      
        my.Rotate(0,0, brandishSpeed * Time.deltaTime);

        timeSpan += Time.deltaTime; 


        if (timeSpan >= weaponLifeTime)
        {
            brandishSpeed = 0;
            Destroy(gameObject, 0.15f);

        }
    }

    void OnTriggerEnter2D(Collider2D _hit)
    {
        playerManager.monsterFSM = _hit.GetComponent<MonsterFSM>();
        playerManager.monsterFSM.ProcessDamage(playerManager.CalCulateDamage());

    }

    void InitialiseWeapon()
    {
        axePath= "Weapon/Axe/Axe" + playerManager.a.ToString();
        bowPath= "Weapon/Bow/Bow" + playerManager.a.ToString(); 
        clawPath= "Weapon/Claw/Claw" + playerManager.a.ToString();
        daggerPath= "Weapon/Dagger/Dagger" + playerManager.a.ToString();
        katarPath= "Weapon/Katar/Katar" + playerManager.a.ToString();
        macePath= "Weapon/Mace/Mace" + playerManager.a.ToString();
        spearPath= "Weapon/Spear/Spear" + playerManager.a.ToString();
        staffPath= "Weapon/Staff/Staff" + playerManager.a.ToString();
        swordPath= "Weapon/Sword/Sword" + playerManager.a.ToString();
        wandPath= "Weapon/Wand/Wand" + playerManager.a.ToString();
        shieldPath= "Weapon/Shield/Shield" + playerManager.a.ToString();


        axeWeapon= my.FindChild("Brandish").FindChild("Axe");
        boweWeapon= my.FindChild("Brandish").FindChild("Bow");
        clawWeapon= my.FindChild("Brandish").FindChild("Claw");
        daggerWeapon= my.FindChild("Brandish").FindChild("Dagger");
        katarWeapon= my.FindChild("Brandish").FindChild("Katar");
        maceWeapon= my.FindChild("Brandish").FindChild("Mace");
        spearWeapon= my.FindChild("Brandish").FindChild("Spear");
        staffWeapon= my.FindChild("Brandish").FindChild("Staff");
        swordWeapon= my.FindChild("Brandish").FindChild("Sword");
        wandWeapon= my.FindChild("Brandish").FindChild("Wand");
        shieldWeapon= my.FindChild("Brandish").FindChild("Shield");



        axeWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(axePath);
        boweWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(bowPath);
        clawWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(clawPath);
        daggerWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(daggerPath);
        katarWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(katarPath);
        maceWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(macePath);
        spearWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(spearPath);
        staffWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(staffPath);
        swordWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(swordPath);
        wandWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(wandPath);
        shieldWeapon.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>(shieldPath);


        axeWeapon.gameObject.SetActive(false);
        boweWeapon.gameObject.SetActive(false);
        clawWeapon.gameObject.SetActive(false);
        daggerWeapon.gameObject.SetActive(false);
        katarWeapon.gameObject.SetActive(false);
        maceWeapon.gameObject.SetActive(false);
        spearWeapon.gameObject.SetActive(false);
        staffWeapon.gameObject.SetActive(false);
        swordWeapon.gameObject.SetActive(false);
        wandWeapon.gameObject.SetActive(false);
        shieldWeapon.gameObject.SetActive(false);


        if (playerManager.wState == WeaponState.axe)
        {
            axeWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.bow)
        {
            boweWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.claw)
        {
            clawWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.dagger)
        {
            daggerWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.katar)
        {
            katarWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.mace)
        {
            maceWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.spear)
        {
            spearWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.staff)
        {
            staffWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.sword)
        {
            swordWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.wand)
        {
            wandWeapon.gameObject.SetActive(true);
        }
        else if (playerManager.wState == WeaponState.shield)
        {
            shieldWeapon.gameObject.SetActive(true);
        }


    }

}
