using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

//TODO rename PointerCube to HandMatch raycast something or other
//Determines whether a cube should be activated, external logic is handled in parent object PointerCubeGroup
public class PointerCube : MonoBehaviour
{
    //Which hand should this PointerCube listen for?
    [SerializeField]
    private Hand matchHand;
    
    private bool activated;

    public bool Activated
    {
        get { return activated; }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(matchHand.transform.position,matchHand.transform.TransformDirection(Vector3.forward), out hit, 30.0f))
        {
            if(hit.transform == transform)
            {
                activated = true;
            }
            else
            {
                activated = false;
            }
        }
        else
        {
            activated = false;
        }
    }
}
