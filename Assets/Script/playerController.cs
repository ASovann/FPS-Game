using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float sensitivity = 3f;

    private playerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<playerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //velocité

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;
        motor.Move(_velocity);

        //rotation horizontal
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0, _yRot, 0) * sensitivity;
        motor.Rotate(_rotation);

        //rotation vertical
        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(_xRot, 0, 0) * sensitivity;
        motor.rotateCamera(_cameraRotation);
    } 
}
