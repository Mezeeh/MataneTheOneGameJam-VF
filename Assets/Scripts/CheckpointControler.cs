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
    private Score score;
    private PhysiqueLiquide liquide;
    void Start () {
        liquide = transform.GetComponent<PhysiqueLiquide>();
        score = transform.GetComponent<Score>();  
	}
	
	void OncollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Checkpoint1":
                if (lastCheckpoint != checkpoint1)
                {
                    lastCheckpoint = checkpoint1;
                    if (liquide.quantiteLiquide < liquide.quantiteMaxLiquide)
                        remplirBierre();
                }
                break;
            case "Checkpoint2":
                if (lastCheckpoint != checkpoint2)
                {
                    lastCheckpoint = checkpoint2;
                    if (liquide.quantiteLiquide < liquide.quantiteMaxLiquide)
                        remplirBierre();
                }
                break;
            case "Checkpoint3":
                if (lastCheckpoint != checkpoint3)
                {
                    lastCheckpoint = checkpoint3;
                    if (liquide.quantiteLiquide < liquide.quantiteMaxLiquide)
                        remplirBierre();
                }
                break;
            case "Checkpoint4":
                if (lastCheckpoint != checkpoint4)
                {
                    lastCheckpoint = checkpoint4;
                    if (liquide.quantiteLiquide < liquide.quantiteMaxLiquide)
                        remplirBierre();
                }
                break;
        }

        if (collision.gameObject.tag == "DeadZone")
        {
            transform.position = lastCheckpoint;
        }
    }
    void remplirBierre()
    {
        //lancer l'annimation de refill;
        var scoreAReduire = Mathf.Floor(liquide.quantiteMaxLiquide - liquide.quantiteLiquide);
        score.ReduireScore((int)scoreAReduire);


    }
	
}
