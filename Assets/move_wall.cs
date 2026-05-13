using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class move_wall : MonoBehaviour
{
    Transform myTransform; // transform情報を格納する変数
    Vector3 position_start; // 物体の初期位置を格納する変数
    Vector3 position_now; // 物体の現在位置を格納する変数
    //float move_speed = 0.025f;

    float amplitude = 5.0f;
    float speed = 1.0f;
    float move_Time = 0f;

    bool isWaiting = false;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform; // 物体のtransform情報をリンクする
        position_start = myTransform.position; // 初期位置を取り出す
        position_now = position_start; // 最初は同じ場所
    }

    // Update is called once per frame
    void Update()
    {
        //position_now.z -= move_speed; // １ステップごとにZを-0.01する
        //if (position_start.z - position_now.z > 5) // Z方向に±5移動したら，
        //{
        //    move_speed = -0.025f;
        //}
        //if(position_start.z - position_now.z < -5)
        //{
        //    move_speed = 0.025f;
        //}

        //if(isWaiting)return;
        move_Time += Time.deltaTime;
            
        /*IEnumerator Wait()
        {
            isWaiting = true;
            yield return new WaitForSeconds(0.0125f);
            isWaiting = false;
        }
        StartCoroutine(Wait());*/
    
        position_now.z = position_start.z + amplitude * Mathf.Sin(move_Time * speed * (-1));
        myTransform.position = position_now;
    }
}