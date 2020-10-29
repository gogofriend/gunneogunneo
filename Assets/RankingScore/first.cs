using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class first : MonoBehaviour
{
    public Text scoreData1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreData1.text = PlayerPrefs.GetInt("BestScore").ToString() + "점"; //1위 데이터 로드

    }
}
