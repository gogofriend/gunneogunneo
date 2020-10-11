using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman_Move : MonoBehaviour
{
    float startTime;
    float finishTime;
    bool reverse;

    Vector3 pos;
    float step = 2;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        reverse = false;
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

        transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("T");
        if (other.gameObject.name == "reverse")
        {
            startTime = Time.time;
            finishTime = startTime + 3f;
            reverse = true;

            Destroy(other.gameObject, 0);

        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = Color.black;

        //Enemy[] scripts = FindObjectsOfType<Enemy>();
        string str = "     X 3";

        GUI.Label(new Rect(10, 10, 100, 20), str, style);
    }
}
