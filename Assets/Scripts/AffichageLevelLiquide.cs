using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichageLevelLiquide : MonoBehaviour {

    public Image liquidLevelBar;
    public GameObject choppe;

    PhysiqueLiquide physiqueLiquide;

    // Use this for initialization
    void Start () {
        physiqueLiquide = choppe.GetComponent<PhysiqueLiquide>();
	}
	
	// Update is called once per frame
	void Update () {
		liquidLevelBar.fillAmount = physiqueLiquide.quantiteLiquide / physiqueLiquide.quantiteMaxLiquide;
	}
}
