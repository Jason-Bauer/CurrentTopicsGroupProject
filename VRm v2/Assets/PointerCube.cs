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

    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(matchHand.transform.position,matchHand.transform.TransformDirection(Vector3.forward), out hit, 30.0f))
        {
            if(hit.transform == transform)
            {
                activated = true;
                meshRenderer.material = correctMat;
            }
            else
            {
                activated = false;
                meshRenderer.material = defaultMat;
            }
        }
        else
        {
            activated = false;
            meshRenderer.material = defaultMat;
        }
    }
}
