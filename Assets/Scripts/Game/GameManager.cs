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
        private Random rnd = new Random();
        
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
            //Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            if(Image.color==Color.blue) Image.color = Color.red;
            else Image.color = Color.blue;
            
        }

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
