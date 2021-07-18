using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Range(0,20), SerializeField, Tooltip("Velocidad lineal maxima del coche")]
    private float speed = 20f;

    [Range(0,90), SerializeField, Tooltip("Velocidad de giro maxima del coche")]
    private float turnSpeed = 45f;

    private float verticalInput, horizontalInput;

    AudioSource fuenteDeAudio;
    public AudioClip inicio,aceleracion,choque,win; 

    float WaitTime = 0.9f; // time to wait
    bool Dieing;

    public GameObject nivel,player,image;
    public int level;
    public bool choquec;

    public Text scoreText;
    private float score,time;

    private void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();   
        fuenteDeAudio.clip = inicio;
        fuenteDeAudio.Play();

        nivel = GameObject.Find ("level");
        nivel.SetActive(true);
        player = GameObject.Find ("Player");
        player.SetActive(true);


    // Update is called once per frame
    }
    void Update()
    {
        time = Time.deltaTime;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(!choquec) {
        this.transform.Translate(speed*Time.deltaTime*Vector3.forward*verticalInput);
        this.transform.Rotate(turnSpeed*Time.deltaTime*Vector3.up*horizontalInput);
        }

        if (speed <= 40) {
        speed = speed + 0.090f;
        }
        if (turnSpeed <= 60) {
        turnSpeed = turnSpeed + 0.010f;
        }

         if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            fuenteDeAudio.clip = aceleracion;
            fuenteDeAudio.Play();
            nivel.SetActive(false);
            score+= 20 * time;
            Debug.Log(score);

        } else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) {
            fuenteDeAudio.Stop();
        }
            scoreText.text = "Score "+ ((int)score).ToString();
    }
    void OnCollisionEnter(Collision micolision) {

        if (micolision.gameObject.name == "barrera") {    
            // this.transform.position = new Vector3(0f,0f,369.05f);
             choquec = true;
             fuenteDeAudio.clip = choque;
             fuenteDeAudio.Play();       
            // Dead();
           StartCoroutine(dieing(WaitTime));
        }
    }

    IEnumerator dieing(float waitTime){
    yield return new WaitForSeconds(waitTime);
    SceneManager.LoadScene("Level"+level);
    }

    void OnTriggerEnter(Collider meta) {
        if (meta.name == "Meta") {
        
                level++;
            if (level<=3) {
                choquec = true;
                SceneManager.LoadScene("Level"+ level);
            } else {
                SceneManager.LoadScene("win"); 
            }
        }

        Debug.Log(level);
    }



}

