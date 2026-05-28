using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOnPlanet : MonoBehaviour
{

    public Transform sphereCenter; // 球体の中心
    public float speed = 5f; // プレイヤーの移動速度
    public float rotationSpeed = 160f; // プレイヤーの回転速度

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; // Unityのデフォルトの重力を無効化
            rb.constraints = RigidbodyConstraints.FreezeRotation; // 自動回転を防止
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sphereCenter == null) return;

        // 入力の取得
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // プレイヤーの移動
        Vector3 movement = transform.forward * vertical;
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
    }
}
