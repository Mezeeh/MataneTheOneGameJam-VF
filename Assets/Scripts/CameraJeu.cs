using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJeu : MonoBehaviour
{

    public GameObject choppe;
    public Vector3 offsetCamera;


    // Update is called once per frame
    /*void FixedUpdate()
    {
        Vector3 pos = choppe.transform.position;
        transform.position = pos + offsetCamera;
    }*/
    

    void Update()
    {
        Vector3 pos = choppe.transform.position;
        transform.position = pos + offsetCamera;
        transform.LookAt(choppe.transform.position + (Vector3.up * 0.3f));
    }
}
