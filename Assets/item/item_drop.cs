using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_drop : MonoBehaviour
{
    float g = 9.8f; //중력 가속도
    public float v = 0; //속도
    int count = 0;
    public bool isFalling = true; //공의 상태가 떨어지고 있는지 상태인지 확인
    public GameObject hole = null;
    Vector3 hole_pos;
    void Start()
    {

    }
    void Update()
    {
        if (transform.position.y <= 0.5f) //공의 반지름=0.5 이기때문에 y좌표가 ground 아래로 가면
        {
            isFalling = false; //떨어지는 상태 아님
             count++;
            if(count>5)
            {
                count = 0;
                Destroy(gameObject, 0);

                if (hole != null)
                {
                    GameObject Hole = GameObject.Instantiate(hole);
                    hole_pos.x = transform.position.x;
                    hole_pos.z = transform.position.z;
                    hole_pos.y = 0.1f;
                    Hole.transform.position = hole_pos;
                    Hole.transform.parent = null;
                }
            }
            if (v <= 0)   //속도<=0 이면
            {

                //위로올라감
                v += 1.2f* g * Time.deltaTime; //공이 튀어오를 때 원래 상태보다 덜 올라오기 때문에 2를 곱해줌
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
                    v += 1.2f*g * Time.deltaTime; //공이 튀어오를 때 원래 상태보다 덜 올라오기 때문에 2를 곱해줌
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
