using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public event Action MenuButtonClicked;
        public event Action ChangeButtonClicked;
        
        [SerializeField] private Image Image;
        
        [SerializeField] private Button MenuButton;
        [SerializeField] private Button ChangeButton;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
			
            MenuButton.onClick.AddListener(OnMenuButtonClicked);

            MenuButtonClicked += OnButtonMenuClicked;
            
            
            ChangeButton.onClick.AddListener(OnChangeButtonClicked);

            ChangeButtonClicked += OnButtonChangeClicked;
        }
        
        
        private void OnButtonMenuClicked()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            
        }
        
        private void OnButtonChangeClicked()
        {
            Color randomColor = GetRandomColor();
            if(Image.color==Color.blue) Image.color = Color.red;
            else Image.color = Color.blue;
            
        }

        private static Color GetRandomColor() =>
            new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f));

        private void OnMenuButtonClicked()
        {
         MenuButtonClicked?.Invoke();
        }
        
        private void OnChangeButtonClicked()
        {
            ChangeButtonClicked?.Invoke();
        }

        private void OnDestroy()
        {
            MenuButtonClicked -= OnButtonMenuClicked;
            ChangeButtonClicked -= OnButtonChangeClicked;
        } 
        
    }
}
