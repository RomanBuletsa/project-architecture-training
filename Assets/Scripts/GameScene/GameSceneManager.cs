using System;
using Application;
using Game;
using MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameScene
{
    public class GameSceneManager : MonoBehaviour
    {
        
        [SerializeField] private  GameObject parent;
        [SerializeField] private  GameObject position;
        [SerializeField] private  GameObject count;
        [SerializeField] private  GameObject wallPrefab;

        public GameObject WallPrefab => wallPrefab;
        public GameObject Parent => parent;
        public GameObject Position => position;
        public GameObject Count => count;
        
        
        private void Awake(){
            GameManager.Instance.GameSceneManager = this;
        }
        
        private void OnDestroy()
        {
            GameManager.Instance.GameSceneManager = null;
        } 
        
        
    }
    
    
}
