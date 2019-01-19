using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementChope : MonoBehaviour {
    private float hAxis;
    public float vitesse;
    public float vitesseRotation;
    private Vector3 inputRotation;
    private Vector3 inputForward;
    private Vector3 inputHorizontal;
    private Rigidbody rb;
    public float hauteurSaut;
    public float vitesseLaterale;
    public AudioSource music;
    public AudioSource slide;
    public AudioSource sounds;
    private AudioScript scriptMusic;
    private AudioScript scriptSlide;
    private AudioScript scriptSounds;
    private bool isSlideIsPlaying;
    private bool isDead;
    private int nombrePlancheTouche;

    public GameObject depart;

    public GameObject checkpoint1;

    public GameObject ServeurCheckPoint1;

    public Quaternion rotationDebut;

    private GameObject lastCheckpoint;
    private Score score;
    private PhysiqueLiquide liquide;

    //private CameraController cameraController;

    public Camera cameraChoppe;
    public Camera cameraStart;
    public Camera cameraCheckPoint;

    //public Camera cameraPrincipale;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        inputForward = new Vector3(0, 0, 1f);
        isSlideIsPlaying = false;
        scriptMusic = music.GetComponent<AudioScript>();
        scriptSlide = slide.GetComponent<AudioScript>();
        scriptSounds = sounds.GetComponent<AudioScript>();
        scriptMusic.jouerSon(AudioScript.Sons.music, true);
        isDead = false;
        score = transform.GetComponent<Score>();
        liquide = transform.GetComponent<PhysiqueLiquide>();
        
        lastCheckpoint = depart;
        rotationDebut = transform.rotation;

        //cameraController = cameraPrincipale.GetComponent<CameraController>();

        cameraCheckPoint.enabled = false;
        cameraChoppe.enabled = false;
        cameraStart.enabled = true;
        rb.isKinematic = true;
        StartCoroutine(changerCameraDeStartVersChoppe());




}
	
	// Update is called once per frame
	void Update () {
        if (!IsGrounded)
        {
            if(isSlideIsPlaying)
            {
                slide.Stop();
                isSlideIsPlaying = false;
            }
            if(!isDead)
            {
                var x = Input.GetAxis("HorizontalR");
                var y = Input.GetAxis("VerticalR");
                inputRotation = new Vector3(x, 0, y);
                transform.Rotate(inputRotation, vitesseRotation * Time.deltaTime, Space.World);
                //transform.Translate(inputForward * vitesse * Time.deltaTime, Space.World);
                //rb.velocity = inputForward * vitesse;
                hAxis = Input.GetAxis("Horizontal");
                inputHorizontal = new Vector3(hAxis * vitesseLaterale, 0, 0);
                transform.Translate(inputHorizontal * Time.deltaTime, Space.World);
            }
            
        }
        else
        {
            if(!isSlideIsPlaying)
            {
                scriptSlide.jouerSon(AudioScript.Sons.glisserChope, true);
                isSlideIsPlaying = true;
            }
            if(Input.GetButtonDown("Jump"))
            {
                //Debug.Log("JUMP");
                rb.AddForce(Vector3.up * hauteurSaut, ForceMode.VelocityChange);
                Animator animator = GetComponentInChildren<Animator>();
                animator.SetTrigger("jump");
            }
            
            hAxis = Input.GetAxis("Horizontal");
            inputHorizontal = new Vector3(hAxis * vitesseLaterale, 0, 0);
            transform.Translate(inputHorizontal * Time.deltaTime, Space.World);
            rb.velocity = inputForward * vitesse;
        }
       
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plancher")
        {
            nombrePlancheTouche++;
            scriptSounds.jouerSon(AudioScript.Sons.frappeTable,false);
        }
      
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "DeadZone")
        {
            if(!isDead)
            {
                isDead = true;
                liquide.scoreDernierCheckpoint = liquide.scoreDernierCheckpoint - 1000;
                score.score -= 1000;
                StartCoroutine(Respawn());
            }
            
            scriptSounds.jouerSon(AudioScript.Sons.chuteChope, false);
            
        }

        switch (collider.gameObject.tag)
        {
            case "Checkpoint1":
                if (lastCheckpoint != checkpoint1)
                {
                    Debug.Log("Tigger checkpoint1");
                    lastCheckpoint = checkpoint1;

                    Animator animatorServeur1 = ServeurCheckPoint1.GetComponent<Animator>();
                    animatorServeur1.SetTrigger("Checkpoint");
                    //cameraController.suivreChoppe = false;
                    //cameraController.ChangerPourCameraRefill();
                    cameraChoppe.enabled = false;
                    cameraCheckPoint.enabled = true;
                    rb.isKinematic = true;
                    transform.rotation = rotationDebut;
                    transform.position = lastCheckpoint.transform.position;


                    StartCoroutine(changerCameraDeChoppeVersRefill());

                    if (liquide.quantiteLiquide < liquide.quantiteMaxLiquide)
                        remplirBierre();
                    //respawn point dernier checkpoint
                }
                break;
            case "Finish":                
                Debug.Log("Score Final : " + score.GetScore());
                break;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Plancher")
            nombrePlancheTouche--;
    }
    public bool IsGrounded
    {
        get { return nombrePlancheTouche > 0; }
        
    }

    void remplirBierre()
    {
        //lancer l'annimation de refill;
        /*var scoreAReduire = Mathf.Floor(liquide.quantiteMaxLiquide - liquide.quantiteLiquide);
        Debug.Log("Score a reduire : " + (int)scoreAReduire);
        score.ReduireScore((int)scoreAReduire);*/
        liquide.scoreDernierCheckpoint = score.score;
        if(liquide.quantiteLiquide < liquide.quantiteMaxLiquide)
        {
            liquide.quantiteLiquide = liquide.quantiteMaxLiquide;
        }
        
        

    }

    IEnumerator Respawn()
    {

        yield return new WaitForSeconds(1);
        
        transform.rotation = rotationDebut;
        transform.position = lastCheckpoint.transform.position;
        isDead = false;
        remplirBierre();
        Debug.Log("Respawn");
    }

    IEnumerator changerCameraDeStartVersChoppe()
    {

        yield return new WaitForSeconds(2.3f);
        rb.isKinematic = false;
        cameraStart.enabled = false;
        cameraChoppe.enabled = true;        
    }

    void changerCameraDeRefillVersChoppe()
    {
        
        cameraChoppe.enabled = false;
        cameraCheckPoint.enabled = true;
    }
    
    IEnumerator changerCameraDeChoppeVersRefill()
    {

        yield return new WaitForSeconds(3.15f);
        rb.isKinematic = false;
        cameraCheckPoint.enabled = false;
        cameraChoppe.enabled = true;

    }


}
