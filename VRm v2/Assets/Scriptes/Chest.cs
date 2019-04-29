using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool open = false;
    GameObject hinge;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GameObject.Find("pivot");
        sound = GetComponent<AudioSource>();
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
            sound.Play();
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
