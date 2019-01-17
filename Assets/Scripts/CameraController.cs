using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;

    public bool changerPourCameraChoppe;
    public bool changerPourCameraDebut;
    public bool changerPourCameraRefill;
    public bool suivreChoppe;
    private Rigidbody rg;

    public GameObject choppe;

    // Use this for initialization
    void Start()
    {
        changerPourCameraChoppe = false;
        changerPourCameraDebut = false;
        changerPourCameraRefill = false;
        currentView = views[1];
        rg = choppe.GetComponent<Rigidbody>();
        rg.isKinematic = true;
        suivreChoppe = false;
        StartCoroutine(Demarrer());

    }

    void Update()
    {

        if(changerPourCameraChoppe)
        {
            //while (changerPourCameraChoppe)            
            views[0].transform.position = choppe.transform.position + new Vector3(0, 1, -1.4f);
            rg.isKinematic = false;
            currentView = views[0];
            changerPourCameraChoppe = false;
            suivreChoppe = true;
            
        }      

        if (changerPourCameraDebut)
        {
            currentView = views[1];
            changerPourCameraDebut = false;
        }

        if (changerPourCameraRefill)
        {
            currentView = views[2];
            changerPourCameraRefill = false;
        }
        if(suivreChoppe)
        {
            Vector3 pos = choppe.transform.position;
            transform.position = pos + new Vector3(0, 1, -1.4f);
            transform.LookAt(choppe.transform.position + (Vector3.up * 0.3f));
        }

    }

    void LateUpdate()
    {

        //Lerp position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
         Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;

        if(changerPourCameraChoppe)
        {
            changerPourCameraChoppe = false;
            suivreChoppe = true;
        }

    }

    IEnumerator Demarrer()
    {

        yield return new WaitForSeconds(2);
        changerPourCameraChoppe = true;
        rg.isKinematic = true;
    }

    public void ChangerPourCameraChope()
    {
        changerPourCameraChoppe = true;
    }

    public void ChangerPourCameraDebut()
    {
        changerPourCameraDebut = true;
    }

    public void ChangerPourCameraRefill()
    {
        changerPourCameraRefill = true;
    }
}