using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inputranking : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField InputText;
    public void onStart()
    {
        SceneManager.LoadScene("Ranking");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Test(Text text)
    {
        text.text = InputText.text;
    }
}