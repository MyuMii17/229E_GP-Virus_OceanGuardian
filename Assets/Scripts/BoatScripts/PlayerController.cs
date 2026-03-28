using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAcion;
    private float horizontalInput;
    private float verticalInput;
    [Header("Boat Setting")]
    private float boatMaxSpeed = 20f;
    private float boatAcceleration = 10f;
    private float boatDeceleration = 15f;
    private float boatTurnSpeed = 60f;
    [Header("Boat Current State")]
    private float currenSpeed = 0.0f;
    private bool isBraking = false;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAcion = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currenSpeed);
        Vector2 v = moveAcion.ReadValue<Vector2>();
        horizontalInput = v.x;
        verticalInput = v.y;
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

        currenSpeed = Mathf.Clamp(currenSpeed, -boatMaxSpeed, boatMaxSpeed);

        transform.Translate(Vector3.forward * currenSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, boatTurnSpeed * horizontalInput * Time.deltaTime);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Items"))
        {
            Rigidbody itemRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 dir = collision.contacts[0].normal * -1;

            itemRb.AddForce(dir * 1f, ForceMode.Impulse);
        }
    }

}
