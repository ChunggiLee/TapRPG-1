using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIClick : MonoBehaviour
{
    public GameObject Building;

    void awake()
    {
        Building.active = false;
    }

    public void BuildingSetActive()
    {
        Building.SetActive(!Building.active);
    }
}
