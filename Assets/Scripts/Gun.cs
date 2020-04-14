using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform aim;
    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Shotting
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bullet, aim.transform.position, transform.rotation);
        }
    }
}
