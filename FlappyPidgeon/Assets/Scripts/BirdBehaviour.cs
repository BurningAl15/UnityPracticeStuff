using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour {

    public bool isDead;
    public bool onTouch;
    private Rigidbody2D rgb;
    public float upForce = 200f;
    private Animator anim;
    //public Controller control;
    public float sensitivity = 100;
    public float loudness = 0;
    AudioSource _audio;
    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //control = FindObjectOfType<Controller>();

        //_audio = GetComponent<AudioSource>();
        //_audio.clip = Microphone.Start(null, true, 10, 44100);
        //_audio.loop = true;
        //_audio.mute = true;
        //while (!(Microphone.GetPosition(null) > 0))
        //{ }
        //_audio.Play();
    }

    // Use this for initialization
    void Start () {
        isDead = false;
        onTouch = false;
	}

    // Update is called once per frame
    void Update() {
        //if (isDead == false)
        //{
        //    Movimiento();  
        //}
        //onTouch = false;
        if (isDead) return;
        //VoiceControl
        //loudness = GetAverageVolume() * sensitivity;
        //if (loudness > 8)
        //    rgb.velocity = new Vector2(rgb.velocity.x, 4);
        Movimiento();
        
    }

    float GetAverageVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        //control.BirdDie();
        Controller.instance.BirdDie();
        anim.SetBool("isDead",isDead);
        rgb.velocity = Vector2.zero;
        SoundSystem.instance.PlayHit();
    }

    private void Movimiento()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            rgb.velocity = Vector2.zero;
            Vector2 YForce = Vector2.up * upForce;
            rgb.AddForce(YForce);
            //onTouch = true;
            anim.SetTrigger("onTouch");
            SoundSystem.instance.PlayFlap();
        }
        //anim.SetBool("OnTouch", onTouch);
    }


}
