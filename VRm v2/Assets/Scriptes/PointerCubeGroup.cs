using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointerCubeGroup : MonoBehaviour
{
    [SerializeField]
    private List<PointerCube> triggers;
    private bool eventTriggered = false;
    private bool shouldTrigger = true;
    public UnityEvent uEvent;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if(triggers.Count < 1)
                return;

            shouldTrigger = true;
            for(int i = 0; i < triggers.Count; i++)
            {
                if(!triggers[i].Activated)
                    shouldTrigger = false;
            }

            if(shouldTrigger)
            {
                uEvent?.Invoke();
            }
        }
    }
}
