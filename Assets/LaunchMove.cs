using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMove : MonoBehaviour
{

    public Transform startPoint;
    public Transform controlPoint;
    public Transform endPoint;
    private bool isGrounded = false;

    public float duration = 2f;

    private float t = 0f;

    private bool isLaunching = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Launcher"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Launcher"))
        {
            isGrounded = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
        

        if (!isLaunching) return;

        t += Time.deltaTime / duration;

        Vector3 p0 = startPoint.position;
        Vector3 p1 = controlPoint.position;
        Vector3 p2 = endPoint.position;

        Vector3 pos =
            Mathf.Pow(1 - t, 2) * p0 +
            2 * (1 - t) * t * p1 +
            Mathf.Pow(t, 2) * p2;

        transform.position = pos;

        if (t >= 1f)
        {
            isLaunching = false;
        }

        
    }

    // 発射開始
    public void Launch()
    {
        t = 0f;
        isLaunching = true;
    }
}
