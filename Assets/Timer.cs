using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timelimit = 50;
    public Text timert;

    // Start is called before the first frame update
    void Start()
    {
        
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

        timert.text = Mathf.FloorToInt(timelimit).ToString();
    }
}
