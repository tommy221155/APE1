using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManagerScript : MonoBehaviour
{
    private static BGMManagerScript instance;

    void Awake()
    {
        if (instance == null)
        {
            // このオブジェクトがシングルトンのインスタンスとして設定される
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 既にインスタンスが存在する場合、このオブジェクトを破棄
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
