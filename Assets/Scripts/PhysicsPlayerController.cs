using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsPlayerController : MonoBehaviour
{
    public float drag = 50f;
    public float angularDrag = 0.001f;
    public float yawPower = 50f;
    private float currenSpeed = 0.0f;
    private float boatDeceleration = 5f;
    private float boatAcceleration = 20f;
    private float boatMaxSpeed = 25f;
    private bool isOnWater;
    private float boatMass;

    private Rigidbody rb; 
    private InputAction AccelerateAction;
    private InputAction moveAction;
    public ParticleSystem WaterParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AccelerateAction = InputSystem.actions.FindAction("Jump");
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
        boatMass = rb.mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var v = moveAction.ReadValue<Vector2>();
        var verticalInput = v.y;
        var horizontalInput = v.x;

        if(verticalInput != 0)
        {
            currenSpeed += verticalInput * boatAcceleration * Time.deltaTime;
        }
        else
        {

            if(currenSpeed > 0.0f)
            {
                currenSpeed -= boatDeceleration * Time.deltaTime;
                if (currenSpeed < 0)
                {
                    currenSpeed = 0f;
                }
            }
            else if (currenSpeed < 0.0f)
            {
                currenSpeed += boatAcceleration * Time.deltaTime;
                if(currenSpeed > 0)
                {
                    currenSpeed = 0f;
                }
            }

        }

        if(verticalInput < 0)
        {
            rb.AddTorque(-horizontalInput * yawPower * transform.up);
       }
        else if(verticalInput > 0)
        {
            rb.AddTorque(horizontalInput * yawPower * transform.up);
        }

        if(currenSpeed == 0)
        {
            WaterParticle.Stop();
        }
        else
        {
            WaterParticle.Play();
        }

        currenSpeed = Mathf.Clamp(currenSpeed, -boatMaxSpeed, boatMaxSpeed);
        rb.AddForce(transform.forward * currenSpeed);

        // Debug.Log(verticalInput);
        // Debug.Log(currenSpeed);

        // float dragForce = -rb.linearVelocity.magnitude * drag;
        // rb.AddForce( transform.forward * -dragForce);
        // Debug.Log(dragForce);

    }   
}
