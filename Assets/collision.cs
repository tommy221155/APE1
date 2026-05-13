using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class collision : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CollisionCount;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CollisionCount.text = string.Format("Collision {0} ", count);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.StartsWith("wall"))
        {
            count++;
        } 
    }
}
