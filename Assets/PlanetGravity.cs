using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{


    [SerializeField] private Transform sphereCenter; // 重力の中心
    [SerializeField] private float gravityStrength = 9.8f; // 重力の強さ
    private float rotationSpeed = 50f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // このオブジェクトのRigidbodyを取得
        rb = GetComponent<Rigidbody>();

        // Rigidbodyがアタッチされていない場合、警告を表示
        if (rb == null)
        {
            Debug.LogWarning("Rigidbodyがアタッチされていません。重力の適用にはRigidbodyが必要です。");
        } 
    }


    void FixedUpdate()
    {
        if (rb == null || sphereCenter == null) return;

        // 球の中心へのベクトルを計算（法線）
        Vector3 direction = (sphereCenter.position - transform.position).normalized;

        // 重力の力を計算
        Vector3 gravityForce = direction * gravityStrength * rb.mass;

        // Rigidbodyに力を適用
        rb.AddForce(gravityForce);

        // 法線ベクトルに従って、プレイヤーの縦方向のRotationを更新する
        Quaternion targetRotation = Quaternion.FromToRotation(-transform.up, direction) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
