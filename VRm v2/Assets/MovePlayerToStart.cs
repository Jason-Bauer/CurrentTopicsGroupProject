using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToStart : MonoBehaviour
{
    [SerializeField]
    private GameObject startTransform;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void MovePlayer()
    {
        player.transform.position = startTransform.transform.position;
        player.transform.rotation = startTransform.transform.rotation;
    }
}
