using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	// Use this for initialization
    public AudioSource source;
    public AudioClip music;
    public AudioClip frappeTable;
    public AudioClip remplirChope;
    public AudioClip renverserLegerement;
    public AudioClip renverserChope;
    public AudioClip boireChope;
    public AudioClip glisserChope;

    public enum Sons
    {
        music,
        frappeTable,
        remplirChope,
        renverserLegerement,
        chuteChope,
        boireChope,
        glisserChope
    }
    public void jouerSon(Sons sonAJouer, bool isLooping)
    {
        source.loop = isLooping;

        Debug.Log("jouerSon");

        switch (sonAJouer)
        {
            case Sons.music:
                source.clip = music;
                source.Play();
                break;
            case Sons.frappeTable:
                source.clip = frappeTable;
                source.Play();
                break;
            case Sons.remplirChope:
                source.clip = remplirChope;
                source.Play();
                break;
            case Sons.chuteChope:
                source.clip = renverserChope;
                source.Play();
                break;
            case Sons.renverserLegerement:
                Debug.Log("renverserLegerement");
                source.clip = renverserLegerement;
                source.Play();
                break;
            case Sons.boireChope:
                source.clip = boireChope;
                source.Play();
                break;
            case Sons.glisserChope:
                source.clip = glisserChope;
                source.Play();
                break;
        }
    }

    public void arreterSon()
    {
        Debug.Log("arreterSon");
        source.Stop();
    }
}
