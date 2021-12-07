using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    public float RotateSpeed;
    public float LerpBackSpeed;
    public float translateSpeed;
    public GameObject Car;
    public GameObject Wheel;
    public GameObject CarChild;
    public float WheelSpeed;
    public Vector3 Swerve;
    public float SwerveAngle;
    public float SwerveMath;
    public float SwerveSpeed;
    public float bounds;
    public float boundsX;
    private bool driving = false;
    public float tiltSpeed;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //SwerveAngle = Car.transform.rotation.y;
        SwerveAngle = CarChild.transform.rotation.y;
        //SwerveMath = SwerveMath + SwerveAngle / SwerveSpeed;
        SwerveMath = SwerveAngle / SwerveSpeed * translateSpeed;

        //Car.transform.Translate(new Vector3(SwerveMath, 0, 0) * Time.deltaTime, Space.World);

        boundsX = Car.transform.localPosition.x;

       

        if (boundsX < bounds && boundsX > -bounds)
        {
            Car.transform.Translate(new Vector3(SwerveMath, 0, 0) * Time.deltaTime, Space.World);
            //SwerveMath = SwerveMath + SwerveAngle / SwerveSpeed;
        }

        if (boundsX > bounds && SwerveMath < 0)
        {
            Car.transform.Translate(new Vector3(SwerveMath, 0, 0) * Time.deltaTime, Space.World);
            //SwerveMath = SwerveMath + SwerveAngle / SwerveSpeed;
        }

  

        if (boundsX < -bounds && SwerveMath > 0)
        {
            Car.transform.Translate(new Vector3(SwerveMath, 0, 0) * Time.deltaTime, Space.World);
            //SwerveMath = SwerveMath + SwerveAngle / SwerveSpeed;
        }



        //Vector3 limit;

        //limit = Car.transform.eulerAngles;

        //limit.y = Mathf.Clamp(limit.y, -60f, 60f);

        //Car.transform.eulerAngles = limit;


        Quaternion limit;

        limit = Car.transform.rotation;

        limit.y = Mathf.Clamp(limit.y, -0.5f, 0.5f);

        Car.transform.rotation = limit;




        if (Input.GetKey(KeyCode.A))
        {
            CarChild.transform.Rotate(-Vector3.up * RotateSpeed);
            CarChild.transform.Rotate(Vector3.forward * tiltSpeed);
            Wheel.transform.Rotate(Vector3.forward * WheelSpeed);
            driving = true;
        }



        


        if (Input.GetKey(KeyCode.D))
        {
            CarChild.transform.Rotate(Vector3.up * RotateSpeed);
            CarChild.transform.Rotate(Vector3.back * tiltSpeed);
            Wheel.transform.Rotate(-Vector3.forward * WheelSpeed);
            driving = true;
        }

       

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            driving = false;
        }




        if (!driving)
        {
            
            CarChild.transform.rotation = Quaternion.Lerp(CarChild.transform.rotation, Quaternion.identity, Time.deltaTime / LerpBackSpeed);
            Wheel.transform.rotation = Quaternion.Lerp(Wheel.transform.rotation, Quaternion.identity, Time.deltaTime / LerpBackSpeed);
        }

      
    }
}