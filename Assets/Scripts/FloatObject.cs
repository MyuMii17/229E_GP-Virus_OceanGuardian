using UnityEngine;

public class FloatObject : MonoBehaviour
{
    public float floatHeight = 0.25f;
    public float floatForce = 20f;
    public float bounceDamping = 0.5f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float waterY = WaterManager.Instance.GetWaterHeight(transform.position);

        float difference = waterY + floatHeight - transform.position.y;

        float force = difference * floatForce;

        // ลดแรงเด้ง (damping)
        float velocity = rb.linearVelocity.y;
        force -= velocity * bounceDamping;

        rb.AddForce(Vector3.up * force * Time.deltaTime);
        
    }
}
