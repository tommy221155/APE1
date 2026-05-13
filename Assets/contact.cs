using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // この２行を追加する． 
using TMPro; // この２行を追加する．

public class contact : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ContactCount;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ContactCount.text = string.Format("Hit wall {0}", count);
    }

    void OnCollisionEnter(Collision other) // 衝突を判定する関数を呼ぶ 
    {
        if (other.gameObject.transform.root.gameObject.name == "wall") // 衝突した物体が「ゴール」なら（※） 
        {
            count += 1; // 衝突フラグを上げる
        } 
    }
}
