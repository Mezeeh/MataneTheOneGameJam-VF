using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FenetrePrincipal : MonoBehaviour {
    private XmlAccesseur xmlAcc;
    List<ScoreSaveObject> scores;
    public Text valeurClassement;


    void Start()
    {
        xmlAcc = XmlAccesseur.getInstance();
        scores = new List<ScoreSaveObject>();
        
    }
	public void jouer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void afficherClassement()
    {
        scores = xmlAcc.load();
        var i = 1;
        valeurClassement.text = "";
        foreach(ScoreSaveObject score in scores)
        {
            valeurClassement.text += i + " " + score.nom + " " + score.score + "\n";
            i++;
        }

    }

    public void quitter()
    {
        Debug.Log("quitter()");
        Application.Quit();
    }
}
