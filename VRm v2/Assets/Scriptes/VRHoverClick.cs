using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class VRHoverClick : MonoBehaviour
{
    public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspector
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller

    private bool hovering;

    public UnityEvent unityEvent;

    private void OnHandHoverBegin()
    {
        hovering = true;
    }

    private void OnHandHoverEnd()
    {
        hovering = false;
    }

    void OnEnable()
    {
        if(grabPinch != null)
        {
            grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }
    private void OnDisable()
    {
        if(grabPinch != null)
        {
            grabPinch.RemoveOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }

    private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if(newState && hovering)
        {
            if(unityEvent!=null)
                unityEvent.Invoke();
        }
    }

}
