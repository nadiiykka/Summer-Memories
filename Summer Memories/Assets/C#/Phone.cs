using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject MessagePrefab;
    public GameObject PhonePrefab;
    public Animator phoneAnimation;
    public Animator cameraAnim;
    public Animator birdAnim;
    public AudioSource ringing;
    private float dilay = 5f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        MessagePrefab.SetActive(false);
        PhonePrefab.SetActive(false);
        phoneAnimation.GetComponent<Animator>();
        phoneAnimation.enabled = false;
        cameraAnim.GetComponent<Animator>();
        cameraAnim.enabled = false;
        birdAnim.SetFloat("Fly", 0.0f);
        cameraAnim.SetFloat("Dialogue", 0.0f);
        ringing.GetComponent<AudioSource>();
        ringing.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > dilay) 
        {
            MessagePrefab.SetActive(true);
            PhonePrefab.SetActive(true);
            phoneAnimation.enabled = true;
            cameraAnim.enabled = true;
            birdAnim.SetFloat("Fly", 1.0f);
            ringing.enabled = true;
        }
    }
}
