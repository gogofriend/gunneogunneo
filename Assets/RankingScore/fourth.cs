using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fourth : MonoBehaviour
{
    public Text scoreData4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreData4.text = PlayerPrefs.GetInt("FourthScore").ToString() + "초";

    }
}
