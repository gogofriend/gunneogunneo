using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move2 : MonoBehaviour
{

    Vector3 pos; //자동차의 위치변수
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= (new Vector3(8, 0, 0) * Time.deltaTime); //차가 8의 속도로 반대 방향으로 이동함.
        pos = gameObject.transform.position; //차의 위치가 계속 갱신한다.

        if (pos.x < -28) //차가 일정한 거리까지 가면
            pos.x = 20; //다시 돌아와서 계속 반복해서 차가 갈수 있도록 한다. 


        gameObject.transform.position = pos;

    }
}