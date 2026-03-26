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
    private float boatcurrentTilt;
    private float boatTiltPower = 5f;
    private float boatTiltReduce = 2f;
    private float boatMaxTilt = 10f;
    private float targetTilt = 0f;

    private Rigidbody rb; 
    private InputAction moveAction;
    public ParticleSystem waterParticle;
    [SerializeField]private FuelSystem fuel;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
        fuel = GetComponent<FuelSystem>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        var v = moveAction.ReadValue<Vector2>();
        var verticalInput = v.y;
        var horizontalInput = v.x;

        if(verticalInput != 0 && fuel.HasFuel())
        {
            currenSpeed += verticalInput * boatAcceleration * Time.fixedDeltaTime;
        }
        else
        {

            if(currenSpeed > 0.0f)
            {
                currenSpeed -= boatDeceleration * Time.fixedDeltaTime;
                if (currenSpeed < 0)
                {
                    currenSpeed = 0f;
                }
            }
            else if (currenSpeed < 0.0f)
            {
                currenSpeed += boatDeceleration * Time.fixedDeltaTime;
                if(currenSpeed > 0)
                {
                    currenSpeed = 0f;
                }
            }

        }

        if(horizontalInput != 0 && fuel.HasFuel())
        {
            boatcurrentTilt += -horizontalInput * boatTiltPower * Time.fixedDeltaTime;
        }
        else
        {
            if(boatcurrentTilt > 0.0f)
            {
                boatcurrentTilt -= boatTiltReduce * Time.fixedDeltaTime;
                if(boatcurrentTilt < 0)
                {
                    boatcurrentTilt = 0f;
                }
            }
            if(boatcurrentTilt < 0.0f)
            {
                boatcurrentTilt += boatTiltReduce * Time.fixedDeltaTime;
                if(boatcurrentTilt > 0)
                {
                    boatcurrentTilt = 0f;
                }
            }
        }

        Quaternion currentRot = rb.rotation;
        Vector3 euler = currentRot.eulerAngles;
        targetTilt = 0f;

        if (boatcurrentTilt > 180)
        {
            boatcurrentTilt -= 360;    
        }

        if(verticalInput != 0)
        {
            rb.AddTorque(horizontalInput * yawPower * transform.up);
            targetTilt = -horizontalInput * boatMaxTilt;
        }

        boatcurrentTilt = Mathf.Clamp(boatcurrentTilt, -boatMaxTilt, boatMaxTilt);
        boatcurrentTilt = Mathf.MoveTowards( boatcurrentTilt, targetTilt, boatTiltPower * Time.fixedDeltaTime);

        //boatcurrentTilt = Mathf.Lerp( boatcurrentTilt, targetTilt, boatTiltSmooth * Time.fixedDeltaTime);

        Quaternion targetRot = Quaternion.Euler(0, euler.y, boatcurrentTilt);
        rb.MoveRotation(targetRot);

        if(currenSpeed == 0)
        {
            waterParticle.Stop();
        }
        else
        {
            waterParticle.Play();
        }

        currenSpeed = Mathf.Clamp(currenSpeed, -boatMaxSpeed, boatMaxSpeed);
        rb.AddForce(transform.forward * currenSpeed);
    }
    public bool IsMoving()
    {
        return moveAction.IsPressed();
    }
}
