using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{

    public float speed;
    public float translateSpeed;
    public GameObject Car;
    public GameObject Wheel;
    public float WheelSpeed;
    public Vector3 Swerve;
    public float SwerveAngle;
    public float SwerveMath;
    public float SwerveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwerveAngle = Car.transform.rotation.y;
        SwerveMath = SwerveMath + SwerveAngle/SwerveSpeed;
        
        Car.transform.Translate(new Vector3(SwerveMath, 0, 0) * Time.deltaTime, Space.World);

        // if (SwerveAngle < 0.05f)
        // {
        //     SwerveSpeed = 3f;
        // }
        // if (SwerveAngle > -0.05f)
        // {
        //     SwerveSpeed = 3f;
        // }
        // if (SwerveAngle > 0.05f)
        // {
        //     SwerveSpeed = 1f;
        // }
        // if (SwerveAngle < -0.05f)
        // {
        //     SwerveSpeed = 1f;
        // }
      
        
        if (Input.GetKey(KeyCode.A))
        {
            Car.transform.Rotate(-Vector3.up * speed * Time.deltaTime);
            Wheel.transform.Rotate(Vector3.forward * WheelSpeed * Time.deltaTime, Space.Self);
            //Car.transform.Translate(-Vector3.right * translateSpeed * Time.deltaTime, Space.World);
            // = x + SwerveSpeed/Time.deltaTime;
        }

      
        if (Input.GetKey(KeyCode.D))
        {
            Car.transform.Rotate(Vector3.up * speed * Time.deltaTime);
            Wheel.transform.Rotate(-Vector3.forward * WheelSpeed * Time.deltaTime, Space.Self);
            //Car.transform.Translate(Vector3.right * translateSpeed * Time.deltaTime, Space.World);
        }

    }
}
