using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageData : ScriptableObject {
    [System.Serializable]
    public class Stage
    {
        public int type;
        public int []pos =new int[7];
//        public int pos0;
//        public int pos1;
//        public int pos2;
//        public int pos3;
//        public int pos4;
//        public int pos5;
//        public int pos6;
    }

    public List<Stage> list = new List<Stage>();
}
