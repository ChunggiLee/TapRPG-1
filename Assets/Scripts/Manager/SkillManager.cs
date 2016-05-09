using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour {

    public Transform[] multiShotPivot= new Transform[3];


    void OnEnable()
    {
        for(int i =0;i<multiShotPivot.Length;i++)
        {
           // multiShotPivot[i] = new Transform;
        }
    }


    void Update()
    {


    }


}
