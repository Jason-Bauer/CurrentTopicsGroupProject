using System.Collections;
using UnityEngine;
using Valve.VR;

public class TransportPlayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is the transform the player will be moved to after activating a pillar pointed at this one")]
    private GameObject thisTransform;
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

    private bool hovering;

    private LineRenderer line;

    private void Awake()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

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
        if (grabPinch != null)
        {
            grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }

    private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if(newState && hovering)
        {
            line.enabled = true;
            StartCoroutine(DelayedLineDisable());
            //start coroutine lerp player transform to target transform
            RaycastHit hit;
            if(Physics.Raycast(transform.position + transform.up, transform.up, out hit))
            {
                if(hit.transform.tag=="pillar" && hit.transform != this.transform)
                {
                    hit.transform.gameObject.GetComponent<TransportPlayer>().StartLerpPlayer();
                }
            }
        }
    }

    private IEnumerator DelayedLineDisable()
    {
        yield return new WaitForSeconds(0.5f);
        line.enabled = false;
    }

    public void StartLerpPlayer()
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
        line = GetComponent<LineRenderer>();
    }

    //private void Update()
    //{
    //    Debug.DrawRay(transform.position, transform.up, Color.green,Time.deltaTime);
    //}

    private IEnumerator LerpPlayer()
    {
        duration = Vector3.Distance(player.transform.position, thisTransform.transform.position);
        duration /= 8.0f;
        startPos = player.transform.position;
        startRot = player.transform.rotation.eulerAngles;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            rPos = Vector3.Lerp(startPos, thisTransform.transform.position, timer / duration);
            rRot = Vector3.Lerp(startRot, thisTransform.transform.rotation.eulerAngles, timer / duration);
            player.transform.position = rPos;
            player.transform.eulerAngles = rRot;
            yield return null;
        }

        timer = 0.0f;
    }


}
