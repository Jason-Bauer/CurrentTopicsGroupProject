using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ScramblePieces : MonoBehaviour
{
    public float leftBound = -.8f;
    public float rightBound = .8f;
    public float upperBound = .8f;
    public float lowerBound = -.8f;
    public float zValue = 0;

    public float centerX = 0.107f;
    public float centerY = -.005f;

    public float snapDistance = 0.08f;

    private Vector3 solutionPoint;

    // Start is called before the first frame update
    void Start()
    {
        solutionPoint = transform.localPosition;
        //Randomize location
        Vector3 newPos = solutionPoint;
        //Hardcoded center of wheel
        newPos.x = centerX + Random.Range(leftBound, rightBound);
        newPos.y = centerY + Random.Range(lowerBound, upperBound);
        transform.localPosition = newPos;
    }
    
    public void CheckCorrect()
    {
        if(Vector2.Distance(transform.localPosition,solutionPoint) < snapDistance)
        {
            OnSolved();
        }
    }

    private void OnSolved()
    {
        transform.localPosition = solutionPoint;
        if(ScrambleGroup.IncrementSolved!=null)
            ScrambleGroup.IncrementSolved.Invoke();
        Destroy(GetComponent<Throwable>());
        Destroy(GetComponent<VelocityEstimator>());
        Destroy(GetComponent<Interactable>());
    }
}
