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
    private Valve.VR.SteamVR_Input_Sources matchHand;
    //Is the correct hand pointing at this cube?
    [SerializeField]
    private Material defaultMat;
    [SerializeField]
    private Material correctMat;

    private MeshRenderer meshRenderer;

    private bool activated;

    public bool Activated
    {
        get { return activated; }
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnHandHoverBegin(Hand hand)
    {
        if (hand.handType == matchHand)
        {
            activated = true;
            meshRenderer.material = correctMat;
        }
    }
    
    private void OnHandHoverEnd(Hand hand)
    {
        if (hand.handType == matchHand && activated)
        {
            activated = false;
            meshRenderer.material = defaultMat;
        }
    }
}
