using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool open = false;
    GameObject hinge;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GameObject.Find("Hinge");
        open = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            hinge.transform.Rotate(0f, 0f, hinge.transform.rotation.z + 1);
        }
    }

    void Open()
    {
        
        
    }
}
