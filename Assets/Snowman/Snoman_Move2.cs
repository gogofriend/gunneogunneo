using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#pragma warning disable 0108
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
    float speed; // 차 스피드

    public Text scoreData1; //랭킹 1위
    public Text scoreData2; //랭킹 2위
    public Text scoreData3; //랭킹 3위
    public Text scoreData4; //랭킹 4위
    public Text scoreData5; //랭킹 5위

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

    AudioSource audio; //오디오 변수
    public AudioClip jump; //오디오 점프

    public GameObject heli; //헬리콥터 오브젝트
    public GameObject heartb; //깨진하트 아이콘
    public GameObject shielditem; //실드 아이콘
    public GameObject timeagainstitem; //시간을 거스르는자 아이콘
    public GameObject reverseitem; //거꾸로 아이콘
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

        heartb = GameObject.Find("heartb"); //깨진하트아이콘 찾기
        shielditem = GameObject.Find("shielditem"); //실드아이콘 찾기
        timeagainstitem = GameObject.Find("timeagainstitem"); //시간을거스르는자아이콘 찾기
        reverseitem = GameObject.Find("reverseitem"); //거꾸로아이콘 찾기

        heartb.SetActive(false); //깨진하트아이콘 안보이게
        shielditem.SetActive(false); //실드아이템 아이콘 비활성화
        timeagainstitem.SetActive(false); //시간을 거스르는 자 아이템 아이콘 비활성화
        reverseitem.SetActive(false); //거꾸로 아이템 아이콘 비활성화
    }

    // Update is called once per frame
    void Update()
    {

        Car_Move carmovespeed = GameObject.FindGameObjectWithTag("Car").GetComponent<Car_Move>(); //Car_Move스크립트를 불러옴
        speed = carmovespeed.speed; //Car_Move스크립트의 speed변수를 넣어줌
        htimer += Time.deltaTime; //깨진하트 시간측정용        

        if (bh == true) //깨진 하트가 나와야 하면
        {
            startTime4 += Time.deltaTime;
            heartb.SetActive(true); //깨진 하트 아이콘 활성화
            if (startTime4 >= finishTime4) //깨진 하트가 보여지는 시간이 끝나면
            {
                heartb.SetActive(false); //깨진 하트 아이콘 비활성화
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

        if (tree_col == true) //나무와 충돌했을 때 눈사람 위치 설정
        {
       
                if (arrow == 1) //앞으로 가다 부딪혔을 때
                {
                    pos -= new Vector3(0, 0, 2);
                }
                if (arrow == 2) //뒤로 가다 부딪혔을 때
                {
                    pos += new Vector3(0, 0, 2);
                }
                if (arrow == 3) //오른쪽으로 가다 부딪혔을 때
                {
                    pos -= new Vector3(2, 0, 0);
                }
                if (arrow == 4) //왼쪽으로 가다 부딪혔을 때
                {
                    pos += new Vector3(2, 0, 0);
                }
                tree_col = false; //나무 충돌 여부 변수를 다시 false로 만들어줌
           
        }

        if (hole_col == true) //폭탄 터진 구멍과 충돌했을 때 눈사람 위치 설정
        {
            if (arrow == 1) //앞으로 가다 부딪혔을 때
            {
                pos -= new Vector3(0, 0, 2);
            }
            if (arrow == 2) //뒤로 가다 부딪혔을 때
            {
                pos += new Vector3(0, 0, 2);
            }
            if (arrow == 3) //오른쪽으로 가다 부딪혔을 때
            {
                pos -= new Vector3(2, 0, 0);
            }
            if (arrow == 4) //왼쪽으로 가다 부딪혔을 때
            {
                pos += new Vector3(2, 0, 0);
            }
            hole_col = false; //구멍 충돌 여부 변수를 다시 false로 만들어줌
        }

        if (reverse == false) //'거꾸로' 아이템이 작동하지 않을 때 스노우맨의 이동 구현
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
        if (reverse) //'거꾸로' 아이템이 작동할 때 스노우맨의 이동 구현
        {
            reverseitem.SetActive(true); //거꾸로 아이템 아이콘 활성화
            startTime1 += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                pos += transform.forward * step;
                arrow = 1;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                pos += transform.forward * step;
                arrow = 2;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                pos += transform.forward * step;
                arrow = 3;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                pos += transform.forward * step;
                arrow = 4;
            }
            if (startTime1 >= finishTime1) //제한 시간이 끝나면
            {
                reverseitem.SetActive(false); //아이템 아이콘 비활성화
                reverse = false; //'거꾸로' 아이템 체크 변수를 다시 false로 만들어줌
            }
        }
        if (time) //'시간을 거스르는 자' 아이템이 작동할 때 스노우맨의 이동 구현
        {
            timeagainstitem.SetActive(true); //시간을 거스르는 자 아이템 아이콘 활성화
            startTime2 += Time.deltaTime;

            GameObject[] objArray = GameObject.FindGameObjectsWithTag("Car"); //오른쪽->왼쪽으로 이동하는 차들을 Tag를 이용해서 배열 저장
            GameObject[] objArray2 = GameObject.FindGameObjectsWithTag("Car2"); //왼쪽->오른쪽으로 이동하는 차들의 Tag이용하여 오브젝트 배열 저장

            for (int i = 0; i < objArray.Length; i++)
                objArray[i].gameObject.transform.position -= (new Vector3(speed, 0, 0) * Time.deltaTime); //Car 태그의 차들을 멈춤
            for (int i = 0; i < objArray2.Length; i++)
                objArray2[i].gameObject.transform.position += (new Vector3(speed, 0, 0) * Time.deltaTime); //Car2 태그의 차들을 멈춤

            if (startTime2 >= finishTime2) //제한 시간이 끝나면
            {
                timeagainstitem.SetActive(false); //아이템 아이콘 비활성화
                time = false; //'시간을 거스르는 자' 아이템 체크 변수를 다시 false로 만들어줌
            }
        }
        if (shield) //'실드' 아이템이 작동할 때
        {
            shielditem.SetActive(true); //실드 아이템 아이콘 활성화
            startTime3 += Time.deltaTime;
            if (startTime3 >= finishTime3) //제한 시간이 끝나면
            {
                shielditem.SetActive(false); //아이템 아이콘 비활성화
                shield = false;//'실드' 아이템 체크 변수를 다시 false로 만들어줌
            }
        }

        if (pos.x > 10) //맵의 x축 제한범위 설정
            pos.x = 10;
        if (pos.x < -14) //맵의 x축 제한범위 설정
            pos.x = -14;
        if (pos.z < 52) //맵의 z축 제한범위 설정
            pos.z = 52;

        if (pos.z > 250) //눈사람이 Finish Line에 도착하면
        {
            Score_Mng.score += Mathf.FloorToInt(Timer.timelimit); //게임 시간을 점수에 더함
            Score_Mng.score += 150;
            Score_Mng.Save(); // 점수 데이터를 소팅 후 랭킹에 저장
            Load(); //랭킹 텍스트 업데이트
            SceneManager.LoadScene("Ranking"); //랭킹 씬을 불러옴
        }

        //눈사람 이동 효과음 적용
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

        //눈사람의 이동에 따른 헬리콥터 위치 변화 설정
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

        transform.position = pos;
    }
    public void Load() //랭킹 Panel의 text에 점수를 로드
    {
        scoreData1.text = PlayerPrefs.GetInt("BestScore").ToString() + "점";
        scoreData2.text = PlayerPrefs.GetInt("SecondScore").ToString() + "점";
        scoreData3.text = PlayerPrefs.GetInt("ThirdScore").ToString() + "점";
        scoreData4.text = PlayerPrefs.GetInt("FourthScore").ToString() + "점";
        scoreData5.text = PlayerPrefs.GetInt("FifthScore").ToString() + "점";
    }
    void OnTriggerEnter(Collider other) //충돌 구현
    {
        if (other.gameObject.tag == "Car2") //Car2 태그가 된 차와 충돌했을 경우
        {
            car_col = true; //차 충돌 여부 변수를 true로 만들어줌
        }
        if (other.gameObject.tag == "Car") //Car 태그가 된 차와 충돌했을 경우
        {
            car_col = true; //차 충돌 여부 변수를 true로 만들어줌
        }
        if (other.gameObject.tag == "reverse") //'거꾸로'아이템을 먹은 경우
        {
            startTime1 = Time.time;
            finishTime1 = startTime1 + 3f; //3초동안
            reverse = true; //'거꾸로' 아이템 동작

            Destroy(other.gameObject, 0); //제한 시간 안에 아이템을 먹지 않으면 소멸

        }
        if (other.gameObject.tag == "time")
        {

            startTime2 = Time.time;
            finishTime2 = startTime2 + 3f; //3초동안
            time = true; //'시간을 거스르는 자' 아이템 동작

            Destroy(other.gameObject, 0); //제한 시간 안에 아이템을 먹지 않으면 소멸

        }
        if (other.gameObject.tag == "shield")
        {
            startTime3 = Time.time;
            finishTime3 = startTime3 + 3f; //3초동안
            shield = true; //'실드' 아이템 동작

            Destroy(other.gameObject, 0); //제한 시간 안에 아이템을 먹지 않으면 소멸
        }

        if (other.gameObject.tag == "bomb") //'폭탄'아이템을 먹은 경우
        {
            SceneManager.LoadScene("GameOver"); //게임오버 씬을 불러옴
        }

        if (other.gameObject.tag == "hole") //폭탄 터진 구멍과 충돌한 경우
        {
            hole_col = true; //구멍 충돌 여부 변수를 true로 만들어줌
        }

        if (other.gameObject.tag == "Tree") //나무와 충돌한 경우
        {
            tree_col = true; //나무 충돌 여부 변수를 true로 만들어줌
        }


    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 60;
        style.normal.textColor = Color.black;

        string str = "      X " + heart; //좌측 상단 하트의 개수 표시
        GUI.Label(new Rect(25, 30, 100, 20), str, style); //텍스트 위치, 크기, 색 설정
    }
}