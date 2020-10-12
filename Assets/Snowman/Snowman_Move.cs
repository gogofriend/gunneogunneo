using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Snowman_Move : MonoBehaviour
{
    float startTime;
    float finishTime;
    bool reverse;
    bool time;
    bool tree_col;
    bool car_col;
    int heart;
    int arrow;
    int carnum;
    float timer;
    int waitingTime;

    Vector3 treepos;
    Vector3 pos;
    Collider obc;
    float step = 2;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        reverse = false;
        time = false;
        tree_col = false;
        car_col = false;
        heart = 3;
        arrow = 0;
        carnum = 0;
        timer = 0;
        waitingTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (arrow == 1)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (arrow == 3)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        if (arrow == 4)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        if (arrow == 2)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        if (heart == 0)
            SceneManager.LoadScene("GameOver");

        if (car_col == true)
        {

            /*
            if (arrow == 1 || carnum == 1)
            {
                pos -= new Vector3(1, 0, 1);
            }
            if (arrow == 1 || carnum == 2)
            {
                pos -= new Vector3(-1, 0, 1);
            }
            if (arrow == 2 || carnum == 1)
            {
                pos += new Vector3(1, 0, 1);
            }
            if (arrow == 2 || carnum == 2)
            {
                pos += new Vector3(-1, 0, 1);
            }
            if (arrow == 3 || carnum == 1)
            {
                pos -= new Vector3(-1, 0, 0);
            }
            if (arrow == 3 || carnum == 2)
            {
                pos -= new Vector3(1, 0, 0);
            }
            if (arrow == 4 || carnum == 1)
            {
                pos += new Vector3(1, 0, 0);
            }
            if (arrow == 4 || carnum == 2)
            {
                pos -= new Vector3(1, 0, 0);
            }
            */
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                car_col = false;
                timer = 0;
            }
            heart--;
            car_col = false;
        }

        if (tree_col == true)
        {
            if (arrow == 1)
            {
                pos -= new Vector3(0, 0, 1);
            }
            if (arrow == 2)
            {
                pos += new Vector3(0, 0, 1);
            }
            if (arrow == 3)
            {
                pos -= new Vector3(1, 0, 0);
            }
            if (arrow == 4)
            {
                pos += new Vector3(1, 0, 0);
            }
            tree_col = false;
        }

        if (reverse == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                pos += transform.forward * step;
                arrow = 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                pos += transform.forward * step;
                arrow = 2;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                pos += transform.forward * step;
                arrow = 3;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                pos += transform.forward * step;
                arrow = 4;
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
        if (other.gameObject.tag == "Tree")
        {
            tree_col = true;
            Debug.Log("tree");
            treepos = other.gameObject.transform.position;

        }
        if (other.gameObject.tag == "Car2")
        {
            car_col = true;
            carnum = 2;
            Debug.Log("car2");
        }
        if (other.gameObject.tag == "Car")
        {
            car_col = true;
            carnum = 1;
            Debug.Log("car");
        }
    }



    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 60;
        style.normal.textColor = Color.black;

        //Enemy[] scripts = FindObjectsOfType<Enemy>();
        string str = "      X " + heart;

        GUI.Label(new Rect(25, 30, 100, 20), str, style);
    }
}
