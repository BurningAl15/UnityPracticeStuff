using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpherePhysics : MonoBehaviour {
    //Meters per second
    public float Speed;

    //Degrees
    //0 to 90
    public float lateralAngle;
    //-90 to 90
    public float verticalAngle;
    
    //(RPM)
    public float Spin;
    
    // Gravity (m/s^2)
    private float Gravity = 9.81f;
    
    // X component of Speed
    private float XSpeed = 0f;
    
    // Y component of Speed
    private float YSpeed = 0f;
    
    //Z component of Speed
    private float ZSpeed = 0f;
    
    // Ball mass (kg)
    public float Mass_KG;
    
    // Ball diameter (m)
    public float Diameter_M;
    
    // Ball area (m^2)
    private float Area_M = 0f;

    // Air density (kg/m^3)
    public float AirDensity_KG;

    //Initial Position
    public Vector3 initialPos;

    //Drag and lift coeficient
    public float DragCoe;
    public float LiftCoe;

    void Start()
    {
        // Scale the size
        transform.localScale = new Vector3(Diameter_M, Diameter_M, Diameter_M);
        initialPos = transform.position;

        // Diameter/2=radius (m^2)
        Area_M = AreaofCircle(Diameter_M / 2.0f);
        
        // Angle in radians
        lateralAngle = Mathf.Deg2Rad * lateralAngle;
        verticalAngle = Mathf.Deg2Rad * verticalAngle;


        XSpeed = Speed * -Mathf.Cos(lateralAngle) * Mathf.Cos(verticalAngle);

        YSpeed = Speed * Mathf.Cos(verticalAngle)*Mathf.Sin(lateralAngle);

        ZSpeed = Speed * Mathf.Sin(verticalAngle);
    }

    Vector3 Calculate2DMagnusAndDrag()
    {
        // Velocity along the XY plane
        float Velocity = magnitude(XSpeed, YSpeed);
        // Convert spin RPM to radians
        //float SpinRateRAD = RPM2Radians(Spin);
        
        // Drag Coefficient
        float DragCoefficient = KD();
        
        // Lift Coefficient
        float LiftCoefficient = KL();

        float D = AirDensity_KG * Area_M * Velocity / (2 * Mass_KG);
        float xAirDrag = D * -(DragCoefficient * XSpeed + LiftCoefficient * YSpeed);
        float yAirDrag = D * -(DragCoefficient * YSpeed - LiftCoefficient * XSpeed);
        float zAirDrag = -Mass_KG*Gravity  - DragCoefficient * ZSpeed;
        return new Vector3(xAirDrag, yAirDrag, zAirDrag);
    }

    //void FixedUpdate()
    //{
    ////PrintValues();
    //    if(Input.GetMouseButtonUp(0))
    //    { 
    //    Vector3 drag = Calculate2DMagnusAndDrag();
    //    XSpeed -= drag.x * Time.fixedDeltaTime;
    //    float xStep = XSpeed * Time.fixedDeltaTime;

    //    YSpeed -= Gravity * Time.fixedDeltaTime;
    //    YSpeed -= drag.y * Time.fixedDeltaTime;
    //    float yStep = YSpeed * Time.fixedDeltaTime;

    //    float newx = transform.position.x + xStep;
    //    float newy = transform.position.y + yStep;
    //    if (newy > -0f)
    //        transform.position = new Vector3(newx, newy, 0f);
    //    }
    //}
    private void Update()
    {
        //if (Input.GetMouseButtonUp(0))
        //{
            Vector3 drag = Calculate2DMagnusAndDrag();
            XSpeed -= drag.x * Time.fixedDeltaTime;
            float xStep = XSpeed * Time.fixedDeltaTime;

            YSpeed -= Gravity * Time.fixedDeltaTime;
            YSpeed -= drag.y * Time.fixedDeltaTime;
            float yStep = YSpeed * Time.fixedDeltaTime;

            float newx = transform.position.x + xStep;
            float newy = transform.position.y + yStep;

       
        if (newy > -0f)
            transform.position = new Vector3(newx, newy, 0f);
    }

    float KD()
    {
        return (DragCoe * AirDensity_KG * AreaofCircle(Diameter_M))/2;
    }

    float KL()
    {
        return (LiftCoe*AirDensity_KG*AreaofCircle(Diameter_M)*(Diameter_M/2)) / 2;
    }

    // Spin rate (radians/s) [Convert RPM]
    float RPM2Radians(float rpm)
    {
        return 2f * Mathf.PI * rpm / 60f;
    }

    // pi r^2
    float AreaofCircle(float radius)
    {
        return Mathf.PI * Mathf.Pow(radius, 2.0f);
    }

    // a^2 + b^2 = c^2
    float magnitude(float speedx, float speedy)
    {
        return Mathf.Sqrt(Mathf.Pow(speedx, 2.0f) + Mathf.Pow(speedy, 2.0f));
    }
}