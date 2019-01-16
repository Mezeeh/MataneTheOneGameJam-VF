using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    public int scoreInitial;
    public int pointARetirer;
    private int score;

	// Use this for initialization
	void Start () {
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

}
