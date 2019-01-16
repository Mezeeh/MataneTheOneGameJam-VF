using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementChope : MonoBehaviour {
    private float hAxis;
    public float vitesse;
    public float vitesseRotation;
    private Vector3 inputRotation;
    private Vector3 inputForward;
    private Vector3 inputHorizontal;
    public bool isGrounded;
    private Rigidbody rb;
    public float hauteurSaut;
    public float vitesseLaterale;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        inputForward = new Vector3(0, 0, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (!IsGrounded)
        {
            var x = Input.GetAxis("HorizontalR");
            var y = Input.GetAxis("VerticalR");
            inputRotation = new Vector3(x, 0, y);
            transform.Rotate(inputRotation, vitesseRotation * Time.deltaTime);
            //transform.Translate(inputForward * vitesse * Time.deltaTime, Space.World);
            //rb.velocity = inputForward * vitesse;
            hAxis = Input.GetAxis("Horizontal");
            inputHorizontal = new Vector3(hAxis * vitesseLaterale, 0, 0);
            transform.Translate(inputHorizontal * Time.deltaTime, Space.World);


        }
        else
        {
            if(Input.GetButtonDown("Jump"))
            {
                Debug.Log("JUMP");
                rb.AddForce(Vector3.up * hauteurSaut);
            }
            
            hAxis = Input.GetAxis("Horizontal");
            inputHorizontal = new Vector3(hAxis * vitesseLaterale, 0, 0);
            transform.Translate(inputHorizontal * Time.deltaTime, Space.World);
            rb.velocity = inputForward * vitesse;
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
