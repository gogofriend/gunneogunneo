using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Snoman_Move2 : MonoBehaviour
{
    float startTime;
    float finishTime;
    bool reverse;
    bool time;
    bool hole_col;
    bool tree_col;
    bool car_col;
    int heart;
    int arrow;
    int carnum;
    float timer;
    int waitingTime;
    string groundnum;

    Vector3 holepos;
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
        hole_col = false;
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
        //휘청이지 않게 함
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
            heart--;
            Debug.Log("하트감소, 하트개수 : " + heart);
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
            }*/
            pos -= new Vector3(1, 0, 0);
            //죽으면 가까운 그라운드로
            if (gameObject.transform.position.z >= 52 && gameObject.transform.position.z < 58)
                pos = new Vector3(-6, -2, 52);
            if (gameObject.transform.position.z >= 58 && gameObject.transform.position.z < 69)
                pos = new Vector3(-6, -2, 58);
            if (gameObject.transform.position.z >= 69 && gameObject.transform.position.z < 83)
                pos = new Vector3(-6, -2, 69);
            if (gameObject.transform.position.z >= 83 && gameObject.transform.position.z < 96)
                pos = new Vector3(-6, -2, 83);
            if (gameObject.transform.position.z >= 96 && gameObject.transform.position.z < 102)
                pos = new Vector3(-6, -2, 96);
            if (gameObject.transform.position.z >= 102 && gameObject.transform.position.z < 110)
                pos = new Vector3(-6, -2, 102);
            if (gameObject.transform.position.z >= 110 && gameObject.transform.position.z < 116)
                pos = new Vector3(-6, -2, 110);
            if (gameObject.transform.position.z >= 116 && gameObject.transform.position.z < 122)
                pos = new Vector3(-6, -2, 116);
            if (gameObject.transform.position.z >= 122 && gameObject.transform.position.z < 136)
                pos = new Vector3(-6, -2, 122);
            if (gameObject.transform.position.z >= 136 && gameObject.transform.position.z < 142)
                pos = new Vector3(-6, -2, 136);
            if (gameObject.transform.position.z >= 142 && gameObject.transform.position.z < 152)
                pos = new Vector3(-6, -2, 142);
            if (gameObject.transform.position.z >= 152 && gameObject.transform.position.z < 162)
                pos = new Vector3(-6, -2, 152);
            if (gameObject.transform.position.z >= 162 && gameObject.transform.position.z < 180)
                pos = new Vector3(-6, -2, 162);
            if (gameObject.transform.position.z >= 180 && gameObject.transform.position.z < 192)
                pos = new Vector3(-6, -2, 180);
            if (gameObject.transform.position.z >= 192 && gameObject.transform.position.z < 202)
                pos = new Vector3(-6, -2, 192);
            if (gameObject.transform.position.z >= 202 && gameObject.transform.position.z < 212)
                pos = new Vector3(-6, -2, 202);
            if (gameObject.transform.position.z >= 212 && gameObject.transform.position.z < 224)
                pos = new Vector3(-6, -2, 212);
            if (gameObject.transform.position.z >= 224 && gameObject.transform.position.z < 232)
                pos = new Vector3(-6, -2, 224);
            if (gameObject.transform.position.z >= 232 && gameObject.transform.position.z < 240)
                pos = new Vector3(-6, -2, 232);
            if (gameObject.transform.position.z >= 240 && gameObject.transform.position.z < 244)
                pos = new Vector3(-6, -2, 240);
            if (gameObject.transform.position.z >= 244 && gameObject.transform.position.z < 250)
                pos = new Vector3(-6, -2, 244);
            /*
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                car_col = false;
                timer = 0;
            }//실드*/

            car_col = false;
        }

        if (tree_col == true || hole_col == true)
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
            hole_col = false;
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

        if (pos.z > 252)
        {
            SceneManager.LoadScene("Continue");
        }



        transform.position = pos;
    }
    void OnTriggerEnter(Collider other)
    {
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
        if (other.gameObject.tag == "reverse")
        {
            startTime = Time.time;
            finishTime = startTime + 3f;
            reverse = true;

            Destroy(other.gameObject, 0);

        }
        if (other.gameObject.tag == "time")
        {

            startTime = Time.time;
            finishTime = startTime + 3f;
            time = true;

            Destroy(other.gameObject, 0);

        }
        if (other.gameObject.tag == "shield")
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                car_col = false;
                timer = 0;
            }
        }

        if (other.gameObject.tag == "hole")
        {
            hole_col = true;
            Debug.Log("hole");
            holepos = other.gameObject.transform.position;
        }

        if (other.gameObject.tag == "Tree")
        {
            tree_col = true;
            Debug.Log("tree");
            treepos = other.gameObject.transform.position;

        }


    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 60;
        style.normal.textColor = Color.black;

        string str = "      X " + heart;
    }
}