using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysiqueLiquide : MonoBehaviour {

    public GameObject liquide;
    public GameObject textureLiquide;

    public int vitesseBallottementLiquide = 60;
    public int vitesseRotationLiquide = 15;

    private int difference = 25;

    public float hauteurTasseRemplie = 1;
    public float hauteurTasseVide = -1;

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
        Quaternion inverseRotationTasse = Quaternion.Inverse(transform.localRotation);

        Vector3 rotationFinaleLiquide = Quaternion.RotateTowards(liquide.transform.localRotation, inverseRotationTasse, vitesseBallottementLiquide * Time.deltaTime).eulerAngles;

        rotationFinaleLiquide.x = limiterRotation(rotationFinaleLiquide.x, difference);
        rotationFinaleLiquide.y = limiterRotation(rotationFinaleLiquide.y, difference);

        liquide.transform.localEulerAngles = rotationFinaleLiquide;
    }

    private void quantifierTasse()
    {
        float pourcentageLiquide = (quantiteLiquide / quantiteMaxLiquide);
        float positionLiquide = (pourcentageLiquide * (hauteurTasseRemplie - hauteurTasseVide)) + hauteurTasseVide;

        Vector3 hauteurLiquideFinal = liquide.transform.localPosition;
        hauteurLiquideFinal.y = positionLiquide;

        liquide.transform.localPosition = hauteurLiquideFinal; 
    }

    private float limiterRotation(float valeur, float difference)
    {
        if (valeur > 180)
            return Mathf.Clamp(valeur, 360 - difference, 360);
        else
            return Mathf.Clamp(valeur, 0, difference);
    }

    private void renverserBiere()
    {
        if(quantiteLiquide > 0)
            quantiteLiquide -= vitesseVersement * Time.deltaTime;
    }
}
