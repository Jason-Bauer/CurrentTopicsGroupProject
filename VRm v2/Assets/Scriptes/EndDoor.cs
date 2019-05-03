using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject green1;
    public GameObject green2;
    //public GameObject green3;
    public GameObject greenEnd1;
    public GameObject greenEnd2;
    public GameObject greenEnd3;
    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(button1.GetComponent<Valve.VR.InteractionSystem.Sample.ButtonEffect>().isPressed && 
            button2.GetComponent<Valve.VR.InteractionSystem.Sample.ButtonEffect>().isPressed && 
            button3.GetComponent<Valve.VR.InteractionSystem.Sample.ButtonEffect>().isPressed)
        {
            win.GetComponent<SpriteRenderer>().enabled = true;
        }

        if(button1.GetComponent<Valve.VR.InteractionSystem.Sample.ButtonEffect>().isPressed)
        {
            green1.GetComponent<SpriteRenderer>().enabled = true;
            greenEnd1.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (button2.GetComponent<Valve.VR.InteractionSystem.Sample.ButtonEffect>().isPressed)
        {
            greenEnd2.GetComponent<SpriteRenderer>().enabled = true;
            green2.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (button3.GetComponent<Valve.VR.InteractionSystem.Sample.ButtonEffect>().isPressed)
        {
            greenEnd3.GetComponent<SpriteRenderer>().enabled = true;
            //green3.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
