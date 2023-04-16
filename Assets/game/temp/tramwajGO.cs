using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tramwajGO : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody rbw1;
    public Rigidbody rbw2;
    public Rigidbody rbw3;
    public Rigidbody rbw4;
    public WheelCollider fr;
    public WheelCollider fl;
    public WheelCollider br;
    public WheelCollider bl;
    public WheelCollider br1;
    public WheelCollider bl1;
    public WheelCollider br2;
    public WheelCollider bl2;
    public WheelCollider br3;
    public WheelCollider bl3;
    public WheelCollider br4;
    public WheelCollider bl4;
    public float speed;
    public float maxSpeed;
    public GameObject camat;
    bool ld, rd;
    public GameObject cam;
    public bool canSteer;
    public float sensY = 10;
    public float sensX = 10;
    private float rotationX;
    private float rotationY;

    bool deb = false;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb.centerOfMass = rb.centerOfMass - new Vector3(0, 1, 0);
        rbw1.centerOfMass = rb.centerOfMass - new Vector3(0, 1, 0);
        rbw2.centerOfMass = rb.centerOfMass - new Vector3(0, 1, 0);
        rbw3.centerOfMass = rb.centerOfMass - new Vector3(0, 1, 0);
        rbw4.centerOfMass = rb.centerOfMass - new Vector3(0, 1, 0);
    }


    void Update()
    {

            float z = 0;
            var localVel = transform.InverseTransformDirection(rb.velocity);
            if (canSteer)
            {

                rotationX += -Input.GetAxis("Mouse Y") * sensY;
                rotationY += Input.GetAxis("Mouse X") * sensX;
                rotationX = Mathf.Clamp(rotationX, -90, 90);
                camat.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
                camat.transform.position = rb.transform.position + new Vector3(0,5,0);
            //turret.transform.localRotation = Quaternion.Euler(0, rotationY, 0);
            rbw4.AddForce(transform.up * -500);
            rbw3.AddForce(transform.up * -500);
            rbw2.AddForce(transform.up * -500);
            rbw1.AddForce(transform.up * -500);
            rb.AddForce(transform.up * -500);
            //Debug.Log(Vector3.Dot(rb.velocity, rb.transform.forward));
            if (Input.GetAxis("Vertical") != 0 && Vector3.Dot(rb.velocity, rb.transform.forward) < maxSpeed)
            {
                z = Input.GetAxis("Vertical");
                fr.motorTorque = z * speed;
                fl.motorTorque = z * speed;
                br.motorTorque = z * speed;
                bl.motorTorque = z * speed;
                br1.motorTorque = z * speed - 10;
                bl1.motorTorque = z * speed - 10;
                br2.motorTorque = z * speed - 20;
                bl2.motorTorque = z * speed - 20;
                br3.motorTorque = z * speed - 30;
                bl3.motorTorque = z * speed - 30;
                br4.motorTorque = z * speed - 40;
                bl4.motorTorque = z * speed - 40;
            }
            else if (Vector3.Dot(rb.velocity, rb.transform.forward) > 0)
            {
                fr.motorTorque = -1 * speed;
                fl.motorTorque = -1 * speed;
                br.motorTorque = -1 * speed;
                bl.motorTorque = -1 * speed;
                br1.motorTorque = -1 * speed;
                bl1.motorTorque = -1 * speed;
                br2.motorTorque = -1 * speed;
                bl2.motorTorque = -1 * speed;
                br3.motorTorque = -1 * speed;
                bl3.motorTorque = -1 * speed;
                br4.motorTorque = -1 * speed;
                bl4.motorTorque = -1 * speed;
            }
            else if (Vector3.Dot(rb.velocity, rb.transform.forward) < 0)
            {
                fr.motorTorque = 1 * speed;
                fl.motorTorque = 1 * speed;
                br.motorTorque = 1 * speed;
                bl.motorTorque = 1 * speed;
                br1.motorTorque = 1 * speed;
                bl1.motorTorque = 1 * speed;
                br2.motorTorque = 1 * speed;
                bl2.motorTorque = 1 * speed;
                br3.motorTorque = 1 * speed;
                bl3.motorTorque = 1 * speed;
                br4.motorTorque = 1 * speed;
                bl4.motorTorque = 1 * speed;
            }
            //    rb.AddForce(Input.GetAxis("Vertical") * transform.forward * 100);

            fr.steerAngle = 45 * Input.GetAxis("Horizontal");
                fl.steerAngle = 45 * Input.GetAxis("Horizontal");
                //    rb.AddTorque(transform.up * 300 * Input.GetAxis("Horizontal"));
            }
            else if (deb)
            {

                if (localVel.z > 0)
                {
                    fr.motorTorque = -1 * speed;
                    fl.motorTorque = -1 * speed;
                    br.motorTorque = -1 * speed;
                    bl.motorTorque = -1 * speed;
                    br1.motorTorque = -1 * speed;
                    bl1.motorTorque = -1 * speed;
                    br2.motorTorque = -1 * speed;
                    bl2.motorTorque = -1 * speed;
                }
                else if (localVel.z < 0)
                {
                    fr.motorTorque = 1 * speed;
                    fl.motorTorque = 1 * speed;
                    br.motorTorque = 1 * speed;
                    bl.motorTorque = 1 * speed;
                    br1.motorTorque = 1 * speed;
                    bl1.motorTorque = 1 * speed;
                    br2.motorTorque = 1 * speed;
                    bl2.motorTorque = 1 * speed;
                }
            }
            else
            {
                //speed = 100 * 5;
                if (localVel.z > 0)
                {
                    fr.motorTorque = -1 * speed;
                    fl.motorTorque = -1 * speed;
                    br.motorTorque = -1 * speed;
                    bl.motorTorque = -1 * speed;
                    br1.motorTorque = -1 * speed;
                    bl1.motorTorque = -1 * speed;
                    br2.motorTorque = -1 * speed;
                    bl2.motorTorque = -1 * speed;
                }
                else if (localVel.z < 0)
                {
                    fr.motorTorque = 1 * speed;
                    fl.motorTorque = 1 * speed;
                    br.motorTorque = 1 * speed;
                    bl.motorTorque = 1 * speed;
                    br1.motorTorque = 1 * speed;
                    bl1.motorTorque = 1 * speed;
                    br2.motorTorque = 1 * speed;
                    bl2.motorTorque = 1 * speed;
                }
            }
        }     
    }

