using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranking_init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //게임 시작시 랭킹 초기화
        PlayerPrefs.SetInt("FifthScore", 0); //5위 점수 초기화
        PlayerPrefs.SetInt("FourthScore", 0);//4위 점수 초기화
        PlayerPrefs.SetInt("ThirdScore", 0);//3위 점수 초기화
        PlayerPrefs.SetInt("SecondScore", 0);//2위 점수 초기화
        PlayerPrefs.SetInt("BestScore", 0);//1위 점수 초기화
    }

    // Update is called once per frame
    void Update()
    {

    }
}
