using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TransportPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject targetTransform;
    [SerializeField]
    private GameObject player;

    private Vector3 rPos;
    private Vector3 rRot;

    public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspector
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
                                                                         // Use this for initialization

    void OnEnable()
    {
        if (grabPinch != null)
        {
            grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }

    private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if(newState)
        {
            //start coroutine lerp player transform to target transform
        }
    }

    private void OnDisable()
    {
        if (grabPinch != null)
        {
            grabPinch.RemoveOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.LeftEye);

        if (player == null)
            GameObject.FindGameObjectWithTag("Player");
    }




}
