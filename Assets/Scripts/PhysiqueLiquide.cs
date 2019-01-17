using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysiqueLiquide : MonoBehaviour {

    public GameObject liquide;
    public GameObject textureLiquide;

    public ParticleSystem particles;

    public AudioScript scriptAudio;

    public int vitesseBallottementLiquide = 60;
    public int vitesseRotationLiquide = 15;

    private int difference = 25;

    public Vector3 hauteurTasseRemplie;
    public Vector3 hauteurTasseVide;

    public float quantiteLiquide = 100;
    public float quantiteMaxLiquide = 100;

    public float vitesseVersement = 50;

    public float scoreDernierCheckpoint;

    bool sonEnCours = false;
    private Score score;

    void Start()
    {
        score = transform.GetComponent<Score>();
        scoreDernierCheckpoint = score.score;
    }

    void Update () {
        ballotterLiquide();

        float angle = Vector3.Angle(Vector3.up, transform.up);
        float angleLimite = Mathf.Lerp(10, 90, 1 - (quantiteLiquide / quantiteMaxLiquide));

        Vector3 up = transform.up + transform.position;
        up.y = transform.position.y;

        Vector3 direction = up - transform.position;
        Vector3 lookAt = transform.position + (direction * 2f);
        // Debug.DrawLine(transform.position, lookAt, Color.red, 1);

        particles.transform.parent.rotation = Quaternion.LookRotation(lookAt - particles.transform.parent.position, transform.up);

        if (angle > angleLimite)
            renverserBiere();
        else
        {
            particles.enableEmission = false;
            scriptAudio.arreterSon();
            sonEnCours = false;
        }

        quantifierTasse();
        

        textureLiquide.transform.Rotate(Vector3.up * vitesseRotationLiquide * Time.deltaTime, Space.Self);
    }

    private void ballotterLiquide()
    {
        Quaternion rotationFinale = Quaternion.Slerp(liquide.transform.rotation, Quaternion.LookRotation(Vector3.up), 0.1f);
        liquide.transform.rotation = rotationFinale;
    }

    private void quantifierTasse()
    {
        float pourcentageLiquide = (quantiteLiquide / quantiteMaxLiquide);

        Vector3 positionLiquide = Vector3.Lerp(hauteurTasseVide, hauteurTasseRemplie, pourcentageLiquide);

        liquide.transform.localPosition = positionLiquide; 
    }

    private void renverserBiere()
    {
        quantiteLiquide -= vitesseVersement * Time.deltaTime;
        if(quantiteLiquide < 0)
        {
            quantiteLiquide = 0;
        }
        //Debug.Log("CA COULE");
        if (quantiteLiquide > 0)
        {
            //score.ReduireScore((int)(vitesseVersement * Time.deltaTime));
            textureLiquide.SetActive(true);
            particles.enableEmission = true;
            //score.score -= 10;
            if (!sonEnCours)
            {
                scriptAudio.jouerSon(AudioScript.Sons.renverserLegerement, true);
                sonEnCours = true;
            }

        }
        else
        {
            textureLiquide.SetActive(false);
            particles.enableEmission = false;
            scriptAudio.arreterSon();
            sonEnCours = false;
        }
        float pourcentageLiquide = (quantiteLiquide / quantiteMaxLiquide);
       score.score = (int)(scoreDernierCheckpoint - Mathf.Lerp(0,1000, 1 - pourcentageLiquide));
    }
}
