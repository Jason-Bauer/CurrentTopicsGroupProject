using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwap : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject object1;
    [SerializeField]
    private GameObject object2;
    [SerializeField]
    private float angleMin;
    [SerializeField]
    private float angleMax;

    private bool switched;

    [SerializeField]
    private bool debugNoVR = false;
    //[SerializeField]
    //private GameObject fallbackPlayer;

    //private void Awake()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //}

    private void Start()
    {
        //if (debugNoVR)
        //    player = fallbackPlayer;

        if (player.transform.rotation.eulerAngles.y < angleMin ||
            player.transform.rotation.eulerAngles.y > angleMax)
        {
            switched = true;
            object1.SetActive(false);
            object2.SetActive(true);
        }
        else
        {
            switched = false;
            object1.SetActive(true);
            object2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!switched &&
            (player.transform.rotation.eulerAngles.y < angleMin ||
            player.transform.rotation.eulerAngles.y > angleMax))
        {
            switched = true;
            object1.SetActive(false);
            object2.SetActive(true);

        }
        else if(switched &&
            player.transform.rotation.eulerAngles.y > angleMin &&
            player.transform.rotation.eulerAngles.y < angleMax)
        {
            switched = false;
            object1.SetActive(true);
            object2.SetActive(false);
        }
    }
}
