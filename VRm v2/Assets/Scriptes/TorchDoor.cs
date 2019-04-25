using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchDoor : MonoBehaviour
{
    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;
    public GameObject torch4;
    

    // Start is called before the first frame update
    void Start()
    {
        torch1 = GameObject.Find("Head (1)");
    }

    // Update is called once per frame
    void Update()
    {
        if(torch1.GetComponent<Valve.VR.InteractionSystem.FireSource>().isBurning && torch2.GetComponent<Valve.VR.InteractionSystem.FireSource>().isBurning && torch3.GetComponent<Valve.VR.InteractionSystem.FireSource>().isBurning && torch4.GetComponent<Valve.VR.InteractionSystem.FireSource>().isBurning)
        {
            Debug.Log("DOOR WILL OPEN");
        }
    }
}
