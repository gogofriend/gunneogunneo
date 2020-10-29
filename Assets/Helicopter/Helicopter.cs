using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{

    public GameObject item1 = null; //item1 게임오브젝트 
    public GameObject item2 = null; //item2 게임오브젝트 
    public GameObject item3 = null; //item3 게임오브젝트 
    public GameObject item4 = null; //item4 게임오브젝트 
    float TimeLeft = 5.0f; //아이템 생성 시간
    float nextTime = 0.0f; //아이템 생성을 위한 시간변수

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft; //5초가 지나면
            item(); //아이템 함수 호출하여 아이템 생성
        }
    }

    public void item()
    {
        int random = Random.Range(0, 5); //아이템 4개 중에 떨어트릴 것을 랜덤으로 지정


        if (random == 1) //random이 1이라면
        {
            if (item1 != null)
            {
                GameObject Item1 = GameObject.Instantiate(item1); //item1을 복제
                Item1.transform.position = transform.position; //item의 생성 위치는 헬기의 위치랑 같다
                Item1.transform.parent = null; //위치 독립
            }
        }
        if (random == 2) //random이 1이라면
        {
            if (item2 != null)
            {
                GameObject Item2 = GameObject.Instantiate(item2); //item2를 복제
                Item2.transform.position = transform.position; //item의 생성 위치는 헬기의 위치랑 같다
                Item2.transform.parent = null; //위치 독립
            }
        }
        if (random == 3) //random이 3이라면
        {
            if (item3 != null)
            {
                GameObject Item3 = GameObject.Instantiate(item3); //item3를 복제
                Item3.transform.position = transform.position; //item의 생성 위치는 헬기의 위치랑 같다
                Item3.transform.parent = null; //위치 독립
            }
        }
        if (random == 4) //random이 4라면
        {
            if (item4 != null)
            {
                GameObject Item4 = GameObject.Instantiate(item4); //item4를 복제
                Item4.transform.position = transform.position; //item의 생성 위치는 헬기의 위치랑 같다
                Item4.transform.parent = null; //위치 독립
            }
        }
    }
}