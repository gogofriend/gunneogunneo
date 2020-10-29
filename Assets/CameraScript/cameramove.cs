using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public GameObject player;

    public float offsetX = 0f; //x축 방향으로 캐릭터에서 떨어진 정도
    public float offsetY = 8f; //y축 방향으로 캐릭터에서 떨어진 정도
    public float offsetZ = -9f; //z축 방향으로 캐릭터에서 떨어진 정도

    Vector3 pos; //카메라의 위치 변수
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        pos.x = player.transform.position.x + offsetX; //카메라의 x좌표는 플레이어의 위치에서 offsetX만큼 더한 값
        pos.y = player.transform.position.y + offsetY; //카메라의 y좌표는 플레이어의 위치에서 offsetY만큼 더한 값
        pos.z = player.transform.position.z + offsetZ; //카메라의 z좌표는 플레이어의 위치에서 offsetZ만큼 더한 값

        transform.position = pos;
    }
}