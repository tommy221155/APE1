using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Transform WarpTarget;
    Image outImage;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // ← FPS を60 に設定
        outImage = GameObject.Find("out").GetComponent<Image>();
        outImage.enabled = false;
    }

     void OnTriggerEnter(Collider other)
    {
         //接触したオブジェクトの名称が"WarpTrigger"のとき
        if(other.gameObject.name == "WarpTrigger")
        {
            //"WarapTarget"にワープする
            transform.position = WarpTarget.position;
        }

        if(other.gameObject.name == "outTrigger")
        {
            outImage.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up")) // ↑なら前（Z 方向）に0.1 だけ進む
        {
            transform.position += transform.forward * 0.1f;
        }
        if (Input.GetKey("down")) // ↓なら-Z 方向に0.1 だけ進む
        {
            transform.position -= transform.forward * 0.1f;
        }
        if (Input.GetKey ("right")) // ←なら Y軸に 3度回転する
        {
            transform.Rotate(0f,3.0f,0f);
        }
        if (Input.GetKey ("left")) // →なら Y軸に -3度回転する
        {
            transform.Rotate(0f, -3.0f, 0f);
        }
    }
} 
