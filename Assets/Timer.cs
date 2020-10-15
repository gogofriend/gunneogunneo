using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timelimit;
    public Text timert;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage1")
            timelimit = 50;
        else if (SceneManager.GetActiveScene().name == "Stage2")
            timelimit = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if(timelimit != 0)
        {
            timelimit -= Time.deltaTime;
            if (timelimit <= 0)
            {
                timelimit = 0;
                SceneManager.LoadScene("GameOver");
            }
        }

        timert.text = "Time  " + Mathf.FloorToInt(timelimit).ToString();
    }
}
