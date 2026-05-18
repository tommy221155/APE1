using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
         //接触したオブジェクトのタグが"Player"のとき
        if(other.CompareTag("Player"))
        {
            //オブジェクトの色を赤に変更する
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
