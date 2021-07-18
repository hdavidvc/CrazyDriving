using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    AudioSource fuenteDeAudio;
    public AudioClip win; 
    // Start is called before the first frame update
    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();   
        fuenteDeAudio.clip = win;
        fuenteDeAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
