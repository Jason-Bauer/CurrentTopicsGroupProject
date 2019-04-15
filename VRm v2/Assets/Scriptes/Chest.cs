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
        hinge = GameObject.Find("pivot");
    }

    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            if (hinge.transform.rotation.x <= .6f)
            {
                hinge.transform.Rotate(- 1f, 0f, 0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "key")
        {
            open = true;
        }
    }

}
