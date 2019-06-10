using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public event Action ButtonClicked;
        
        [SerializeField] private Button GameButton;
        
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
			
            GameButton.onClick.AddListener(OnSomeButtonClicked);

            ButtonClicked += OnButtonClicked;
        }
        
        
        private void OnButtonClicked()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            
        }
        
        private void OnSomeButtonClicked() => ButtonClicked?.Invoke();
        
        private void OnDestroy() => ButtonClicked -= OnButtonClicked;
        
    }
}
