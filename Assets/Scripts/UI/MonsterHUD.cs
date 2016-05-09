using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonsterHUD : MonoBehaviour
{



    public Image hpBar;
    public Image spBar;
    public Image figure;
    public Text hpText;
    public Text lvText;
    public Text nameText;
    public Image elite1;
    public Image elite2;


    public float currentHP;
    public float maxHP;
    public float currentSP;
    public MonsterFSM monsterFSM;
    public GameObject hud;

    void OnEnable()
    {
        hud = GameObject.FindGameObjectWithTag("HUD");
        hpBar.fillAmount = 1.0f;

        hud.SetActive(false);
    }

    void Update()
    {
        if (monsterFSM == null)
        {
            hpBar.fillAmount = 0.0f;
            spBar.fillAmount = 0.0f;
            hpText.text = "0/" + maxHP.ToString();
            hud.SetActive(false);
        }
        else
        {

            hpBar.fillAmount = currentHP / maxHP;
            spBar.fillAmount = currentSP / 1.5f;

            currentSP = monsterFSM.currentSP;
            currentHP = monsterFSM.currentHp;
            maxHP = monsterFSM.maxHp;
            hpText.text = currentHP.ToString() + "/" + maxHP.ToString();
        }


    }

    public void SelectMonster(MonsterFSM _monsterFSM)
    {
        hud.SetActive(true);

        monsterFSM = _monsterFSM;

        figure.sprite = monsterFSM.monsterSprite.sprite;
        lvText.text = monsterFSM.monsterLevel.ToString();
        nameText.text = monsterFSM.monsterName;
        if (monsterFSM.elite > 1)
        {
            elite1.enabled = true;
            if (monsterFSM.elite > 2)
            {
                elite2.enabled = true;
            }
        }
        else
        {
            elite1.enabled = false;
            elite2.enabled = false;
        }


        hpBar.fillAmount = 1.0f;
        spBar.fillAmount = 0.0f;

    }

 

}
