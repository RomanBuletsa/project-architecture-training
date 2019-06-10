using System;
using MainMenu;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

namespace Application
{
    public class ApplicationManager : MonoBehaviour
    {
        public MainMenuManager MainMenuManager { get; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
