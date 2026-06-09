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
    [SerializeField] private GameObject playerObject;

    private player Player;
    private int count;
    private int check;
    private Vector3 savedPosition;
    private bool isChecked;
    private float holdTime;
    private float needHoldTime;
    private int isPlanet1;

    

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<player>();
        count = 0;
        check = 0;
        isChecked = false;
        holdTime = 0f;
        needHoldTime = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //ContactCount.text = string.Format("Hit wall {0}", count);
        CheckCount.text = string.Format("check {0}", check);

        isPlanet1 = Player.IsPlanet1;
        
        if(Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
        {
            holdTime += Time.deltaTime;
            if(holdTime >= needHoldTime)
            {
                if(isChecked)
                {
                    if(isPlanet1 == 1){
                        playerObject.transform.position = savedPosition;
                        transform.rotation = Quaternion.Euler(0, 0, -180);
                        holdTime = 0f;
                    }
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
        if (other.gameObject.CompareTag("wall")) // 衝突した物体が「ゴール」なら
        {
            count += 1; // 衝突フラグを上げる
            //SceneManager.LoadScene("Result");
        } 
        
    }

    void OnTriggerEnter(Collider other_t)
    {
        if(other_t.gameObject.name == "checkpoint")
        {
            check = 1;
            savedPosition = other_t.transform.position + new Vector3(0f, 0f, 1f);

            isChecked = true;
        }
    }
}
