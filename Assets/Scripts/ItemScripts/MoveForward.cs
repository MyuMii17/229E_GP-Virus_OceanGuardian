using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float acceleration = 10.0f;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        _rb.AddForce(transform.forward * acceleration * Time.fixedDeltaTime,ForceMode.Impulse);
    }
}
