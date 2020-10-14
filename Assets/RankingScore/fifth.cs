using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fifth : MonoBehaviour
{
    public Text scoreData5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreData5.text = PlayerPrefs.GetInt("FifthScore").ToString() + "초";
    }
}
