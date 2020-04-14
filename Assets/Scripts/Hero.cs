using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Transform cam;
    public float camDistanceX;
    public float camVelocity;

    public GameObject character;
    public float velocity;

    private Animation anim;
    private AudioSource _audio;
    
    // Start is called before the first frame update
    void Start()
    {
        //Obtain the animation component of the character
        anim = character.GetComponent<Animation>();

        GetComponent<Renderer>().enabled = false;

        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Camera
        float dis = transform.position.x - cam.transform.position.x;

        if(Mathf.Abs(dis) > camDistanceX)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position,
                                               new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z),
                                               camVelocity * Time.deltaTime);
        }
        

        //Move
        float move = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        transform.Translate(move, 0.0f, 0.0f);

        //Animation of Run and Idle
        if(Mathf.Abs(move) > 0)
        {
            anim.CrossFade("Run");
        }
        else if(move == 0.0f)
        {
            anim.CrossFade("Idle");
        }

        //Oritentation
        if(move > 0.0f)
        {
            character.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
        }
        else if(move < 0.0f)
        {
            character.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
        }

        //GUN
        if (Input.GetButton("Jump") && move == 0.0f)
        {
            anim.CrossFade("Fire");
        }

        //Verify if your position is not null and the audio is not playing
        if(move != 0.0f && !_audio.isPlaying)
        {
            //Sound
            _audio.Play();
        }
    }
}
