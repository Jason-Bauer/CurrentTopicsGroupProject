using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPuzzleInvokeRotation : MonoBehaviour
{
    public void InvokeRotation()
    {
        if(PillarPuzzleRotate.Rotate!=null)
            PillarPuzzleRotate.Rotate.Invoke();
    }
}
