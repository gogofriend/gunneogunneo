using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class item_drop : MonoBehaviour
{
    float g = 9.8f; //중력 가속도
    public float v = 0; //속도
    int count = 0; //공이 튄 횟수
    public bool isFalling = true; //공의 상태가 떨어지고 있는지 상태인지 확인
    public GameObject hole = null;
    Vector3 hole_pos; //폭탄 아이템 구멍 위치 변수

    void Start()
    {

    }
    void Update()
    {
        if (transform.position.y <= 0.5f) //공의 반지름=0.5 이기때문에 y좌표가 ground 아래로 가면
        {
            isFalling = false; //떨어지는 상태 아님
            count++; // 아이템 공이 튄 횟수 +1
            if (count > 5) // 아이템 공이 5번 이상 튕기면
            {
                count = 0; // 카운트 초기화
                Destroy(gameObject, 0); // 아이템 공 사라짐

                if (hole != null)
                {
                    GameObject Hole = GameObject.Instantiate(hole);
                    hole_pos.x = transform.position.x; // 구멍의 x 위치 = 아이템 공의 x 위치
                    hole_pos.z = transform.position.z; // 구멍의 z 위치 = 아이템 공의 z 위치
                    if (SceneManager.GetActiveScene().name == "Stage1")
                        hole_pos.y = 0.1f; // 스테이지1일 경우 구멍의 y좌표 설정 
                    else if (SceneManager.GetActiveScene().name == "Stage2")
                        hole_pos.y = 0.3f; // 스테이지2일 경우 구멍의 y좌표 설정 
                    Hole.transform.position = hole_pos; // Hole 오브젝트의 위치 저장
                    Hole.transform.parent = null;  //위치 독립
                }
            }
            if (v <= 0)   //속도<=0 이면
            {

                //위로올라감
                v += 1.2f * g * Time.deltaTime; //공이 튀어오를 때 원래 상태보다 덜 올라오기 때문에 2를 곱해줌
                transform.Translate(0, -v * Time.deltaTime, 0); //속도 부호를 바꿔 방향을 바꿔 이동, v*t는 올라오는 거리

            }
        }
        else //허공에 있을 때
        {
            if (isFalling) //떨어지는 상태면
            {
                //아래로 내려감
                v -= g * Time.deltaTime; //중력가속도*시간만큼 속도 감소
                transform.Translate(0, v * Time.deltaTime, 0);//v*t만큼 이동
            }
            else //위로 올라가는 상태
            {
                if (v <= 0) //속도가 0보다 작거나 같으면
                {
                    //위로올라감
                    v += 1.2f * g * Time.deltaTime; //공이 튀어오를 때 원래 상태보다 덜 올라오기 때문에 2를 곱해줌
                    transform.Translate(0, -v * Time.deltaTime, 0); //속도 부호를 바꿔 방향을 바꿈, v*t는 올라오는 거리
                }
                if (v >= 0)//속도가 0보다 크거나 같으면
                {
                    isFalling = true; //떨어짐
                }
            }
        }
    }

}
