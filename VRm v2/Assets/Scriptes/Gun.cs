using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class Gun : MonoBehaviour
    {
        public GameObject bullet;
        public GameObject bulletholder;
        public bool reset = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (this.gameObject.GetComponent <LinearMapping>().value>=.8 && !reset)
            {
                shoot();
                reset = true;
            }
            else if(reset && this.gameObject.GetComponent<LinearMapping>().value <= .5)
            {
                reset = false;
            }
        }
        public void shoot()
        {
            GameObject b1 = Instantiate(bullet, bulletholder.transform);
            b1.transform.position = this.gameObject.transform.position;
            b1.GetComponent<Bullet>().forward = this.transform.right;
        }
    }
}
