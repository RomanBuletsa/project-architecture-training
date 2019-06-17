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
        private static ApplicationManager instance;

        public static ApplicationManager Instance
        {
            get
            {
                if (instance == null) SceneManager.LoadScene(ApplicationScenes.Application.ToString());
                return instance;
            }
            private set => instance = value;
        }
        public MainMenuManager MainMenuManager { get; set; }
        public GameManager GameManager { get; set; }
        public String SelectedGameScene  { get; set; }

        

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