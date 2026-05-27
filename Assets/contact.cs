using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
using UnityEngine.SceneManagement;

public class contact : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ContactCount;
    [SerializeField] private TextMeshProUGUI CheckCount;
    [SerializeField] private GameObject player;

    private int count;
    private int check;
    private Vector3 savedPosition;
    private bool isChecked;
    private float holdTime;
    private float needHoldTime;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        check = 0;
        isChecked = false;
        holdTime = 0f;
        needHoldTime = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        ContactCount.text = string.Format("Hit wall {0}", count);
        CheckCount.text = string.Format("check {0}", check);

        if(Input.GetKey(KeyCode.RightShift))
        {
            holdTime += Time.deltaTime;
            if(holdTime >= needHoldTime)
            {
                if(isChecked)
                {
                    player.transform.position = savedPosition;
                    holdTime = 0f;
                }
            }
        }
        else
        {
            holdTime = 0f;
        }
    }

    void OnCollisionEnter(Collision other) // 衝突を判定する関数を呼ぶ 
    {
        if (other.gameObject.transform.root.gameObject.name == "wall") // 衝突した物体が「ゴール」なら
        {
            count += 1; // 衝突フラグを上げる
            SceneManager.LoadScene("Result");
        } 
        if(other.gameObject.name == "checkpoint")
        {
            check = 1;
            savedPosition = new Vector3(3f,1f,-7f);
            isChecked = true;
        }
    }
}
