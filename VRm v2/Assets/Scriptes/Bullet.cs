using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 forward;
    public float lifetime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > 4)
        {
            Destroy(this.gameObject);
        }
        this.gameObject.transform.Translate(-forward*Time.deltaTime*5);
    }
}
