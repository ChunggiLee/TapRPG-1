using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    

    public GameObject spawningMonster;
    public float gridX = 0.75f;
    public float gridY = 5.0f;
    public int step = 1;
    public int level = 1;

    public StageData.Stage _stageData;

    void Awake()
    {
        _stageData = DataManager.Instance.stageData.list[step - 1];

       
    }

    public void CreateStage()
    {
        _stageData = DataManager.Instance.stageData.list[(int)Random.Range(0, 10.0f)];
       //그리드를 WorldToScreenPoint로 바꿔주기ㅁ
        for (int i = 0; i < 7; i++)
        {
            if (_stageData.pos[i] != 0)
            {
                Vector3 SpawnPos = new Vector3((i-3) * gridX, gridY, 0);
                spawningMonster.GetComponent<MonsterFSM>().monsterLevel = level;
                spawningMonster.GetComponent<MonsterFSM>().no = step;
                spawningMonster.GetComponent<MonsterFSM>().elite = _stageData.pos[i];
                Instantiate(spawningMonster, SpawnPos, Quaternion.Euler(0, 0, 0));

            }

        }



        step++;

        if (step > 34)
        {
            step = 1;
            level++;
        }

    }

}
