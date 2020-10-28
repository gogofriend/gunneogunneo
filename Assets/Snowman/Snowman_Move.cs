using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Snowman_Move : MonoBehaviour
{
    bool bh;  //깨진하트 확인 변수
    bool reverse; //reverse 아이템 체크 변수
    bool time; //제한시간 체크 변수
    bool hole_col; //구멍 충돌 여부 확인
    bool tree_col;//나무 충돌 여부 확인
    bool car_col; //차 충돌 여부 확인
    int heart; //생명 개수
    int arrow; //키보드 입력 값 저장

    float htimer;//깨진하트 타이머
    float startTime1; //아이템 시간 측정용
    float startTime2; //아이템 시간 측정용
    float startTime3; //아이템 시간 측정용
    float startTime4; //하트 시간 측정용

    float finishTime1; //아이템 시간 측정용
    float finishTime2; //아이템 시간 측정용
    float finishTime3; //아이템 시간 측정용
    float finishTime4; //하트 시간 측정용

    bool shield; //실드 사용 여부 체크
    Vector3 pos; //눈사람 위치
    float step = 2; //눈사람 한걸음

    AudioSource audio; //오디오 변수
    public AudioClip jump; //오디오 점프

    public GameObject heli; //헬리콥터 오브젝트
    public GameObject heartb;//깨진하트 오브젝트
    public GameObject shielditem;//실드 
    public GameObject timeagainstitem;//시간을 거스르는자
    public GameObject reverseitem;//거꾸로

    // Start is called before the first frame update
    void Start()
    {
        bh = false; // 하트 안깨진 상태
        htimer = 0.0f;

        heartb = GameObject.Find("heartb");//깨진하트 오브젝트찾기
        shielditem = GameObject.Find("shielditem");//실드 찾기
        timeagainstitem = GameObject.Find("timeagainstitem");//시간을거스르는자 찾기
        reverseitem= GameObject.Find("reverseitem");//거꾸로 찾기

        heartb.SetActive(false);
        shielditem.SetActive(false);
        timeagainstitem.SetActive(false);
        reverseitem.SetActive(false);

        pos = transform.position; //현재 위치 받아오기
        reverse = false; //아이템 reverse 끄기
        time = false; //타임 변수 끄기
        shield = false; //실드 아이템 끄기
        hole_col = false; //구멍 충돌 false로 초기화
        tree_col = false; //나무 충돌 false로 초기화
        car_col = false;  //차 충돌 false로 초기화

        
        startTime1 = 0;  //아이템 시간 변수 초기화
        startTime2 = 0;  //아이템 시간 변수 초기화
        startTime3 = 0;  //아이템 시간 변수 초기화
        startTime4 = 0;  //깨진 하트 시간 변수 초기화

        finishTime1 = 0;  //아이템 시간 변수 초기화
        finishTime2 = 0;  //아이템 시간 변수 초기화
        finishTime3 = 0;  //아이템 시간 변수 초기화
        finishTime4 = 0;  //깨진 하트 시간 변수 초기화

        heart = 3;  //생명 개수 3개로 초기화
        arrow = 0;  //방향키 0으로 초기화
        Score_Mng.score = 0; //점수 0으로 최기화
        audio = gameObject.AddComponent<AudioSource>();  //오디오 소스 받아오기
        audio.clip = jump;  //점프소리 넣기
        audio.loop = false;  //반복 안함

        heartb.SetActive(false); //깨진하트 안보이게
    }

    // Update is called once per frame
    void Update()
    {
        htimer += Time.deltaTime; //깨진하트 시간측정용        

        if(bh==true)
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
        if (arrow == 2)  //아래
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (heart == 0)
            SceneManager.LoadScene("GameOver");

        if (car_col == true)
        {
           if(shield)
            {
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
                    pos = new Vector3(0, 1, -72);
                if (gameObject.transform.position.z >= -66 && gameObject.transform.position.z < -58)
                    pos = new Vector3(0, 1, -66);
                if (gameObject.transform.position.z >= -58 && gameObject.transform.position.z < -50)
                    pos = new Vector3(0, 1, -58);
                if (gameObject.transform.position.z >= -50 && gameObject.transform.position.z < -37)
                    pos = new Vector3(0, 1, -50);
                if (gameObject.transform.position.z >= -37 && gameObject.transform.position.z < -28)
                    pos = new Vector3(0, 1, -36);
                if (gameObject.transform.position.z >= -28 && gameObject.transform.position.z < -20)
                    pos = new Vector3(0, 1, -28);
                if (gameObject.transform.position.z >= -20 && gameObject.transform.position.z < -10)
                    pos = new Vector3(0, 1, -20);
                if (gameObject.transform.position.z >= -10 && gameObject.transform.position.z < -6)
                    pos = new Vector3(0, 1, -10);
                if (gameObject.transform.position.z >= -6 && gameObject.transform.position.z < 0)
                    pos = new Vector3(0, 1, -6);

            }
            if (shield == false)
            {
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
                    pos = new Vector3(0, 1, -72);
                if (gameObject.transform.position.z >= -66 && gameObject.transform.position.z < -58)
                    pos = new Vector3(0, 1, -66);
                if (gameObject.transform.position.z >= -58 && gameObject.transform.position.z < -50)
                    pos = new Vector3(0, 1, -58);
                if (gameObject.transform.position.z >= -50 && gameObject.transform.position.z < -37)
                    pos = new Vector3(0, 1, -50);
                if (gameObject.transform.position.z >= -37 && gameObject.transform.position.z < -28)
                    pos = new Vector3(0, 1, -36);
                if (gameObject.transform.position.z >= -28 && gameObject.transform.position.z < -20)
                    pos = new Vector3(0, 1, -28);
                if (gameObject.transform.position.z >= -20 && gameObject.transform.position.z < -10)
                    pos = new Vector3(0, 1, -20);
                if (gameObject.transform.position.z >= -10 && gameObject.transform.position.z < -6)
                    pos = new Vector3(0, 1, -10);
                if (gameObject.transform.position.z >= -6 && gameObject.transform.position.z < 0)
                    pos = new Vector3(0, 1, -6);

                    
                heart--;

                startTime4 = Time.time;
                finishTime4 = startTime4 + 1f;
                bh = true;
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
        if (pos.z < -98)
            pos.z = -98;

        if (pos.z > 1)
        {
            SceneManager.LoadScene("Continue");
            Score_Mng.score += Mathf.FloorToInt(Timer.timelimit);
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

        if (gameObject.transform.position.z > -98 && gameObject.transform.position.z < -92)
            heli.transform.position = new Vector3(0, 8, -90);
        if (gameObject.transform.position.z > -90 && gameObject.transform.position.z < -88)
            heli.transform.position = new Vector3(0, 8, -86);
        if (gameObject.transform.position.z > -86 && gameObject.transform.position.z < -84)
            heli.transform.position = new Vector3(0, 8, -82);
        if (gameObject.transform.position.z > -82 && gameObject.transform.position.z < -75)
            heli.transform.position = new Vector3(0, 8, -73);
        if (gameObject.transform.position.z > -73 && gameObject.transform.position.z < -68)
            heli.transform.position = new Vector3(0, 8, -66);
        if (gameObject.transform.position.z > -66 && gameObject.transform.position.z < -60)
            heli.transform.position = new Vector3(0, 8, -58);
        if (gameObject.transform.position.z > -58 && gameObject.transform.position.z < -52)
            heli.transform.position = new Vector3(0, 8, -50);
        if (gameObject.transform.position.z > -50 && gameObject.transform.position.z < -39)
            heli.transform.position = new Vector3(0, 8, -37);
        if (gameObject.transform.position.z > -37 && gameObject.transform.position.z < -30)
            heli.transform.position = new Vector3(0, 8, -28);
        if (gameObject.transform.position.z > -28 && gameObject.transform.position.z < -22)
            heli.transform.position = new Vector3(0, 8, -20);
        if (gameObject.transform.position.z > -20 && gameObject.transform.position.z < -12)
            heli.transform.position = new Vector3(0, 8, -10);
        if (gameObject.transform.position.z > -10 && gameObject.transform.position.z < -8)
            heli.transform.position = new Vector3(0, 8, -6);
        if (gameObject.transform.position.z > -6 && gameObject.transform.position.z < 2)
            heli.transform.position = new Vector3(0, 8, 0);

        transform.position = pos;
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
        }

        if (other.gameObject.tag == "Tree")
        {
            tree_col = true;

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