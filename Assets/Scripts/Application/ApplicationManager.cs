using System;
using MainMenu;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

namespace Application
{
    public class ApplicationManager : MonoBehaviour
    {
        public static ApplicationManager Instance { get; private set; }
        
        public MainMenuManager MainMenuManager { get; set;  }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
