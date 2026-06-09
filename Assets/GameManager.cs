using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //オブジェクトの宣言
    private AudioSource audioSource = null;
    public AudioClip SE_1;
    public AudioClip SE_2;
    public AudioClip SE_3;
    public AudioClip SE_4;
    public AudioClip SE_5;
    public AudioClip SE_Image_1;
    public AudioClip SE_Image_2;
    public AudioClip SE_Image_3;
    public AudioClip SE_konran;
    public AudioClip SE_warning;
    public AudioClip SE_Launcher;
    public AudioClip SE_Warp;
    public Image Image_1;
    public Image Image_2;
    public Image Image_3;

    //パラメータの宣言
    private float displayTime;
    private int f_display = 0; // 画像表示用のフラッグ
    private float InversionTime;
    private int f_Inversion = 0; // 操作反転のフラッグ
    
    public int F_Inversion
    {
        get{return f_Inversion;}
    }

    // Start is called before the first frame update
    void Start()
    {
        Image_1.enabled = false; //初期設定では表示しない
        Image_2.enabled = false;
        Image_3.enabled = false;
        f_display = 0; // 表示フラグを初期化する
        audioSource = GetComponent<AudioSource>();
    }

    // SE再生用の関数
    public void PlaySE_1()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(SE_1); //SE_1 の再生
        }
        else
        {
            Debug.Log("audiosource=null"); //デバッグログ用コード
        }
    }
    public void PlaySE_2()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(SE_2);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }
    public void PlaySE_3()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(SE_3);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }
    public void PlaySE_4()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(SE_4);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }
    public void PlaySE_5()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(SE_5);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }
    public void PlaySE_konran()
    {
        if (audioSource != null)
        {
            if (f_Inversion == 0)
            {
                audioSource.PlayOneShot(SE_konran);
            }
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }
    public void PlaySE_warning()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(SE_warning);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }
    public void PlaySE_Launcher()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(SE_Launcher);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }
    public void PlaySE_Warp()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(SE_Warp);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }

    //画像表示用の関数
    public void DisplayImage_1()
    {
        if(f_display != 1)
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(SE_Image_1);
            }
            else
            {
                Debug.Log("audiosource=null");
            }
            f_display = 1; //表示フラッグを立てる
        }
    }
    public void DisplayImage_2()
    {
        if(f_display != 2)
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(SE_Image_2);
            }
            else
            {
                Debug.Log("audiosource=null");
            }
            f_display = 2; //表示フラッグを立てる
        }
    }
    public void DisplayImage_3()
    {
        if(f_display != 3)
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(SE_Image_3);
            }
            else
            {
                Debug.Log("audiosource=null");
            }
            f_display = 3; //表示フラッグを立てる
        }
    }

    //操作反転用の関数
    public void Inversion()
    {
        if(f_Inversion != 1)
        {
            f_Inversion = 1; //反転フラッグを立てる
        }
    }

// Update is called once per frame
    void Update()
    {
        if (f_display == 1) 
        {
            Image_1.enabled = true; //"Image_1"を表示する
            displayTime += Time.deltaTime; //表示時間を加算する
            if(displayTime >= 3.0f) //三秒表示したら
            {
                Image_1.enabled = false; //"Image_1"を非表示にする
                f_display = 0; //表示フラッグをリセット
                displayTime = 0.0f; //表示時間をリセット
            }
        }

        if (f_display == 2) 
        {
            Image_2.enabled = true; //"Image_1"を表示する
            displayTime += Time.deltaTime; //表示時間を加算する
            if(displayTime >= 3.0f) //三秒表示したら
            {
                Image_2.enabled = false; //"Image_1"を非表示にする
                f_display = 0; //表示フラッグをリセット
                displayTime = 0.0f; //表示時間をリセット
            }
        }

        if (f_display == 3) 
        {
            Image_3.enabled = true; //"Image_1"を表示する
            displayTime += Time.deltaTime; //表示時間を加算する
            if(displayTime >= 3.0f) //三秒表示したら
            {
                Image_3.enabled = false; //"Image_1"を非表示にする
                f_display = 0; //表示フラッグをリセット
                displayTime = 0.0f; //表示時間をリセット
            }
        }

        if (f_Inversion == 1)
        {
            InversionTime += Time.deltaTime; //操作反転を実行している時間を加算する
            if(InversionTime >= 10.0f) //十秒実行したら
            {
                f_Inversion = 0; //反転フラッグをリセット
                InversionTime = 0.0f; //操作反転を実行している時間をリセット
            }
        }
    }
}
