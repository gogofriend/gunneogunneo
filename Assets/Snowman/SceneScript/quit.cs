using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("GameOverCheck"); //GameOverCheck 씬으로 이동
    }

    // Update is called once per frame
    void Update()
    {

    }
}
