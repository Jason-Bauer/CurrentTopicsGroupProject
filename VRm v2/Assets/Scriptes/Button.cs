using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;
    Valve.VR.InteractionSystem.Sample.ButtonEffect btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ColorSelf(Color.cyan);
        transform.position = new Vector3(10f, 1.795f, -10.167f);
        door.GetComponent<Animator>().SetTrigger("character_nearby");
    }

    private void ColorSelf(Color newColor)
    {
        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
        {
            renderers[rendererIndex].material.color = newColor;
        }
    }
}
