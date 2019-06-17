
using Application;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene
{
    public class GameSceneManager : MonoBehaviour
    {
        
        [SerializeField] private  Transform parent;
        [SerializeField] private  Transform position;
        [SerializeField] private  Text countText;
        [SerializeField] private  Wall wallPrefab;

        public Wall WallPrefab => wallPrefab;
        public Transform Parent => parent;
        public Transform Position => position;
        public Text CountText => countText;
        
        
        private void Awake(){
            ApplicationManager.Instance.GameManager.RegisterGameSceneManager(this);
        }
        
        private void OnDestroy()
        {
        } 
        
        
    }
    
    
}
