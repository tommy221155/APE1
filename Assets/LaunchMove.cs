using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMove : MonoBehaviour
{
    private GameManager gamemanager;
    public Transform startPoint;
    public Transform controlPoint;
    public Transform endPoint;

    public Camera mainCamera;
    public Transform launchCameraPoint;

    private Transform originalParent;
    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;


    private bool isGrounded = false;

    public float duration = 10f;

    private float t = 0f;

    private bool isLaunching = false;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionStay(Collision collision)
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

    // Update is called once per frame
    void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
        

        if (!isLaunching) return;

        mainCamera.transform.LookAt(transform);

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

            transform.rotation = Quaternion.identity;

            mainCamera.transform.SetParent(originalParent);

            mainCamera.transform.localPosition =
                originalLocalPosition + new Vector3(0f, -3f, 0f);

            mainCamera.transform.localRotation =
                originalLocalRotation * Quaternion.Euler(-30f, 0f, 0f);
        }

        
    }

    // 発射開始
    public void Launch()
    {
        gamemanager.PlaySE_Launcher();

        originalParent = mainCamera.transform.parent;
        originalLocalPosition = mainCamera.transform.localPosition;
        originalLocalRotation = mainCamera.transform.localRotation;

        mainCamera.transform.SetParent(null);

        mainCamera.transform.position =
            launchCameraPoint.position;

        mainCamera.transform.rotation =
            launchCameraPoint.rotation;

        t = 0f;

        isLaunching = true;
    }
}
