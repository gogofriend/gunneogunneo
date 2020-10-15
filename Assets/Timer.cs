using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timelimit; //제한시간
    public Text timert; // 제한시간 텍스트

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage1") // 스테이지 1일 경우 제한시간 50
            timelimit = 50;
        else if (SceneManager.GetActiveScene().name == "Stage2") // 스테이지 2일 경우 제한시간 120
            timelimit = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (timelimit != 0) // 제한시간이 0이 아닐 경우
        {
            // 제한시간 감소
            timelimit -= Time.deltaTime;
            if (timelimit <= 0) //제한시간이 0보다 작아질 경우
            {
                //제한시간을 0으로 바꾸고 GameOver창으로 전환
                timelimit = 0;
                SceneManager.LoadScene("GameOver");
            }
        }

        timert.text = "Time  " + Mathf.FloorToInt(timelimit).ToString(); //타이머 텍스트 내용 업데이트
    }
}
