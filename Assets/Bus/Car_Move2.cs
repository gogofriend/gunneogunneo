using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move2 : MonoBehaviour
{

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (new Vector3(10, 0, 0) * Time.deltaTime);
        pos = gameObject.transform.position;

        if (pos.x < -28)
            pos.x = 20;


        gameObject.transform.position = pos;

    }
}
