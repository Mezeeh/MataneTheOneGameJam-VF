using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VueFinDePartie : MonoBehaviour
{
    public Text enTete;
    public InputField inputFieldNom;
    private Score score;
    public GameObject chope;
    private XmlAccesseur xmlAcc;
    // Use this for initialization
    void Start()
    {
        xmlAcc = XmlAccesseur.getInstance();
        enTete.text += " " + score.score.ToString();
        
    }
    public void rejouer()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void quiter()
    {
        SceneManager.LoadScene(0);
    }
    public void EnregistrerScore()
    {
        xmlAcc.save(new ScoreSaveObject { nom = inputFieldNom.text, score = score.score });
    }

    

}
