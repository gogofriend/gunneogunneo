using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class second : MonoBehaviour
{
    public Text scoreData2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreData2.text = PlayerPrefs.GetInt("SecondScore").ToString() + "점"; //2위 데이터 로드

    }
}
