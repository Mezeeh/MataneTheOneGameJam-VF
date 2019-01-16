using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementChope : MonoBehaviour {
    private float hAxis;
    public float vitesse;
    public float vitesseRotation;
    private Vector3 input;
    private bool isGrounded;
    private Rigidbody rb;
    public float hauteurSaut;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();   
	}
	
	// Update is called once per frame
	void Update () {
        if (!IsGrounded)
        {
            var x = Input.GetAxis("HorizontalR");
            var y = Input.GetAxis("VerticalR");
            input = new Vector3(x, 0, y);
            transform.Rotate(input, vitesseRotation * Time.deltaTime);
            input = new Vector3(0, 0, 1f);
            transform.Translate(input * vitesse * Time.deltaTime, Space.World);


        }
        else
        {
            if(Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * hauteurSaut);
            }
            
            hAxis = Input.GetAxis("Horizontal");
            input = new Vector3(hAxis, 0, 1f);
            transform.Translate(input * vitesse * Time.deltaTime, Space.World);
        }
       
	}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Plancher")
            IsGrounded = true;
      
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Plancher")
            IsGrounded = false;
    }
    public bool IsGrounded
    {
        get { return isGrounded; }
        set
        {
            if(isGrounded != value)
            {
                isGrounded = value;
            }
        }
    }

}
