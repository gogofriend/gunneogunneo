using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public GameObject player;

    public float offsetX = 0f;
    public float offsetY = 8f;
    public float offsetZ = -9f;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        pos.x = player.transform.position.x + offsetX;
        pos.y = player.transform.position.y + offsetY;
        pos.z = player.transform.position.z + offsetZ;

        transform.position = pos;
    }
}
