using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlleurRalenti : MonoBehaviour {
    public float vitesseRalenti = 0.05f;
    public float dureeRalenti = 3;

    void Update()
    {
        Time.timeScale += (1f / dureeRalenti) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0.01f, 0.02f);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Slow mo mofo");
            ralentirTemps();
        }
    }

    public void ralentirTemps()
    {
        Time.timeScale = vitesseRalenti;
        
    }
}
