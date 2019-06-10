using System;
using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public event Action ButtonClicked;
        
        [SerializeField] private Button gameButton;
        
        
        private void Awake()
        {
            ApplicationManager.Instance.MainMenuManager = this;
            
            DontDestroyOnLoad(this);
			
            gameButton.onClick.AddListener(OnSomeButtonClicked);
        }
        
        private void OnSomeButtonClicked() => ButtonClicked?.Invoke();
        
        private void OnDestroy()
        {
            ApplicationManager.Instance.MainMenuManager = null;
        }
    }
}
