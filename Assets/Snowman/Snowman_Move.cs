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

    AudioSource audio;
    public AudioClip jump;
    AudioSource audio1;
    public AudioClip cnt_time;

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

        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = jump;
        audio.loop = false;

        audio1 = gameObject.AddComponent<AudioSource>();
        audio1.clip = cnt_time;
        audio1.loop = false;
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
            if (gameObject.transform.position.z >= -98 && gameObject.transform.position.z < -90)
                pos = new Vector3(0, 1, -98);
            if (gameObject.transform.position.z >= -90 && gameObject.transform.position.z < -86)
                pos = new Vector3(0, 1, -90);
            if (gameObject.transform.position.z >= -86 && gameObject.transform.position.z < -82)
                pos = new Vector3(0, 1, -86);
            if (gameObject.transform.position.z >= -82 && gameObject.transform.position.z < -73)
                pos = new Vector3(0, 1, -82);
            if (gameObject.transform.position.z >= -73 && gameObject.transform.position.z < -66)
                pos = new Vector3(0, 1, -73);
            if (gameObject.transform.position.z >= -66 && gameObject.transform.position.z < -58)
                pos = new Vector3(0, 1, -66);
            if (gameObject.transform.position.z >= -58 && gameObject.transform.position.z < -50)
                pos = new Vector3(0, 1, -58);
            if (gameObject.transform.position.z >= -50 && gameObject.transform.position.z < -37)
                pos = new Vector3(0, 1, -50);
            if (gameObject.transform.position.z >= -37 && gameObject.transform.position.z < -28)
                pos = new Vector3(0, 1, -37);
            if (gameObject.transform.position.z >= -28 && gameObject.transform.position.z < -20)
                pos = new Vector3(0, 1, -28);
            if (gameObject.transform.position.z >= -20 && gameObject.transform.position.z < -10)
                pos = new Vector3(0, 1, -20);
            if (gameObject.transform.position.z >= -10 && gameObject.transform.position.z < -6)
                pos = new Vector3(0, 1, -10);
            if (gameObject.transform.position.z >= -6 && gameObject.transform.position.z < 0)
                pos = new Vector3(0, 1, -6);

            heart--;
            Debug.Log("하트감소, 하트개수 : " + heart);
            car_col = false;
        }

        if (tree_col == true)
        {
            if (arrow == 1)
            {
                pos -= new Vector3(0, 0, 2);
            }
            if (arrow == 2)
            {
                pos += new Vector3(0, 0, 2);
            }
            if (arrow == 3)
            {
                pos -= new Vector3(2, 0, 0);
            }
            if (arrow == 4)
            {
                pos += new Vector3(2, 0, 0);
            }
            tree_col = false;
        }

        if (hole_col == true)
        {
            if (arrow == 1)
            {
                pos -= new Vector3(0, 0, 2);
            }
            if (arrow == 2)
            {
                pos += new Vector3(0, 0, 2);
            }
            if (arrow == 3)
            {
                pos -= new Vector3(2, 0, 0);
            }
            if (arrow == 4)
            {
                pos += new Vector3(2, 0, 0);
            }
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
            audio1.Play();
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

        if (pos.z > 1)
        {
            SceneManager.LoadScene("Continue");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audio.Play();
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
            Destroy(other.gameObject, 0);
        }
        if (other.gameObject.tag == "bomb")
        {
            SceneManager.LoadScene("GameOver");
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

        //Enemy[] scripts = FindObjectsOfType<Enemy>();
        string str = "      X " + heart;

        GUI.Label(new Rect(25, 30, 100, 20), str, style);
    }
}