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

    //ワープ先のオブジェクトの宣言
    public Transform WarpTarget;
    public Transform CheckPoint;

    //ワープ後に向く先のオブジェクトの宣言
    public Transform lookTarget_1;
    public Transform lookTarget_2;
    public Transform lookTarget_3;

    // Start is called before the first frame update
    void Start()
    {
        position_start = transform.position; // 初期位置を格納
        gamemanager = FindObjectOfType<GameManager>();
        Application.targetFrameRate = 120; // ← FPS を60 に設定
        
    }

    void OnTriggerEnter(Collider other)
    {
         //接触したオブジェクトの名称が"WarpToStartTrigger"のとき
        if(other.gameObject.name == "WarpToStartTrigger")
        {
            //初期位置にワープする関数の呼び出し
            gamemanager.PlaySE_Warp();
            WarpToStart();
        }

        if(other.gameObject.name == "WarpToCheckTrigger")
        {
            //初期位置にワープする関数の呼び出し
            gamemanager.PlaySE_Warp();
            WarpToCheck();
        }

        //接触したオブジェクトの名称が"ImageTrigger_1"のとき
        if(other.gameObject.name == "ImageTrigger_1")
        {
            gamemanager.DisplayImage_1();
        }
        if(other.gameObject.name == "ImageTrigger_2")
        {
            gamemanager.DisplayImage_2();
        }
        if(other.gameObject.name == "ImageTrigger_3")
        {
            gamemanager.DisplayImage_3();
        }

        if(other.gameObject.CompareTag("SETrigger_1"))
        {
            gamemanager.PlaySE_1();
        }
        if(other.gameObject.CompareTag("SETrigger_2"))
        {
            gamemanager.PlaySE_2();
        }
        if(other.gameObject.CompareTag("SETrigger_3"))
        {
            gamemanager.PlaySE_3();
        }
        if(other.gameObject.CompareTag("SETrigger_4"))
        {
            gamemanager.PlaySE_4();
        }
        if(other.gameObject.CompareTag("SETrigger_5"))
        {
            gamemanager.PlaySE_5();
        }
        if(other.gameObject.CompareTag("InversionTrigger"))
        {
            gamemanager.PlaySE_konran();
            gamemanager.Inversion();
        }
    }

    private void WarpToStart()
    {
        // 初期位置へワープ
        transform.position = position_start;
        if(lookTarget_1 != null)
        {
            transform.rotation = lookTarget_1.rotation;
        }
    }

    private void WarpToTarget()
    {
        transform.position = WarpTarget.position;
        if(lookTarget_2 != null)
        {
            transform.rotation = lookTarget_2.rotation;
        }
        else
        {
            Debug.LogWarning("null LookTarget_2.");
        }
    }

    private void WarpToCheck()
    {
        transform.position = CheckPoint.position;
        if(lookTarget_3 != null)
        {
            transform.rotation = lookTarget_3.rotation;
        }
        else
        {
            Debug.LogWarning("null LookTarget_3.");
        }
    }

    // Update is called once per frame
    void Update()
    {
      // テスト用のコード．完成前に消す
        if(Input.GetKeyDown(KeyCode.I))
        {
            WarpToTarget();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            WarpToCheck();
        }
    }
} 
