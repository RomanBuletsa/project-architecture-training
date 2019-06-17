using System;
using System.Collections;
using System.Collections.Generic;
using Application;
using GameScene;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public GameSceneManager GameSceneManager { get; set; }

        [SerializeField] private Button menuButton;
        [SerializeField] private Button startButton;
        [SerializeField] private Text bestText;
        [SerializeField] private Text lastText;
        private float spawnRate = 2.5f;
        private int currentCount;
         
        private void Awake()
        {
            DontDestroyOnLoad(this);
            ApplicationManager.Instance.GameManager = this;
            
            menuButton.onClick.AddListener(OnMenuButtonClicked);

            startButton.onClick.AddListener(OnStartButtonClicked);
        }
        
        
        private void OnMenuButtonClicked()
        {
            Destroy(gameObject);
            SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());
        }
        
        private void OnStartButtonClicked()
        { 
            SceneManager.LoadScene(ApplicationManager.Instance.SelectedGameScene);
        }

        private void OnEnable()
        {
            int bestresult = PlayerPrefs.GetInt("Best",0);
            bestText.text = $"Best {bestresult}";
            
            int lastresult = PlayerPrefs.GetInt("Last",0);
            lastText.text = $"Last {lastresult}";
        }

        private void UpdateText()
        {
            GameSceneManager.CountText.text = $"{currentCount}";
        }
        
        public void RegisterGameSceneManager(GameSceneManager gameSceneManager)
        {
            GameSceneManager = gameSceneManager;
            StartGame();
        }

        private void StartGame()
        {
            StartCoroutine(SpawnCoroutine());
        }
        
        private IEnumerator SpawnCoroutine()
        {
            var timeElapsed = spawnRate;
            while (true)
            {
                if (timeElapsed > spawnRate)
                {
                    timeElapsed = 0f;
                    var newWall = Instantiate(GameSceneManager.WallPrefab,GameSceneManager.Position);
                    newWall.transform.parent = GameSceneManager.Parent;
                    newWall.WallCollision += OnWallCollision;
                    newWall.WallPassed += OnWallPassed;
                }

                timeElapsed += Time.deltaTime;
                
                yield return null;
            }
        }

        private void OnWallPassed(Wall thisWall)
        {
            thisWall.WallPassed -= OnWallPassed;
            currentCount++;
            UpdateText();
        }

        private void OnWallCollision(Wall thisWall)
        {
            thisWall.WallCollision -= OnWallCollision;
            
            int bestresult = PlayerPrefs.GetInt("Best");
            if(bestresult<currentCount) PlayerPrefs.SetInt("Best",currentCount);
            
            PlayerPrefs.SetInt("Last",currentCount);

            Destroy(gameObject);
            SceneManager.LoadScene(ApplicationScenes.Game.ToString(), LoadSceneMode.Single);
            
        }

        private void OnDestroy()
        {
            ApplicationManager.Instance.GameManager = null;
        } 
        
    }
}
