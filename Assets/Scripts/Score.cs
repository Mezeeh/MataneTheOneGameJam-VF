using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    public int scoreInitial;
    public int pointARetirer;
    public int score;

	// Use this for initialization
	void Awake () {
        score = scoreInitial;
	}
	
	// Update is called once per frame
    public void ReduireScore(int nombreAReduire)
    {
        score -= (nombreAReduire * pointARetirer);
    }

    public int GetScore()
    {
        return score;
    }
    public void AjouterScore(int scoreAAjouter)
    {
        score += scoreAAjouter;
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Bonus")
        {
            AjouterScore(collider.gameObject.GetComponent<ZoneBonus>().points);
            Destroy(collider.gameObject);
        }
    }

}
