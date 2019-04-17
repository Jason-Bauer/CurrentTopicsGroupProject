using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{

    public Queue<int> keypadStorage = new Queue<int>();
    public GameObject target,target1,Door;
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
                                    
                                    Debug.Log("Moving Doors");
                                    Door.GetComponent<Animator>().SetTrigger("character_nearby");
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
