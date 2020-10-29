using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
#pragma warning disable 0108
public class Snowman_Move : MonoBehaviour
{
    bool bh;  //깨진하트 확인 변수
    bool reverse; //거꾸로 아이템 체크 변수
    bool time; //시간을 거스르는 자 아이템 체크 변수
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
    public GameObject heartb;//깨진하트아이콘
    public GameObject shielditem;//실드 아이콘
    public GameObject timeagainstitem;//시간을 거스르는자 아이콘
    public GameObject reverseitem;//거꾸로 아이콘

    // Start is called before the first frame update
    void Start()
    {
        bh = false; // 하트 안깨진 상태
        htimer = 0.0f; //깨진 하트 보여지는 시간 측정 변수

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
        shielditem.SetActive(false); //실드아이템 비활성화
        timeagainstitem.SetActive(false); //시간을 거스르는 자 아이템 비활성화
        reverseitem.SetActive(false); //거꾸로 아이템 비활성화
    }

    // Update is called once per frame
    void Update()
    {
        htimer += Time.deltaTime; //깨진하트 시간측정용        

        if(bh==true) //깨진 하트가 나와야 하면
        {
            startTime4 += Time.deltaTime;
            heartb.SetActive(true); //깨진 하트 아이콘 활성화
            if (startTime4 >= finishTime4) //깨진 하트가 보여지는 시간이 끝나면
            {
                heartb.SetActive(false); //깨진 하트 아이콘 비활성화
                bh = false; //깨진 하트 체크 변수를 다시 false로 만들어줌
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
        if (arrow == 2)  //아래
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (heart == 0) //생명이 0이 되면
            SceneManager.LoadScene("GameOver"); //게임오버 씬을 불러옴

        if (car_col == true) //차와 충돌하면
        {
           if(shield) //'실드' 아이템이 작동중이면
            {
                //목숨이 줄어들지 않고 장애물을 통과해서 지나간다
            }
            if (shield == false) //'실드' 아이템이 작동중이지 않으면
            {
                //죽으면 눈사람을 가까운 그라운드로 리스폰함
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

                    
                heart--; //생명을 차감함

                startTime4 = Time.time;
                finishTime4 = startTime4 + 1f; //1초동안
                bh = true; //깨진 하트 보여짐
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
                objArray[i].gameObject.transform.position -= (new Vector3(8, 0, 0) * Time.deltaTime); //Car 태그의 차들을 멈춤
            for (int i = 0; i < objArray2.Length; i++)
                objArray2[i].gameObject.transform.position += (new Vector3(8, 0, 0) * Time.deltaTime); //Car2 태그의 차들을 멈춤

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
                shield = false; //'실드' 아이템 체크 변수를 다시 false로 만들어줌
            }
        }

        if (pos.x > 10) //맵의 x축 제한범위 설정
            pos.x = 10;
        if (pos.x < -14) //맵의 x축 제한범위 설정
            pos.x = -14;
        if (pos.z < -98) //맵의 z축 제한범위 설정
            pos.z = -98;

        if (pos.z > 1) //눈사람이 Finish Line에 도착하면
        {
            SceneManager.LoadScene("Continue"); //계속할지를 묻는 씬을 불러옴
            Score_Mng.score += Mathf.FloorToInt(Timer.timelimit); // 남은 시간을 스테이지2 종료후 저장할 랭킹 점수에 반영
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
        if (gameObject.transform.position.z > -98 && gameObject.transform.position.z < -92)
            heli.transform.position = new Vector3(-4.000001f, 8, -90);
        if (gameObject.transform.position.z > -90 && gameObject.transform.position.z < -88)
            heli.transform.position = new Vector3(-4.000001f, 8, -86);
        if (gameObject.transform.position.z > -86 && gameObject.transform.position.z < -84)
            heli.transform.position = new Vector3(-4.000001f, 8, -82);
        if (gameObject.transform.position.z > -82 && gameObject.transform.position.z < -75)
            heli.transform.position = new Vector3(-4.000001f, 8, -73);
        if (gameObject.transform.position.z > -73 && gameObject.transform.position.z < -68)
            heli.transform.position = new Vector3(-4.000001f, 8, -66);
        if (gameObject.transform.position.z > -66 && gameObject.transform.position.z < -60)
            heli.transform.position = new Vector3(-4.000001f, 8, -58);
        if (gameObject.transform.position.z > -58 && gameObject.transform.position.z < -52)
            heli.transform.position = new Vector3(-4.000001f, 8, -50);
        if (gameObject.transform.position.z > -50 && gameObject.transform.position.z < -39)
            heli.transform.position = new Vector3(-4.000001f, 8, -37);
        if (gameObject.transform.position.z > -37 && gameObject.transform.position.z < -30)
            heli.transform.position = new Vector3(-4.000001f, 8, -28);
        if (gameObject.transform.position.z > -28 && gameObject.transform.position.z < -22)
            heli.transform.position = new Vector3(-4.000001f, 8, -20);
        if (gameObject.transform.position.z > -20 && gameObject.transform.position.z < -12)
            heli.transform.position = new Vector3(-4.000001f, 8, -10);
        if (gameObject.transform.position.z > -10 && gameObject.transform.position.z < -8)
            heli.transform.position = new Vector3(-4.000001f, 8, -6);
        if (gameObject.transform.position.z > -6 && gameObject.transform.position.z < 2)
            heli.transform.position = new Vector3(-4.000001f, 8, 0);
        
        transform.position = pos;
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
        if (other.gameObject.tag == "time") //'시간을 거스르는 자'아이템을 먹은 경우
        {

            startTime2 = Time.time;
            finishTime2 = startTime2 + 3f; //3초동안
            time = true; //'시간을 거스르는 자' 아이템 동작

            Destroy(other.gameObject, 0); //제한 시간 안에 아이템을 먹지 않으면 소멸

        }
        if (other.gameObject.tag == "shield") //'실드'아이템을 먹은 경우
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