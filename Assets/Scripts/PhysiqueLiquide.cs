using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysiqueLiquide : MonoBehaviour {

    public GameObject liquide;
    public GameObject textureLiquide;

    public int vitesseBalotementLiquide = 60;
    public int vitesseRotationLiquide = 15;

    public int difference = 25;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        baloterLiquide();

        textureLiquide.transform.Rotate(Vector3.up * vitesseRotationLiquide * Time.deltaTime, Space.Self);
    }

    private void baloterLiquide()
    {
        Quaternion inverseRotationTasse = Quaternion.Inverse(transform.localRotation);

        Vector3 rotationFinale = Quaternion.RotateTowards(liquide.transform.localRotation, inverseRotationTasse, vitesseBalotementLiquide * Time.deltaTime).eulerAngles;

        rotationFinale.x = limiterRotation(rotationFinale.x, difference);
        rotationFinale.y = limiterRotation(rotationFinale.y, difference);

        liquide.transform.localEulerAngles = rotationFinale;
    }

    private float limiterRotation(float valeur, float difference)
    {
        if (valeur > 180)
            return Mathf.Clamp(valeur, 360 - difference, 360);
        else
            return Mathf.Clamp(valeur, 0, difference);
    }
}
