using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 200;
    private float lowerBound = -200;

    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound || transform.position.x > topBound || transform.position.x < lowerBound )
        {
            Destroy(gameObject);
        }
    }
}
