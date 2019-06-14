using System;
using Game;
using MainMenu;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

namespace Application
{
    public class ApplicationManager : MonoBehaviour
    {
        public static ApplicationManager Instance { get; private set; }
        public MainMenuManager MainMenuManager { get; set; }
        public GameManager GameManager { get; set; }
        public String SelectedGameScene  { get; set; }
        
        public enum ApplicationScenes
        {
            Application,
            MainMenu,
            Game
        }
        

        private void Awake()
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        
        private void Start()
        {
            SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());
        }
        
        
        
        
        
    }
}
