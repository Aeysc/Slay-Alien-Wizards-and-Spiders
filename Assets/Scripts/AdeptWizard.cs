﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AdeptWizard
    :
    MonoBehaviour
{
    void Start()
    {
        player = Utility.FindInScene( "Player" );

        bullet = Utility.FindInScene( "PrefabManager" )
            .GetComponent<PrefabManagerScript>()
            .mageBullet;
    }
    void Update()
    {
        refireTime.Update( Time.deltaTime );

        if( refireTime.IsDone() && Mathf
            .Abs( player.transform.position.y -
            transform.position.y ) < yTolerance )
        {
            refireTime.Reset();

            Vector2 vel = new Vector2( 0.0f,0.0f );

            if( player.transform.position.x <
                transform.position.x )
            {
                vel.x = -1.0f;
                ScaleBy( -1 );
            }
            else if( player.transform.position.x >
                transform.position.x )
            {
                vel.x = 1.0f;
                ScaleBy( 1 );
            }

            GameObject bull = Instantiate( bullet );
            bull.transform.position = transform.position;
            bull.GetComponent<MagicMove>().SetVel( vel );
        }
    }
    void ScaleBy( int dir )
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs( scale.x ) * ( float )dir;
        transform.localScale = scale;
    }
    // 
    Timer refireTime = new Timer( 1.1f );
    GameObject bullet;
    GameObject player;
    const float yTolerance = 0.783f;
}
