using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPuzzleRotate : MonoBehaviour
{
    public static Action Rotate;
    
    [SerializeField]
    private float timeToRotate = 5.0f;

    private bool rotated;
    private bool running = false;

    private Vector3 currentRotation;
    private Vector3 targetRotation = new Vector3(0, 0, -90.0f);
    
    private void Start()
    {
        Rotate += StartRotation;
    }
    
    public void StartRotation()
    {
        if(running)
            return;
        StartCoroutine(SlowRotate());
    }

    private IEnumerator SlowRotate()
    {
        running = true;
        float timer = 0.0f;
        while(timer < timeToRotate)
        {
            if(!rotated)
            {
                transform.eulerAngles = (Vector3.Lerp(Vector3.zero, targetRotation, timer / timeToRotate));
            }
            else
            {
                transform.eulerAngles = (Vector3.Lerp(targetRotation, Vector3.zero, timer / timeToRotate));
            }
            timer += Time.deltaTime;
            yield return null;
        }
        rotated = !rotated;
        running = false;
    }
}
