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

    private bool triggered = false;

    private void Update()
    {
        if(triggered)
            return;
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
            triggered = true;
        }
    }
}
