using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    private GameManager gamemanager;
    public Transform WarpTarget;
    Image outImage;
    private float displayTime;
    int f_display = 0;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        Application.targetFrameRate = 60; // ← FPS を60 に設定
        outImage = GameObject.Find("out").GetComponent<Image>();
        outImage.enabled = false;
        f_display = 0; // 表示フラグを初期化する
    }

     void OnTriggerEnter(Collider other)
    {
         //接触したオブジェクトの名称が"WarpTrigger"のとき
        if(other.gameObject.name == "WarpTrigger")
        {
            //"WarapTarget"にワープする
            transform.position = WarpTarget.position;
        }

        //接触したオブジェクトの名称が"ImageTrigger_1"のとき
        if(other.gameObject.name == "ImageTrigger_1")
        {
            if(f_display != 1)
            {
                f_display = 1;
            }
        }

        if(other.gameObject.name == "SETrigger_1")
        {
            gamemanager.PlaySE_1();
        }
        if(other.gameObject.name == "SETrigger_2")
        {
            gamemanager.PlaySE_2();
        }
        if(other.gameObject.name == "SETrigger_3")
        {
            gamemanager.PlaySE_3();
        }
        if(other.gameObject.name == "SETrigger_4")
        {
            gamemanager.PlaySE_4();
        }
        if(other.gameObject.name == "SETrigger_5")
        {
            gamemanager.PlaySE_5();
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
        if (f_display == 1) // "out"の画像を表示している場合だけ時間を合だけ時間を加算する
        {
            outImage.enabled = true;
            // 前のフレームからの経過時間（秒）を加算する
            displayTime += Time.deltaTime;
            if(displayTime >= 3.0f)
            {
                outImage.enabled = false;
                f_display = 0;
                displayTime = 0.0f;
            }
        }
        
    }
} 
