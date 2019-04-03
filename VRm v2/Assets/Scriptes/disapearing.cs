using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disapearing : MonoBehaviour {
    public Camera cam;
    float timer = 0;
    public bool swapped = true;
    bool canswap = true;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (!this.gameObject.GetComponent<Renderer>().isVisible&&canswap)
        {
           // Debug.Log("is visible");
            canswap = false;
            swap();
            
            //this.gameObject.SetActive(true);
        }
        else if(this.gameObject.GetComponent<Renderer>().isVisible)
        {
            //Debug.Log("is visible");
            canswap = true;
        }
       

      /*  if (!IsInView(cam.gameObject, this.gameObject))
        {
            //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            timer += Time.deltaTime;
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            timer = 0;
        }
        if (timer > 2)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }*/
	}
    public void swap()
    {
        if (swapped)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(.1f, .1f, .1f, 1);
            this.gameObject.GetComponent<Collider>().enabled = true;
            swapped = false;
        }
        else if (!swapped)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0);
            this.gameObject.GetComponent<Collider>().enabled = false;
            swapped = true;
        }
        //this.gameObject.GetComponent<Renderer>().material.color = new Color(.1f, .1f, .1f, 1);

    }
    private bool IsInView(GameObject origin, GameObject toCheck)
    {
        Vector3 pointOnScreen = cam.WorldToScreenPoint(toCheck.GetComponentInChildren<Renderer>().bounds.center);

        //Is in front
        if (pointOnScreen.z < 0)
        {
            Debug.Log( toCheck.name+" is in front of cam");
            return false;
        }

       //Is in FOV
       else if ((pointOnScreen.x < 0) || (pointOnScreen.x > Screen.width) ||
                (pointOnScreen.y < 0) || (pointOnScreen.y > Screen.height))
        {
            Debug.Log( toCheck.name+ " is in view " );
            return false;
        }
        else
        {
            return true;
        }

        RaycastHit hit;
        Vector3 heading = toCheck.transform.position - origin.transform.position;
        Vector3 direction = heading.normalized;// / heading.magnitude;

        if (Physics.Linecast(cam.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, out hit))
        {
            if (hit.transform.name != toCheck.name)
            {
                /* -->
                Debug.DrawLine(cam.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, Color.red);
                Debug.LogError(toCheck.name + " occluded by " + hit.transform.name);
                */
                Debug.Log(toCheck.name + " occluded by " + hit.transform.name);
                return false;
            }
        }
        return true;
    }
}
