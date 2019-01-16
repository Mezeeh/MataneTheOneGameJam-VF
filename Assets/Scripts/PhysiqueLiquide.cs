using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysiqueLiquide : MonoBehaviour {

    public GameObject liquide;
    public GameObject textureLiquide;

    public int vitesseBallottementLiquide = 60;
    public int vitesseRotationLiquide = 15;

    private int difference = 25;

    public Vector3 hauteurTasseRemplie;
    public Vector3 hauteurTasseVide;

    public float quantiteLiquide = 100;
    public float quantiteMaxLiquide = 100;

    public float vitesseVersement = 50;

    void Update () {
        ballotterLiquide();

        float angle = Vector3.Angle(Vector3.up, transform.up);

        if(angle > 90)
            renverserBiere();

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
        //Debug.Log("CA COULE");
        if(quantiteLiquide > 0)
            quantiteLiquide -= vitesseVersement * Time.deltaTime;
    }
}
