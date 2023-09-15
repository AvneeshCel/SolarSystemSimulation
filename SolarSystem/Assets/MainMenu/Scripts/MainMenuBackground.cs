using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackground : MonoBehaviour
{
    public Transform mainCamera;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(Mathf.Lerp(-155f,155f,timer/60),16.5f, -102f);

        if (timer > 60f)
        {
            timer = 0f;
        }
    }
}
