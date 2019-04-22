using System.Collections;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(TeleportArea))]
public class HidePlane : MonoBehaviour
{
    [SerializeField]
    private float disappearDistance = 4.0f;
    private GameObject player;
    private TeleportArea teleportArea;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        teleportArea = GetComponent<TeleportArea>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < disappearDistance)
        {
            teleportArea.SetLocked(false);
        }
        else
        {
            teleportArea.SetLocked(true);
        }
    }

    //private IEnumerator SlowUpdate()
    //{
    //    while(true)
    //    {
    //        if(Vector3.Distance(transform.position, player.transform.position) < disappearDistance) 
    //        {
    //            teleportArea.SetLocked(false);
    //        }
    //        else
    //        {
    //            teleportArea.SetLocked(true);
    //        }
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //}
}
