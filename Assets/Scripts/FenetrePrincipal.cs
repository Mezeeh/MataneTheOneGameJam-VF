using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FenetrePrincipal : MonoBehaviour {

	public void jouer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitter()
    {
        Debug.Log("quitter()");
        Application.Quit();
    }
}
