using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Snoman_Move2 : MonoBehaviour
{
    bool bh;  //깨진하트 확인 변수
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
    public Text scoreData1;
    public Text scoreData2;
    public Text scoreData3;
    public Text scoreData4;
    public Text scoreData5;
    float htimer;//깨진하트 타이머
    float startTime1;
    float startTime2;
    float startTime3;
    float startTime4;

    float finishTime1;
    float finishTime2;
    float finishTime3;
    float finishTime4;

    bool shield;

    Vector3 holepos;
    Vector3 treepos;
    Vector3 pos;
    Collider obc;
    float step = 2;

    AudioSource audio;
    public AudioClip jump;

    public GameObject heli;
    public GameObject heartb;//깨진하트 오브젝트
    public GameObject shielditem;//실드 
    public GameObject timeagainstitem;//시간을 거스르는자
    public GameObject reverseitem;//거꾸로
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        reverse = false;
        time = false;
        hole_col = false;
        tree_col = false;
        car_col = false;
        shield = false;
        heart = 3;
        arrow = 0;
        carnum = 0;
        timer = 0;
        waitingTime = 2;
        startTime1 = 0;
        startTime2 = 0;
        startTime3 = 0;
        startTime4 = 0;  //깨진 하트 시간 변수 초기화

        finishTime1 = 0;
        finishTime2 = 0;
        finishTime3 = 0;
        finishTime4 = 0;  //깨진 하트 시간 변수 초기화

        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = jump;
        audio.loop = false;

        bh = false; // 하트 안깨진 상태
        htimer = 0.0f;

        heartb = GameObject.Find("heartb");//깨진하트 오브젝트찾기
        shielditem = GameObject.Find("shielditem");//실드 찾기
        timeagainstitem = GameObject.Find("timeagainstitem");//시간을거스르는자 찾기
        reverseitem = GameObject.Find("reverseitem");//거꾸로 찾기

        heartb.SetActive(false);
        shielditem.SetActive(false);
        timeagainstitem.SetActive(false);
        reverseitem.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        htimer += Time.deltaTime; //깨진하트 시간측정용        

        if (bh == true)
        {
            startTime4 += Time.deltaTime;
            heartb.SetActive(true);
            if (startTime4 >= finishTime4)
            {
                heartb.SetActive(false);
                bh = false;
            }
        }
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

            if (shield)
            {
               
                pos -= new Vector3(1, 0, 0);
                //죽으면 가까운 그라운드로
                if (gameObject.transform.position.z >= 52 && gameObject.transform.position.z < 58)
                    pos = new Vector3(-6, 1.099988f, 52);
                if (gameObject.transform.position.z >= 58 && gameObject.transform.position.z < 69)
                    pos = new Vector3(-6, 1.099988f, 58);
                if (gameObject.transform.position.z >= 69 && gameObject.transform.position.z < 83)
                    pos = new Vector3(-6, 1.099988f, 70);
                if (gameObject.transform.position.z >= 83 && gameObject.transform.position.z < 96)
                    pos = new Vector3(-6, 1.099988f, 84);
                if (gameObject.transform.position.z >= 96 && gameObject.transform.position.z < 102)
                    pos = new Vector3(-6, 1.099988f, 96);
                if (gameObject.transform.position.z >= 102 && gameObject.transform.position.z < 110)
                    pos = new Vector3(-6, 1.099988f, 102);
                if (gameObject.transform.position.z >= 110 && gameObject.transform.position.z < 116)
                    pos = new Vector3(-6, 1.099988f, 110);
                if (gameObject.transform.position.z >= 116 && gameObject.transform.position.z < 122)
                    pos = new Vector3(-6, 1.099988f, 116);
                if (gameObject.transform.position.z >= 122 && gameObject.transform.position.z < 136)
                    pos = new Vector3(-6, 1.099988f, 122);
                if (gameObject.transform.position.z >= 136 && gameObject.transform.position.z < 142)
                    pos = new Vector3(-6, 1.099988f, 136);
                if (gameObject.transform.position.z >= 142 && gameObject.transform.position.z < 152)
                    pos = new Vector3(-6, 1.099988f, 142);
                if (gameObject.transform.position.z >= 152 && gameObject.transform.position.z < 162)
                    pos = new Vector3(-6, 1.099988f, 152);
                if (gameObject.transform.position.z >= 162 && gameObject.transform.position.z < 180)
                    pos = new Vector3(-6, 1.099988f, 162);
                if (gameObject.transform.position.z >= 180 && gameObject.transform.position.z < 192)
                    pos = new Vector3(-6, 1.099988f, 180);
                if (gameObject.transform.position.z >= 192 && gameObject.transform.position.z < 202)
                    pos = new Vector3(-6, 1.099988f, 192);
                if (gameObject.transform.position.z >= 202 && gameObject.transform.position.z < 212)
                    pos = new Vector3(-6, 1.099988f, 202);
                if (gameObject.transform.position.z >= 212 && gameObject.transform.position.z < 224)
                    pos = new Vector3(-6, 1.099988f, 212);
                if (gameObject.transform.position.z >= 224 && gameObject.transform.position.z < 232)
                    pos = new Vector3(-6, 1.099988f, 224);
                if (gameObject.transform.position.z >= 232 && gameObject.transform.position.z < 240)
                    pos = new Vector3(-6, 1.099988f, 232);
                if (gameObject.transform.position.z >= 240 && gameObject.transform.position.z < 244)
                    pos = new Vector3(-6, 1.099988f, 240);
                if (gameObject.transform.position.z >= 244 && gameObject.transform.position.z < 250)
                    pos = new Vector3(-6, 1.099988f, 244);

            }
            if (shield == false)
            {
                heart--;

                startTime4 = Time.time;
                finishTime4 = startTime4 + 1f;
                bh = true;

                pos -= new Vector3(1, 0, 0);
                //죽으면 가까운 그라운드로
                if (gameObject.transform.position.z >= 52 && gameObject.transform.position.z < 58)
                    pos = new Vector3(-6, 1.099988f, 52);
                if (gameObject.transform.position.z >= 58 && gameObject.transform.position.z < 69)
                    pos = new Vector3(-6, 1.099988f, 58);
                if (gameObject.transform.position.z >= 69 && gameObject.transform.position.z < 83)
                    pos = new Vector3(-6, 1.099988f, 70);
                if (gameObject.transform.position.z >= 83 && gameObject.transform.position.z < 96)
                    pos = new Vector3(-6, 1.099988f, 84);
                if (gameObject.transform.position.z >= 96 && gameObject.transform.position.z < 102)
                    pos = new Vector3(-6, 1.099988f, 96);
                if (gameObject.transform.position.z >= 102 && gameObject.transform.position.z < 110)
                    pos = new Vector3(-6, 1.099988f, 102);
                if (gameObject.transform.position.z >= 110 && gameObject.transform.position.z < 116)
                    pos = new Vector3(-6, 1.099988f, 110);
                if (gameObject.transform.position.z >= 116 && gameObject.transform.position.z < 122)
                    pos = new Vector3(-6, 1.099988f, 116);
                if (gameObject.transform.position.z >= 122 && gameObject.transform.position.z < 136)
                    pos = new Vector3(-6, 1.099988f, 122);
                if (gameObject.transform.position.z >= 136 && gameObject.transform.position.z < 142)
                    pos = new Vector3(-6, 1.099988f, 136);
                if (gameObject.transform.position.z >= 142 && gameObject.transform.position.z < 152)
                    pos = new Vector3(-6, 1.099988f, 142);
                if (gameObject.transform.position.z >= 152 && gameObject.transform.position.z < 162)
                    pos = new Vector3(-6, 1.099988f, 152);
                if (gameObject.transform.position.z >= 162 && gameObject.transform.position.z < 180)
                    pos = new Vector3(-6, 1.099988f, 162);
                if (gameObject.transform.position.z >= 180 && gameObject.transform.position.z < 192)
                    pos = new Vector3(-6, 1.099988f, 180);
                if (gameObject.transform.position.z >= 192 && gameObject.transform.position.z < 202)
                    pos = new Vector3(-6, 1.099988f, 192);
                if (gameObject.transform.position.z >= 202 && gameObject.transform.position.z < 212)
                    pos = new Vector3(-6, 1.099988f, 202);
                if (gameObject.transform.position.z >= 212 && gameObject.transform.position.z < 224)
                    pos = new Vector3(-6, 1.099988f, 212);
                if (gameObject.transform.position.z >= 224 && gameObject.transform.position.z < 232)
                    pos = new Vector3(-6, 1.099988f, 224);
                if (gameObject.transform.position.z >= 232 && gameObject.transform.position.z < 240)
                    pos = new Vector3(-6, 1.099988f, 232);
                if (gameObject.transform.position.z >= 240 && gameObject.transform.position.z < 244)
                    pos = new Vector3(-6, 1.099988f, 240);
                if (gameObject.transform.position.z >= 244 && gameObject.transform.position.z < 250)
                    pos = new Vector3(-6, 1.099988f, 244);
            }
            car_col = false;
        }
        if (shield)
        {
            shielditem.SetActive(true);
            startTime3 += Time.deltaTime;
            if (startTime3 >= finishTime3)
            {
                shielditem.SetActive(false);
                shield = false;
            }
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
            reverseitem.SetActive(true);
            startTime1 += Time.deltaTime;
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
            if (startTime1 >= finishTime1)
            {
                reverseitem.SetActive(false);
                reverse = false;
            }
        }
       if (time)
        {
            timeagainstitem.SetActive(true);
            startTime2 += Time.deltaTime;

            GameObject[] objArray = GameObject.FindGameObjectsWithTag("Car");
            GameObject[] objArray2 = GameObject.FindGameObjectsWithTag("Car2");

            for (int i = 0; i < objArray.Length; i++)
                objArray[i].gameObject.transform.position -= (new Vector3(9, 0, 0) * Time.deltaTime);
            for (int i = 0; i < objArray2.Length; i++)
                objArray2[i].gameObject.transform.position += (new Vector3(9, 0, 0) * Time.deltaTime);

            if (startTime2 >= finishTime2)
            {
                timeagainstitem.SetActive(false);
                time = false;
            }
        }
   

        if (pos.x > 10)
            pos.x = 10;
        if (pos.x < -14)
            pos.x = -14;
        if (pos.z < 52)
            pos.z = 52;

        if (pos.z > 250)
        {
            Score_Mng.score += Mathf.FloorToInt(Timer.timelimit);
            Score_Mng.Save();
            Load();
            SceneManager.LoadScene("Ranking");
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

        if (gameObject.transform.position.z >= 52 && gameObject.transform.position.z < 58)
            heli.transform.position = new Vector3(-6, 8, 58.1f);
        if (gameObject.transform.position.z >= 58 && gameObject.transform.position.z < 69)
            heli.transform.position = new Vector3(-6, 8, 69.1f);
        if (gameObject.transform.position.z >= 69 && gameObject.transform.position.z < 83)
            heli.transform.position = new Vector3(-6, 8, 83.1f);
        if (gameObject.transform.position.z >= 83 && gameObject.transform.position.z < 96)
            heli.transform.position = new Vector3(-6, 6, 96.1f);
        if (gameObject.transform.position.z >= 96 && gameObject.transform.position.z < 102)
            heli.transform.position = new Vector3(-6, 6, 102.1f);
        if (gameObject.transform.position.z >= 102 && gameObject.transform.position.z < 110)
            heli.transform.position = new Vector3(-6, 6, 110.1f);
        if (gameObject.transform.position.z >= 110 && gameObject.transform.position.z < 116)
            heli.transform.position = new Vector3(-6, 6, 116.1f);
        if (gameObject.transform.position.z >= 116 && gameObject.transform.position.z < 122)
            heli.transform.position = new Vector3(-6, 6, 122.1f);
        if (gameObject.transform.position.z >= 122 && gameObject.transform.position.z < 136)
            heli.transform.position = new Vector3(-6, 6, 136.1f);
        if (gameObject.transform.position.z >= 136 && gameObject.transform.position.z < 142)
            heli.transform.position = new Vector3(-6, 6, 142.1f);
        if (gameObject.transform.position.z >= 142 && gameObject.transform.position.z < 152)
            heli.transform.position = new Vector3(-6, 6, 152.1f);
        if (gameObject.transform.position.z >= 152 && gameObject.transform.position.z < 162)
            heli.transform.position = new Vector3(-6, 6, 162.1f);
        if (gameObject.transform.position.z >= 162 && gameObject.transform.position.z < 180)
            heli.transform.position = new Vector3(-6, 6, 180.1f);
        if (gameObject.transform.position.z >= 180 && gameObject.transform.position.z < 192)
            heli.transform.position = new Vector3(-6, 6, 192.1f);
        if (gameObject.transform.position.z >= 192 && gameObject.transform.position.z < 202)
            heli.transform.position = new Vector3(-6, 6, 202.1f);
        if (gameObject.transform.position.z >= 202 && gameObject.transform.position.z < 212)
            heli.transform.position = new Vector3(-6, 6, 212.1f);
        if (gameObject.transform.position.z >= 212 && gameObject.transform.position.z < 224)
            heli.transform.position = new Vector3(-6, 6, 224.1f);
        if (gameObject.transform.position.z >= 224 && gameObject.transform.position.z < 232)
            heli.transform.position = new Vector3(-6, 6, 232.1f);
        if (gameObject.transform.position.z >= 232 && gameObject.transform.position.z < 240)
            heli.transform.position = new Vector3(-6, 6, 240.1f);
        if (gameObject.transform.position.z >= 240 && gameObject.transform.position.z < 244)
            heli.transform.position = new Vector3(-6, 6, 244.1f);
        if (gameObject.transform.position.z >= 244 && gameObject.transform.position.z < 250)
            heli.transform.position = new Vector3(-6, 6, 250.1f);

        transform.position = pos;
    }
    public void Load() //랭킹 Panel의 text에 점수를 로드
    {
        scoreData1.text = PlayerPrefs.GetInt("BestScore").ToString() + "초";
        scoreData2.text = PlayerPrefs.GetInt("SecondScore").ToString() + "초";
        scoreData3.text = PlayerPrefs.GetInt("ThirdScore").ToString() + "초";
        scoreData4.text = PlayerPrefs.GetInt("FourthScore").ToString() + "초";
        scoreData5.text = PlayerPrefs.GetInt("FifthScore").ToString() + "초";
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
            startTime1 = Time.time;
            finishTime1 = startTime1 + 3f;
            reverse = true;

            Destroy(other.gameObject, 0);

        }
        if (other.gameObject.tag == "time")
        {

            startTime2 = Time.time;
            finishTime2 = startTime2 + 3f;
            time = true;

            Destroy(other.gameObject, 0);

        }
        if (other.gameObject.tag == "shield")
        {
            startTime3 = Time.time;
            finishTime3 = startTime3 + 3f;
            shield = true;

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

        string str = "      X " + heart;
        GUI.Label(new Rect(25, 30, 100, 20), str, style);
    }
}