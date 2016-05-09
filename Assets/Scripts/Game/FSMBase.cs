using UnityEngine;
using System.Collections;

public class FSMBase : MonoBehaviour
{
    
    public CharacterState state;


    protected virtual void Awake()
    {

    }

    protected virtual void OnEnable()
    {
        SetState(CharacterState.Idle);
        StartCoroutine(FSMMain());
    }

    protected IEnumerator FSMMain()
    {
        while (true)
        {

            yield return StartCoroutine(state.ToString());
        }

    }

    public void SetState(CharacterState newState)
    {

        state = newState;


    }

    protected virtual IEnumerator Idle()
    {
        do
        {

            yield return null;




        } while(state == CharacterState.Idle);


    }


}
