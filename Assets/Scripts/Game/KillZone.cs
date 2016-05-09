using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour
{
    
    public int killZoneNum = 0;

    void OnTriggerStay2D(Collider2D _hit)
    {
        if (_hit.tag == "Monster")
        {
            _hit.GetComponent<MonsterFSM>().SetState(CharacterState.Dead);
            if (_hit.GetComponent<MonsterFSM>().isSplit == false)
            {
                killZoneNum++;
            }
        }
    }
}
