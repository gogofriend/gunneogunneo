using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score_Mng : MonoBehaviour
{
    public static int score;

    public Text scoreData1;
    public Text scoreData2;
    public Text scoreData3;
    public Text scoreData4;
    public Text scoreData5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreData1.text = PlayerPrefs.GetInt("BestScore").ToString() + "초";
        scoreData2.text = PlayerPrefs.GetInt("SecondScore").ToString() + "초";
        scoreData3.text = PlayerPrefs.GetInt("ThirdScore").ToString() + "초";
        scoreData4.text = PlayerPrefs.GetInt("FourthScore").ToString() + "초";
        scoreData5.text = PlayerPrefs.GetInt("FifthScore").ToString() + "초";
    }

    public static void Save()  //점수 데이터를 저장함
    {
        if (score < PlayerPrefs.GetInt("BestScore"))
        {
            if (score < PlayerPrefs.GetInt("SecondScore"))
            {
                if (score < PlayerPrefs.GetInt("ThirdScore"))
                {
                    if (score < PlayerPrefs.GetInt("FourthScore"))
                    {
                        if (score < PlayerPrefs.GetInt("FifthScore"))
                            return;
                        //5등일때
                        PlayerPrefs.SetInt("FifthScore", score);
                        return;
                    }
                    //4등일때
                    PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore"));
                    PlayerPrefs.SetInt("FourthScore", score);
                    return;
                }
                //3등일때
                PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore"));
                PlayerPrefs.SetInt("FourthScore", PlayerPrefs.GetInt("ThirdScore"));
                PlayerPrefs.SetInt("ThirdScore", score);
                return;
            }
            //2등일때
            PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore"));
            PlayerPrefs.SetInt("FourthScore", PlayerPrefs.GetInt("ThirdScore"));
            PlayerPrefs.SetInt("ThirdScore", PlayerPrefs.GetInt("SecondScore"));
            PlayerPrefs.SetInt("SecondScore", score);
            return;
        }
        //1등일때
        if (score == PlayerPrefs.GetInt("BestScore")) return;
        PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore"));
        PlayerPrefs.SetInt("FourthdScore", PlayerPrefs.GetInt("ThirdScore"));
        PlayerPrefs.SetInt("ThirdScore", PlayerPrefs.GetInt("SecondScore"));
        PlayerPrefs.SetInt("SecondScore", PlayerPrefs.GetInt("BestScore"));
        PlayerPrefs.SetInt("BestScore", score);
    }


}
