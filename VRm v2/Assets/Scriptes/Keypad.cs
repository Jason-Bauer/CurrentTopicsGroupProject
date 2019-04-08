using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{

    public Queue<int> keypadStorage = new Queue<int>();
    public GameObject target,target1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addnum(int i)
    {
        keypadStorage.Enqueue(i);
        Debug.Log(i);
    }
    public void clearkeypad()
    {
        keypadStorage.Clear();
    }
    public void checkcombo()
    {
        if (keypadStorage.Dequeue() == 8)
        {
            if (keypadStorage.Dequeue() == 6)
            {
                if (keypadStorage.Dequeue() == 7)
                {
                    if (keypadStorage.Dequeue() == 5)
                    {
                        if (keypadStorage.Dequeue() == 3)
                        {
                            if (keypadStorage.Dequeue() ==0)
                            {
                                if (keypadStorage.Dequeue() == 9)
                                {
                                    target.gameObject.SetActive(false);
                                    Debug.Log("Moving Doors");
                                    target.gameObject.transform.Translate(new Vector3(0, 1.2f,0 ));
                                    target1.gameObject.transform.Translate(new Vector3(0, -1.2f, 0));
                                    target1.gameObject.SetActive(false);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void Dooropen(GameObject door)
    {
        door.gameObject.SetActive(false);
    }
}
