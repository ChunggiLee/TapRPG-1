using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerData : ScriptableObject {
    [System.Serializable]
    public class Attribute
    {
        public int level;
        public int gold;
        public int maxHP;
        public float baseAttack;
        public int reqExp;
        public float BulletmoveSpeed = 3f;
        public float BulletturnSpeed = 360f;
        public float attackRange = 1.5f;
    }

    public List<Attribute> list = new List<Attribute>();
}