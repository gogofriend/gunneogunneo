using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
          GameObject[] objArray = GameObject.FindGameObjectsWithTag("Car");
          GameObject[] objArray2 = GameObject.FindGameObjectsWithTag("Car2");

            for (int i = 0; i < objArray.Length; i++)
            {
                objArray[i].gameObject.GetComponent<Car_Move>().enabled = true;
                objArray[i].gameObject.GetComponent<Car_Move2>().enabled = false;
            }
            for (int i = 0; i < objArray2.Length; i++)
            {
           
                objArray2[i].gameObject.GetComponent<Car_Move>().enabled = false;
                objArray2[i].gameObject.GetComponent<Car_Move2>().enabled = true;
               
            }
        
        

    }

    // Update is called once per frame
    void Update()
    {
      

    }
}
