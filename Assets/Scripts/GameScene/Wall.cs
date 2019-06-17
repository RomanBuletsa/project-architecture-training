using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Random = System.Random;

namespace GameScene
{
    public class Wall : MonoBehaviour
    {

        public event Action<Wall> WallCollision;

        public event Action<Wall> WallPassed;

        [SerializeField] private GameObject top;
        [SerializeField] private GameObject bottom;

        [SerializeField] private float force = 5000;
        [SerializeField] private float destroyPos = -500;
        
        private Random rand;
        private Rigidbody2D _rigidbody2D;
        

/*        public void CollisionEnter2D()
        {
            WallCollision?.Invoke(this);
        }
        
        public void TriggerExit2D()
        {
            WallPassed?.Invoke(this);
        }*/

        void OnTriggerExit2D(Collider2D  col)
        {
            WallPassed?.Invoke(this);
        }
        
        void OnCollisionEnter2D(Collision2D col)
        {
            WallCollision?.Invoke(this);
        }
        

        void OnEnable()
        {
            rand = new Random();
            int move = rand.Next(-80, 50);
            top.transform.position=new Vector3(top.transform.position.x,top.transform.position.y+move,top.transform.position.z);
            bottom.transform.position=new Vector3(bottom.transform.position.x,bottom.transform.position.y+move,bottom.transform.position.z);
            
            _rigidbody2D = GetComponent<Rigidbody2D>();
            //_rigidbody2D.gravityScale = 0f;
            _rigidbody2D.AddForce(Vector2.left*force,ForceMode2D.Force);
        }    

        private void FixedUpdate()
        {
            /*var pos = transform.position;
            pos.x -= 2.5f;
            transform.position = pos;*/
            if(transform.position.x<=destroyPos) Destroy(gameObject);
            
        }
    }
}



