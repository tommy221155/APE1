using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseViewpoint : MonoBehaviour
{
    private float mouseSensitivity = 3.0f;
    private float mouseX;
    private float mouseY;
    private float Rotation_X = 0;
    private float Rotation_Y = 0;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの移動量を取得
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        Rotation_X = mouseX;
        Rotation_Y = -mouseY;
        
        transform.RotateAround(player.transform.position, Vector3.up, Rotation_X); // Y軸に対して回転させる処理
        transform.RotateAround(player.transform.position, transform.right, Rotation_Y); // X軸に対して回転させる処理
    }
}
