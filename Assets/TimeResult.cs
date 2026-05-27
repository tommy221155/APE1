using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeResult : MonoBehaviour
{
    public TextMeshProUGUI TimeResultText;
    float ResultTime;

    // Start is called before the first frame update
    void Start()
    {
        ResultTime = time.GetTime();
        TimeResultText.text = string.Format("Time : {0}",ResultTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
