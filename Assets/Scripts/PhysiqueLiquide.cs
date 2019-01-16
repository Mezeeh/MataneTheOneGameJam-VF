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
	
	// Update is called once per frame
	void Update () {
        ballotterLiquide();

        quantifierTasse();

        textureLiquide.transform.Rotate(Vector3.up * vitesseRotationLiquide * Time.deltaTime, Space.Self);
    }

    private void ballotterLiquide()
    {
        Quaternion inverseRotationTasse = Quaternion.Inverse(transform.localRotation);

        Vector3 rotationFinale = Quaternion.RotateTowards(liquide.transform.localRotation, inverseRotationTasse, vitesseBallottementLiquide * Time.deltaTime).eulerAngles;

        rotationFinale.x = limiterRotation(rotationFinale.x, difference);
        rotationFinale.y = limiterRotation(rotationFinale.y, difference);

        liquide.transform.localEulerAngles = rotationFinale;
    }

    private void quantifierTasse()
    {
        float pourcentageLiquide = (quantiteLiquide / quantiteMaxLiquide);
        //Debug.Log(pourcentageLiquide);
        float positionLiquide = (pourcentageLiquide * (hauteurTasseRemplie - hauteurTasseVide)) + hauteurTasseVide;
        Debug.Log(positionLiquide);

        Vector3 hauteurLiquideFinal = liquide.transform.localPosition;
        hauteurLiquideFinal.y = positionLiquide;

        liquide.transform.localPosition = hauteurLiquideFinal; 
    }

    private float limiterRotation(float valeur, float difference)
    {
        if (valeur > 180)
        {

            return Mathf.Clamp(valeur, 360 - difference, 360);
        }
        else
            return Mathf.Clamp(valeur, 0, difference);
    }

    private void renverserBiere()
    {

    }
}
