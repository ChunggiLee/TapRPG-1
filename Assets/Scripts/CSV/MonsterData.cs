using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterData : ScriptableObject {
    [System.Serializable]
    public class Attribute
    {
        public string name;
        public int stage;
        public int no;
        public int maxHP;
        public float moveSpeed;
        public string feature1;
        public float feature2;
        public int crowdUp = 5;
        public int crowdMax = 30;
    }

    public List<Attribute> list = new List<Attribute>();
}
