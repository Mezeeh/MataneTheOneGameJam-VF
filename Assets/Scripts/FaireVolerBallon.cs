using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaireVolerBallon : MonoBehaviour {

    float valeurPingPong = 0;
    float yInitial;

    public float vitesseDeplacement = 2f;

	void Start () {
        yInitial = transform.position.y;
	}
	
	void Update () {
        //valeurPingPong = Mathf.PingPong(Time.time * (1 / vitesseDeplacement), 1f);
        valeurPingPong = Mathf.Sin(Time.time * (1 / vitesseDeplacement));
        Debug.Log(valeurPingPong);
        transform.position = new Vector3(transform.position.x, yInitial + (valeurPingPong * 3f), transform.position.z);
	}
}
