using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject MessagePrefab;
    public Animator phoneAnimation;
    public Animator cameraShake;
    // public AudioSource ringing;
    private float dilay = 5f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        MessagePrefab.SetActive(false);
        phoneAnimation.GetComponent<Animator>();
        phoneAnimation.enabled = false;
        cameraShake.GetComponent<Animator>();
        cameraShake.enabled = false;
        // ringing.GetComponent<AudioSource>();
        // ringing.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > dilay) 
        {
            MessagePrefab.SetActive(true);
            phoneAnimation.enabled = true;
            cameraShake.enabled = true;
            // ringing.enabled = true;
        }
    }
}
