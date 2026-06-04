using UnityEngine;

public class GravityArea : MonoBehaviour
{
    [SerializeField]
    private Transform planetCenter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlanetGravity gravity =
                other.GetComponent<PlanetGravity>();

            if(gravity != null)
            {
                gravity.SetGravityCenter(planetCenter);
            }
        }
    }
}