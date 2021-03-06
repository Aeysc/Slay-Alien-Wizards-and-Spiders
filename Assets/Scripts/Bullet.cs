﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
    :
    MonoBehaviour
{
    void Update()
    {
        lifetime.Update( Time.deltaTime );
        
        if( lifetime.IsDone() ) Destroy( gameObject );
    }
    public void SetPos( Vector3 pos )
    {
        transform.position = pos;
    }
    public void SetVel( Vector2 dir )
    {
        GetComponent<Rigidbody2D>()
            .AddForce( dir * ( speed + Random
            .Range( -speedDev,speedDev ) ),
            ForceMode2D.Impulse );

        vel = dir;
    }
    void OnTriggerEnter2D( Collider2D other )
    {
        if( other.tag != "Player" )
        {
            Enemy script = other.gameObject
                .GetComponent<Enemy>();
            if( script != null )
            {
                if( Input.GetKey( KeyCode.LeftShift ) )
                {
                    script.Attack( 999,
                        new Vector2( 0.0f,0.0f ) );
                }
                script.Attack( 1,vel * 1.35f );
            }
            Destroy( gameObject );
        }
    }
    // 
    const float speed = 19.7f;
    const float speedDev = 4.1f;
    Timer lifetime = new Timer( 0.24f );
    Vector2 vel = new Vector2( 0.0f,0.0f );
}
