using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{

    public GameObject item1 = null;
    public GameObject item2 = null;
    public GameObject item3 = null;
    public GameObject item4 = null;
    float TimeLeft = 5.0f;
    float nextTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            item();
        }
    }

    public void item()
    {
        int random = Random.Range(0, 5);


        if (random == 1)
        {
            if (item1 != null)
            {
                GameObject Item1 = GameObject.Instantiate(item1);
                Item1.transform.position = transform.position;
                Item1.transform.parent = null;
            }
        }
        if (random == 2)
        {
            if (item2 != null)
            {
                GameObject Item2 = GameObject.Instantiate(item2);
                Item2.transform.position = transform.position;
                Item2.transform.parent = null;
            }
        }
        if (random == 3)
        {
            if (item3 != null)
            {
                GameObject Item3 = GameObject.Instantiate(item3);
                Item3.transform.position = transform.position;
                Item3.transform.parent = null;
            }
        }
        if (random == 4)
        {
            if (item4 != null)
            {
                GameObject Item4 = GameObject.Instantiate(item4);
                Item4.transform.position = transform.position;
                Item4.transform.parent = null;
            }
        }
    }
}