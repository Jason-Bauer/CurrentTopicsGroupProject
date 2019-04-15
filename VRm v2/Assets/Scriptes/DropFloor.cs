using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFloor : MonoBehaviour
{
    public GameObject floor;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop()
    {
        floor.SetActive(false);
        coroutine = Comeback();
        StartCoroutine(coroutine);

    }
    IEnumerator Comeback()
    {

        yield return new WaitForSeconds(4);
        floor.SetActive(true);
    }
}
