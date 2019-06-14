using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float tap=2000;
    
    private bool jump;
    private float rotation;

    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        //GetComponent<Rigidbody2D>().gravityScale = 0f;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Jump")) jump = true;
    }
        

    void FixedUpdate()
    {
        if (jump)
        {
            _rigidbody2D.AddForce(Vector2.up*tap*3.5f,ForceMode2D.Force);
            rotation += 0.2f;
            rotation = Math.Min(rotation, 0.2f);
            jump = false;
        }
        
        rotation -= 0.003f;
        rotation = Math.Max(rotation, -0.7f);
        _rigidbody2D.AddForce(-Vector2.up*(tap/15),ForceMode2D.Force);
        transform.rotation=new Quaternion(0,0,rotation,1f);
    }
    
    
    
/*    private void FixedUpdate()
    {
        if (jump)
        {
            transform.Translate(Vector3.up * 25 , Space.World);
            jump = false;
            rotation += 0.3f;
            rotation = Math.Min(rotation, 0.2f);
        }

        rotation -= 0.01f;
        rotation = Math.Max(rotation, -0.7f);
        
        transform.Translate(-Vector3.up * 1.4f , Space.World);
        transform.rotation=new Quaternion(0,0,rotation,1f);
    }
    

    void Update()
    {
        if (Input.GetButtonDown("Jump")) jump = true;
    }*/

    
    
    
}
