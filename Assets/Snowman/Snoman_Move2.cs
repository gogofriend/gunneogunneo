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
    bool reverse; //거꾸로 아이템 체크 변수
    bool time; //시간을 거스르는 자 아이템 체크 변수
    bool hole_col; //구멍 충돌 여부 확인
    bool tree_col; //나무 충돌 여부 확인
    bool car_col; //차 충돌 여부 확인
    int heart; //생명 개수
    int arrow; //키보드 입력 값 저장

    public Text scoreData1;
    public Text scoreData2;
    public Text scoreData3;
    public Text scoreData4;
    public Text scoreData5;

    float htimer; //깨진하트 타이머
    float startTime1; //아이템 시간 측정용
    float startTime2; //아이템 시간 측정용
    float startTime3; //아이템 시간 측정용
    float startTime4; //아이템 시간 측정용

    float finishTime1; //아이템 시간 측정용
    float finishTime2; //아이템 시간 측정용
    float finishTime3; //아이템 시간 측정용
    float finishTime4; //하트 시간 측정용

    bool shield; //실드 사용 여부 체크
    Vector3 pos; //눈사람 위치
    float step = 2; //눈사람 한걸음

    Vector3 holepos;
    Vector3 treepos;
    Collider obc;

    AudioSource audio; //오디오 변수
    public AudioClip jump; //오디오 점프

    public GameObject heli; //헬리콥터 오브젝트
    public GameObject heartb; //깨진하트 오브젝트
    public GameObject shielditem; //실드 
    public GameObject timeagainstitem; //시간을 거스르는자
    public GameObject reverseitem; //거꾸로
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position; //현재 위치 받아오기

        reverse = false; //거꾸로 아이템 끄기
        time = false; //타임 아이템 끄기
        shield = false; //실드 아이템 끄기
        hole_col = false; //구멍 충돌 false로 초기화
        tree_col = false; //나무 충돌 false로 초기화
        car_col = false; //차 충돌 false로 초기화

        heart = 3; //생명 개수 3개로 초기화
        arrow = 0; //방향키 0으로 초기화
        startTime1 = 0; //아이템 시간 변수 초기화
        startTime2 = 0; //아이템 시간 변수 초기화
        startTime3 = 0; //아이템 시간 변수 초기화
        startTime4 = 0;  //깨진 하트 시간 변수 초기화

        finishTime1 = 0; //아이템 시간 변수 초기화
        finishTime2 = 0; //아이템 시간 변수 초기화
        finishTime3 = 0; //아이템 시간 변수 초기화
        finishTime4 = 0;  //깨진 하트 시간 변수 초기화

        audio = gameObject.AddComponent<AudioSource>(); //오디오 소스 받아오기
        audio.clip = jump; //점프소리 넣기
        audio.loop = false; //반복 안함

        bh = false; // 하트 안깨진 상태
        htimer = 0.0f; //깨진 하트 보여지는 시간 측정 변수

        heartb = GameObject.Find("heartb"); //깨진하트 오브젝트찾기
        shielditem = GameObject.Find("shielditem"); //실드 찾기
        timeagainstitem = GameObject.Find("timeagainstitem"); //시간을거스르는자 찾기
        reverseitem = GameObject.Find("reverseitem"); //거꾸로 찾기

        heartb.SetActive(false); //깨진하트 안보이게
        shielditem.SetActive(false); //실드아이템 비활성화
        timeagainstitem.SetActive(false); //시간을 거스르는 자 아이템 비활성화
        reverseitem.SetActive(false); //거꾸로 아이템 비활성화
    }

    // Update is called once per frame
    void Update()
    {
        htimer += Time.deltaTime; //깨진하트 시간측정용        

        if (bh == true) //깨진 하트가 나와야 하면
        {
            startTime4 += Time.deltaTime;
            heartb.SetActive(true); //깨진 하트 활성화
            if (startTime4 >= finishTime4) //깨진 하트가 보여지는 시간이 끝나면
            {
                heartb.SetActive(false); //깨진 하트 비활성화
                bh = false; //깨진 하트체크 변수를 다시 false로 만들어줌
            }
        }
        //눈사람이 충돌했을 때 휘청이지 않게 함
        if (arrow == 1) //위
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (arrow == 3) //오른쪽
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        if (arrow == 4) //왼쪽
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        if (arrow == 2) //아래
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        if (heart == 0) //생명이 0이 되면
            SceneManager.LoadScene("GameOver"); //게임오버 씬을 불러옴

        if (car_col == true) //차와 충돌하면
        {

            if (shield) //'실드' 아이템이 작동중이면
            {
                //목숨이 줄어들지 않고 장애물을 통과해서 지나간다
            }
            if (shield == false) //'실드' 아이템이 작동중이지 않으면
            {
                heart--; //생명을 차감함

                startTime4 = Time.time;
                finishTime4 = startTime4 + 1f; //1초동안
                bh = true; //깨진 하트 보여짐

                //죽으면 눈사람을 가까운 그라운드로 리스폰함
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
            car_col = false; //차 충돌 여부 변수를 다시 false로 만들어줌
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
                objArray[i].gameObject.transform.position -= (new Vector3(8, 0, 0) * Time.deltaTime);
            for (int i = 0; i < objArray2.Length; i++)
                objArray2[i].gameObject.transform.position += (new Vector3(8, 0, 0) * Time.deltaTime);

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

        if (gameObject.transform.position.z > 52 && gameObject.transform.position.z < 56)
            heli.transform.position = new Vector3(0, 8, 58.1f);
        if (gameObject.transform.position.z > 58 && gameObject.transform.position.z < 68)
            heli.transform.position = new Vector3(0, 8, 69.1f);
        if (gameObject.transform.position.z > 69 && gameObject.transform.position.z < 82)
            heli.transform.position = new Vector3(0, 8, 83.1f);
        if (gameObject.transform.position.z > 83 && gameObject.transform.position.z < 94)
            heli.transform.position = new Vector3(0, 8, 96.1f);
        if (gameObject.transform.position.z > 96 && gameObject.transform.position.z < 100)
            heli.transform.position = new Vector3(0, 8, 102.1f);
        if (gameObject.transform.position.z > 102 && gameObject.transform.position.z < 108)
            heli.transform.position = new Vector3(0, 8, 110.1f);
        if (gameObject.transform.position.z > 110 && gameObject.transform.position.z < 114)
            heli.transform.position = new Vector3(0, 8, 116.1f);
        if (gameObject.transform.position.z > 116 && gameObject.transform.position.z < 120)
            heli.transform.position = new Vector3(2, 8, 122.1f);
        if (gameObject.transform.position.z > 122 && gameObject.transform.position.z < 134)
            heli.transform.position = new Vector3(2, 8, 136.1f);
        if (gameObject.transform.position.z > 136 && gameObject.transform.position.z < 140)
            heli.transform.position = new Vector3(0, 8, 142.1f);
        if (gameObject.transform.position.z > 142 && gameObject.transform.position.z < 150)
            heli.transform.position = new Vector3(0, 8, 152.1f);
        if (gameObject.transform.position.z > 152 && gameObject.transform.position.z < 160)
            heli.transform.position = new Vector3(2, 8, 162.1f);
        if (gameObject.transform.position.z > 162 && gameObject.transform.position.z < 178)
            heli.transform.position = new Vector3(-10, 8, 180.1f);
        if (gameObject.transform.position.z > 180 && gameObject.transform.position.z < 190)
            heli.transform.position = new Vector3(-10, 8, 192.1f);
        if (gameObject.transform.position.z > 192 && gameObject.transform.position.z < 200)
            heli.transform.position = new Vector3(0, 8, 202.1f);
        if (gameObject.transform.position.z > 202 && gameObject.transform.position.z < 210)
            heli.transform.position = new Vector3(0, 8, 212.1f);
        if (gameObject.transform.position.z > 212 && gameObject.transform.position.z < 222)
            heli.transform.position = new Vector3(0, 8, 224.1f);
        if (gameObject.transform.position.z > 224 && gameObject.transform.position.z < 230)
            heli.transform.position = new Vector3(0, 8, 232.1f);
        if (gameObject.transform.position.z > 232 && gameObject.transform.position.z < 238)
            heli.transform.position = new Vector3(0, 8, 240.1f);
        if (gameObject.transform.position.z > 240 && gameObject.transform.position.z < 242)
            heli.transform.position = new Vector3(0, 8, 244.1f);
        if (gameObject.transform.position.z > 244 && gameObject.transform.position.z < 248)
            heli.transform.position = new Vector3(2, 8, 250.1f);

        /*
        if (gameObject.transform.position.z >= 52 && gameObject.transform.position.z < 58)
            heli.transform.position = new Vector3(-1.199999f, 8, 58.1f);
        if (gameObject.transform.position.z >= 58 && gameObject.transform.position.z < 69)
            heli.transform.position = new Vector3(-1.199999f, 8, 69.1f);
        if (gameObject.transform.position.z >= 69 && gameObject.transform.position.z < 83)
            heli.transform.position = new Vector3(-1.199999f, 8, 83.1f);
        if (gameObject.transform.position.z >= 83 && gameObject.transform.position.z < 96)
            heli.transform.position = new Vector3(-1.199999f, 8, 96.1f);
        if (gameObject.transform.position.z >= 96 && gameObject.transform.position.z < 102)
            heli.transform.position = new Vector3(-1.199999f, 8, 102.1f);
        if (gameObject.transform.position.z >= 102 && gameObject.transform.position.z < 110)
            heli.transform.position = new Vector3(-1.199999f, 8, 110.1f);
        if (gameObject.transform.position.z >= 110 && gameObject.transform.position.z < 116)
            heli.transform.position = new Vector3(-1.199999f, 8, 116.1f);
        if (gameObject.transform.position.z >= 116 && gameObject.transform.position.z < 122)
            heli.transform.position = new Vector3(-1.199999f, 8, 122.1f);
        if (gameObject.transform.position.z >= 122 && gameObject.transform.position.z < 136)
            heli.transform.position = new Vector3(-1.199999f, 8, 136.1f);
        if (gameObject.transform.position.z >= 136 && gameObject.transform.position.z < 142)
            heli.transform.position = new Vector3(-1.199999f, 8, 142.1f);
        if (gameObject.transform.position.z >= 142 && gameObject.transform.position.z < 152)
            heli.transform.position = new Vector3(-1.199999f, 8, 152.1f);
        if (gameObject.transform.position.z >= 152 && gameObject.transform.position.z < 162)
            heli.transform.position = new Vector3(-1.199999f, 8, 162.1f);
        if (gameObject.transform.position.z >= 162 && gameObject.transform.position.z < 180)
            heli.transform.position = new Vector3(-1.199999f, 8, 180.1f);
        if (gameObject.transform.position.z >= 180 && gameObject.transform.position.z < 192)
            heli.transform.position = new Vector3(-1.199999f, 8, 192.1f);
        if (gameObject.transform.position.z >= 192 && gameObject.transform.position.z < 202)
            heli.transform.position = new Vector3(-1.199999f, 8, 202.1f);
        if (gameObject.transform.position.z >= 202 && gameObject.transform.position.z < 212)
            heli.transform.position = new Vector3(-1.199999f, 8, 212.1f);
        if (gameObject.transform.position.z >= 212 && gameObject.transform.position.z < 224)
            heli.transform.position = new Vector3(-1.199999f, 8, 224.1f);
        if (gameObject.transform.position.z >= 224 && gameObject.transform.position.z < 232)
            heli.transform.position = new Vector3(-1.199999f, 8, 232.1f);
        if (gameObject.transform.position.z >= 232 && gameObject.transform.position.z < 240)
            heli.transform.position = new Vector3(-1.199999f, 8, 240.1f);
        if (gameObject.transform.position.z >= 240 && gameObject.transform.position.z < 244)
            heli.transform.position = new Vector3(-1.199999f, 8, 244.1f);
        if (gameObject.transform.position.z >= 244 && gameObject.transform.position.z < 250)
            heli.transform.position = new Vector3(-1.199999f, 8, 250.1f);
        */
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
        }
        if (other.gameObject.tag == "Car")
        {
            car_col = true;
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