using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXscr : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
