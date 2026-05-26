using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private AudioSource audioSource = null;
    public AudioClip SE_1;
    public AudioClip SE_2;
    public AudioClip SE_3;
    public AudioClip SE_4;
    public AudioClip SE_5;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
