using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerCubeGroup : MonoBehaviour
{
    [SerializeField]
    private List<PointerCube> triggers;
    public Action TriggerHandMatchEvent;
    private bool eventTriggered = false;
    private bool shouldTrigger = true;

    private void Awake()
    {
        TriggerHandMatchEvent += LogEventTriggered;
    }

    private void OnDestroy()
    {
        TriggerHandMatchEvent -= LogEventTriggered;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggers.Count < 1)
            return;

        shouldTrigger = true;   
        for (int i = 0; i < triggers.Count; i++)
        {
            if (!triggers[i].Activated)
                shouldTrigger = false;
        }

        if(shouldTrigger)
        {
           TriggerHandMatchEvent?.Invoke();
        }
    }

    private void LogEventTriggered()
    {
        Debug.Log("Event Triggered");
    }
}
