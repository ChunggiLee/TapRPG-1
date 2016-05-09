using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour
{

    protected static DataManager instance;
    public PlayerData playerData;
    public MonsterData monsterData;
    public StageData stageData;

    public static string nextSceneName;

    public static DataManager Instance
    {
        get
        { 
            return instance;
        }

    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            playerData = Resources.Load("Data/PlayerData")as PlayerData;
            monsterData = Resources.Load("Data/MonsterData")as MonsterData;
            stageData = Resources.Load("Data/StageData")as StageData;
        }
        else
        {
            Destroy(gameObject);
        }





    }


}
