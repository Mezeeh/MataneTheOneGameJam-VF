using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControler : MonoBehaviour {

	// Use this for initialization
    public Vector3 depart;
    public Vector3 checkpoint1;
    public Vector3 checkpoint2;
    public Vector3 checkpoint3;
    public Vector3 checkpoint4;
    private Vector3 lastCheckpoint;
    void Start () {
        
	}
	
	void OncollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Checkpoint1":
                lastCheckpoint = checkpoint1;
                break;
            case "Checkpoint2":
                lastCheckpoint = checkpoint2;
                break;
            case "Checkpoint3":
                lastCheckpoint = checkpoint3;
                break;
            case "Checkpoint4":
                lastCheckpoint = checkpoint4;
                break;
        }

        if (collision.gameObject.tag == "DeadZone")
        {
            transform.position = lastCheckpoint;
        }
    }
	
}
