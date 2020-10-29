using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car_Move2 : MonoBehaviour
{
    public GameObject player;
    Vector3 pos; //자동차의 위치변수
    float speed; //자동차의 속도변수
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Snowman");
        speed = 6.5f; //초기 속도
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "Stage1") //Stage1의 차 속도가 도착점에 가까워질수록 점점 빨라짐
        {   
            if (player.transform.position.z >= -98 && player.transform.position.z < -73)
                speed = 6.5f;
            if (player.transform.position.z >= -73 && player.transform.position.z < -50)
                speed = 7.0f;
            if (player.transform.position.z >= -50 && player.transform.position.z < -20)
                speed = 7.5f;
            if (player.transform.position.z >= -20 && player.transform.position.z < 0)
                speed = 8.0f;
        }
        else if (SceneManager.GetActiveScene().name == "Stage2") //Stage2의 차 속도가 도착점에 가까워질수록 점점 빨라짐
        {
            if (player.transform.position.z >= 52 && player.transform.position.z < 102)
                speed = 6.5f;
            if (player.transform.position.z >= 102 && player.transform.position.z < 136)
                speed = 7.0f;
            if (player.transform.position.z >= 136 && player.transform.position.z < 180)
                speed = 7.5f;
            if (player.transform.position.z >= 180 && player.transform.position.z < 224)
                speed = 8.0f;
            if (player.transform.position.z >= 224 && player.transform.position.z < 240)
                speed = 8.5f;
            if (player.transform.position.z >= 240 && player.transform.position.z < 250)
                speed = 9.0f;
        }
        gameObject.transform.position -= (new Vector3(speed, 0, 0) * Time.deltaTime); //차가 8의 속도로 반대 방향으로 이동함.
        pos = gameObject.transform.position; //차의 위치가 계속 갱신한다.

        if (pos.x < -28) //차가 일정한 거리까지 가면
            pos.x = 20; //다시 돌아와서 계속 반복해서 차가 갈수 있도록 한다. 


        gameObject.transform.position = pos;

    }
}