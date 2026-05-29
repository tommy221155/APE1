using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    private AudioSource audioSource = null;
    public AudioClip SE_1;
    public AudioClip SE_2;
    public AudioClip SE_3;
    public AudioClip SE_4;
    public AudioClip SE_5;
    public Image Image_1;
    private float displayTime;
    private int f_display = 0;
    private float InversionTime;
    public int f_Inversion = 0;

    // Start is called before the first frame update
    void Start()
    {
        Image_1.enabled = false; //初期設定では表示しない
        f_display = 0; // 表示フラグを初期化する
        audioSource = GetComponent<AudioSource>();
    }

    
    public void PlaySE_1()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(SE_1);
        }
        else
        {
            Debug.Log("audiosource=null");
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

    //接触したオブジェクトの名称が"ImageTrigger_1"のとき
    public void DisplayImage_1()
    {
        if(f_display != 1)
        {
            f_display = 1;
        }
    }

    public void Inversion()
    {
        if(f_Inversion != 1)
        {
            f_Inversion = 1;
        }
    }

// Update is called once per frame
    void Update()
    {
        if (f_display == 1) // "out"の画像を表示している場合だけ時間を合だけ時間を加算する
        {
            Image_1.enabled = true;
            // 前のフレームからの経過時間（秒）を加算する
            displayTime += Time.deltaTime;
            if(displayTime >= 3.0f)
            {
                Image_1.enabled = false;
                f_display = 0;
                displayTime = 0.0f;
            }
        }

        if (f_Inversion == 1)
        {
            InversionTime += Time.deltaTime;
            if(InversionTime >= 10.0f)
            {
                f_Inversion = 0;
                InversionTime = 0.0f;
            }
        }
    }

}
