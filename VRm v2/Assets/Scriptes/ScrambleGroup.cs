using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrambleGroup : MonoBehaviour
{

    public static Action IncrementSolved;
    private int nSolved = 0;

    [SerializeField]
    private List<GameObject> scramblePieces;
    [SerializeField]
    private GameObject solvedWheel;


    private void Awake()
    {
        IncrementSolved += Increment;
    }

    private void OnDestroy()
    {
        IncrementSolved -= Increment;
    }

    private void Increment()
    {
        nSolved++;
        if(nSolved == scramblePieces.Count)
        {
            solvedWheel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
