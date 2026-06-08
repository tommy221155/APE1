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
    private int isPlanet1;
    

    //ワープ先のオブジェクトの宣言
    public Transform MeiroStart;
    public Transform CheckPoint;
    public Transform LauncherPoint;

    //ワープ後に向く先のオブジェクトの宣言
    public Transform lookTarget_1;
    public Transform lookTarget_2;
    public Transform lookTarget_3;

    // Start is called before the first frame update
    void Start()
    {
        position_start = transform.position; // 初期位置を格納
        gamemanager = FindObjectOfType<GameManager>();
        Application.targetFrameRate = 60; // ← FPS を60 に設定
        isPlanet1 = 0;
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

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Planet1Ground"))
        {
            isPlanet1 = 1;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Planet1Ground"))
        {
            isPlanet1 = 0;
        }
    }

    private void WarpToStart()
    {
        // 初期位置へワープ
        transform.position = MeiroStart.position;
        if(lookTarget_1 != null)
        {
            transform.rotation = lookTarget_1.rotation;
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

    private void WarpToLauncher()
    {
        transform.position = LauncherPoint.position;
        if(lookTarget_2 != null)
        {
            transform.rotation = lookTarget_2.rotation;
        }
        else
        {
            Debug.LogWarning("null LookTarget_2.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // テスト用のコード．完成前に消す(つもりだったが面白いので残す)
        if(isPlanet1 == 1)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
            WarpToLauncher();
            }
            if(Input.GetKeyDown(KeyCode.O))
            {
            WarpToCheck();
            }
        }
    }
} 
