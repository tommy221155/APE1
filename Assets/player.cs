using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    Transform myTransform; // transform情報を格納する変数
    Vector3 position_start; // 物体の初期位置を格納する変数
    private GameManager gamemanager;
    public Transform WarpTarget;
    private float displayTime;

    // Start is called before the first frame update
    void Start()
    {
        position_start = transform.position;
        gamemanager = FindObjectOfType<GameManager>();
        Application.targetFrameRate = 60; // ← FPS を60 に設定
        
    }

     void OnTriggerEnter(Collider other)
    {
         //接触したオブジェクトの名称が"WarpToStartTrigger"のとき
        if(other.gameObject.name == "WarpToStartTrigger")
        {
            //初期位置にワープする
            transform.position = position_start;
        }

        //接触したオブジェクトの名称が"ImageTrigger_1"のとき
        if(other.gameObject.name == "ImageTrigger_1")
        {
            gamemanager.DisplayImage_1();
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
        if(other.gameObject.name == "InversionTrigger")
        {
            gamemanager.Inversion();
            gamemanager.PlaySE_konran();
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
} 
