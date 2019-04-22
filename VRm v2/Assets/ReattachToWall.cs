using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReattachToWall : MonoBehaviour
{
    public float LeftBound;
    public float RightBound;
    public float UpperBound;
    public float LowerBound;
    public float ZValue;

    private Quaternion rotation;

    private void Start()
    {
        rotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = rotation;
        
    }

    public void Reattach()
    {
        Vector3 pos = transform.localPosition;
        if (pos.x < LeftBound)
            pos.x = LeftBound;
        if (pos.x > RightBound)
            pos.x = RightBound;
        if (pos.y > UpperBound)
            pos.y = UpperBound;
        if (pos.y < LowerBound)
            pos.y = LowerBound;
        pos.z = ZValue;
        transform.localPosition = pos;
        
    }
}
