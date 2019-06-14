using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace GameScene
{
    public class Barrier : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D col)
        {
            transform.parent.GetComponent<Wall>().CollisionEnter2D();
        }


    }
}
