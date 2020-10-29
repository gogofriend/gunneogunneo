using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score_Mng : MonoBehaviour
{
    public static int score; //점수 저장 변수

    public Text scoreData1; // 1위 점수 텍스트 
    public Text scoreData2; // 2위 점수 텍스트 
    public Text scoreData3; // 3위 점수 텍스트 
    public Text scoreData4; // 4위 점수 텍스트 
    public Text scoreData5; // 5위 점수 텍스트 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreData1.text = PlayerPrefs.GetInt("BestScore").ToString() + "점"; // 1위 점수 텍스트 내용 업데이트
        scoreData2.text = PlayerPrefs.GetInt("SecondScore").ToString() + "점"; // 2위 점수 텍스트 내용 업데이트
        scoreData3.text = PlayerPrefs.GetInt("ThirdScore").ToString() + "점"; // 3위 점수 텍스트 내용 업데이트
        scoreData4.text = PlayerPrefs.GetInt("FourthScore").ToString() + "점";  // 4위 점수 텍스트 내용 업데이트
        scoreData5.text = PlayerPrefs.GetInt("FifthScore").ToString() + "점"; // 5위 점수 텍스트 내용 업데이트
    }

    public static void Save()  //점수 데이터 저장
    {
        if (score < PlayerPrefs.GetInt("BestScore")) // 1위 점수보다 작을 경우
        {
            if (score < PlayerPrefs.GetInt("SecondScore")) //2위 점수보다 작을 경우
            {
                if (score < PlayerPrefs.GetInt("ThirdScore")) //3위 점수보다 작을 경우
                {
                    if (score < PlayerPrefs.GetInt("FourthScore"))  //4위 점수보다 작을 경우
                    {
                        if (score < PlayerPrefs.GetInt("FifthScore"))  //5위 점수보다 작을 경우
                            return; //저장하지 않음
                        //5등일때
                        PlayerPrefs.SetInt("FifthScore", score);  //5위에 점수 저장
                        return;
                    }
                    //4등일때
                    PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore")); // 기존 4위 점수를 5위로 옮김
                    PlayerPrefs.SetInt("FourthScore", score); //4위에 점수 저장
                    return;
                }
                //3등일때
                PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore")); // 기존 4위 점수를 5위로 옮김
                PlayerPrefs.SetInt("FourthScore", PlayerPrefs.GetInt("ThirdScore")); // 기존 3위 점수를 4위로 옮김
                PlayerPrefs.SetInt("ThirdScore", score); //3위에 점수 저장
                return;
            }
            //2등일때
            PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore"));
            PlayerPrefs.SetInt("FourthScore", PlayerPrefs.GetInt("ThirdScore"));
            PlayerPrefs.SetInt("ThirdScore", PlayerPrefs.GetInt("SecondScore"));
            PlayerPrefs.SetInt("SecondScore", score); //2위에 점수 저장
            return;
        }
        //1등일때
        if (score == PlayerPrefs.GetInt("BestScore")) //1등 점수가 같을 경우 저장하지 않음
            return;
        PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore")); // 기존 4위 점수를 5위로 옮김
        PlayerPrefs.SetInt("FourthScore", PlayerPrefs.GetInt("ThirdScore")); // 기존 3위 점수를 4위로 옮김
        PlayerPrefs.SetInt("ThirdScore", PlayerPrefs.GetInt("SecondScore")); // 기존 2위 점수를 3위로 옮김
        PlayerPrefs.SetInt("SecondScore", PlayerPrefs.GetInt("BestScore")); // 기존 1위 점수를 2위로 옮김
        PlayerPrefs.SetInt("BestScore", score); //1위에 점수 저장
    }


}
