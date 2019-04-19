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

    private float timer = 0.0f;
    private float duration;

    private Vector3 startPos;
    private Vector3 startRot;

    [SerializeField]
    private bool debug;
    [SerializeField]
    private GameObject debugPlayer;

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
            StartCoroutine(LerpPlayer());
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine(LerpPlayer());
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
        if (player == null)
            GameObject.FindGameObjectWithTag("Player");
        if (debug)
            player = debugPlayer;
    }

    IEnumerator LerpPlayer()
    {
        duration = Vector3.Distance(player.transform.position, targetTransform.transform.position);
        duration /= 8.0f;
        startPos = player.transform.position;
        startRot = player.transform.rotation.eulerAngles;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            rPos = Vector3.Lerp(startPos, targetTransform.transform.position, timer / duration);
            rRot = Vector3.Lerp(startRot, targetTransform.transform.rotation.eulerAngles, timer / duration);
            player.transform.position = rPos;
            player.transform.eulerAngles = rRot;
            yield return null;
        }

        timer = 0.0f;
    }


}
