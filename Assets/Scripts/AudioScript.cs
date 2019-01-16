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

    public enum Sons
    {
        music,
        frappeTable,
        remplirChope,
        renverserLegerement,
        renverserChope,
        boireChope

    }
    public void jouerSon(Sons sonAJouer)
    {
        switch(sonAJouer)
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
            case Sons.renverserChope:
                source.clip = renverserChope;
                source.Play();
                break;
            case Sons.renverserLegerement:
                source.clip = renverserLegerement;
                source.Play();
                break;
            case Sons.boireChope:
                source.clip = boireChope;
                source.Play();
                break;
        }
    }
}
