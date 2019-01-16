using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarProgression : MonoBehaviour {

    public Image progressBar;
    private float finalGoal_dist = 0.0f;
    public Transform Player;
    public Transform finalGoal;
    float initialDistance;
   

    // Use this for initialization
    void Start () {
        initialDistance = Vector3.Distance(Player.position, finalGoal.position);
    }
	
	// Update is called once per frame
	void Update () {
        finalGoal_dist = Vector3.Distance(Player.position, finalGoal.position);
        print("Distance to Goal:" + finalGoal_dist);
        float t = finalGoal_dist / initialDistance;
        t = 1 - t;
        progressBar.fillAmount = t;

    }
}
