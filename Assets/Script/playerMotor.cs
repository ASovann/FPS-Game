
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 cameraRotation;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;

    }
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void rotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        }

    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        cam.transform.Rotate(-cameraRotation);
    }
}
