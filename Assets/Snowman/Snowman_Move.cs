using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman_Move : MonoBehaviour
{
    float startTime;
    float finishTime;
    bool reverse;
    bool time;

    Vector3 pos;
    float step = 2;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        reverse = false;
        time = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reverse == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                pos += transform.forward * step;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                pos += transform.forward * step;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                pos += transform.forward * step;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                pos += transform.forward * step;
            }
        }
        if (reverse)
        {
            startTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                pos += transform.forward * step;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                pos += transform.forward * step;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                pos += transform.forward * step;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                pos += transform.forward * step;
            }
            if (startTime >= finishTime)
            {
                reverse = false;
            }
        }
        if (time)
        {

            startTime += Time.deltaTime;

            GameObject[] objArray = GameObject.FindGameObjectsWithTag("Car");
            GameObject[] objArray2 = GameObject.FindGameObjectsWithTag("Car2");

            for (int i = 0; i < objArray.Length; i++)
                objArray[i].gameObject.transform.position -= (new Vector3(10, 0, 0) * Time.deltaTime);
            for (int i = 0; i < objArray2.Length; i++)
                objArray2[i].gameObject.transform.position += (new Vector3(10, 0, 0) * Time.deltaTime);

            if (startTime >= finishTime)
            {
                time = false;
            }
        }

        if (pos.x > 20)
            pos.x = 20;
        if (pos.x < -25)
            pos.x = -25;




        transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "reverse")
        {
            startTime = Time.time;
            finishTime = startTime + 3f;
            reverse = true;

            Destroy(other.gameObject, 0);

        }
        if (other.gameObject.name == "time")
        {

            startTime = Time.time;
            finishTime = startTime + 3f;
            time = true;

            Destroy(other.gameObject, 0);

        }

    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 60;
        style.normal.textColor = Color.black;

        //Enemy[] scripts = FindObjectsOfType<Enemy>();
        string str = "      X 3";

        GUI.Label(new Rect(25, 30, 100, 20), str, style);
    }
}
