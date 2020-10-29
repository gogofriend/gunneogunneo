using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameObject[] objArray = GameObject.FindGameObjectsWithTag("Car"); // Car태그 설정 오브젝트 찾기
        GameObject[] objArray2 = GameObject.FindGameObjectsWithTag("Car2"); // Car2 태그 오브젝트 찾기

        for (int i = 0; i < objArray.Length; i++) //Car 태그된 차들의 움직임을 구현한 스크립트 활성화
        {
            objArray[i].gameObject.GetComponent<Car_Move>().enabled = true;
            objArray[i].gameObject.GetComponent<Car_Move2>().enabled = false;
        }
        for (int i = 0; i < objArray2.Length; i++) //Car2 태그된 차들의 움직임을 구현한 스크립트 활성화
        {

            objArray2[i].gameObject.GetComponent<Car_Move>().enabled = false;
            objArray2[i].gameObject.GetComponent<Car_Move2>().enabled = true;

        }



    }

    // Update is called once per frame
    void Update()
    {


    }
}