using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class third : MonoBehaviour
{
    public Text scoreData3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreData3.text = PlayerPrefs.GetInt("ThirdScore").ToString() + "초"; //3위 데이터 로드

    }
}
