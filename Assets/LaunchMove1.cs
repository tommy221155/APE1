using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMove1 : MonoBehaviour
{
    private GameManager gamemanager;

    private bool isGrounded = false;
    public Transform[] points;
    private int currentSegment = 0;
    public float duration = 10f;

    private float t = 0f;

    private bool isLaunching = false;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Launcher1"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Launcher1"))
        {
            isGrounded = false;
        }
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

        Vector3 startPos =
            points[currentSegment].position;

        Vector3 endPos =
            points[currentSegment + 1].position;

        transform.position =
            Vector3.Lerp(startPos, endPos, t);


        if (t >= 1f)
        {
            currentSegment++;
        t = 0f;

        if(currentSegment >= points.Length - 1)
            {
                isLaunching = false;
                currentSegment = 0;
            }
        }

        
    }

    // 発射開始
    public void Launch()
    {
        gamemanager.PlaySE_Launcher();

        currentSegment = 0;
        t = 0f;
        isLaunching = true;
    }
}
