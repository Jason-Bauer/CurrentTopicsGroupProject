using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPuzzleInvokeRotation : MonoBehaviour
{
    public void InvokeRotation()
    {
        PillarPuzzleRotate.Rotate?.Invoke();
    }
}
