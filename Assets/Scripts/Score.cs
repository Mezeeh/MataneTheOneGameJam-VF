using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    public int scoreInitial;
    public int pointARetirer;
    public int score;
    public Text scoreText;

	// Use this for initialization
	void Awake () {
        score = scoreInitial;
        UpdateUiScore();
	}
	void Update()
    {
        UpdateUiScore();
    }
	// Update is called once per frame
    public void ReduireScore(int nombreAReduire)
    {
        score -= (nombreAReduire * pointARetirer);
        UpdateUiScore();
    }

    public int GetScore()
    {
        return score;
    }
    public void AjouterScore(int scoreAAjouter)
    {
        score += scoreAAjouter;
        UpdateUiScore();
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Bonus")
        {
            AjouterScore(collider.gameObject.GetComponent<ZoneBonus>().points);
            Destroy(collider.gameObject);
        }
    }
    void UpdateUiScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
