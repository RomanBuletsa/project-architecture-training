using System;
using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {

        [SerializeField] private Button gameButton;
        [SerializeField] private Dropdown dropdown;
        [SerializeField] private String[] scanes;
        
        private void Awake()
        {
            ApplicationManager.Instance.MainMenuManager = this;
            
            ApplicationManager.Instance.SelectedGameScene = scanes[0];
			
            gameButton.onClick.AddListener(OnSomeButtonClicked);

            dropdown.onValueChanged.AddListener(delegate {
                DropdownValueChanged(dropdown);
            });
        }
        
        private void OnSomeButtonClicked() => SceneManager.LoadScene(ApplicationScenes.Game.ToString());

        private void DropdownValueChanged(Dropdown change)
        {
            ApplicationManager.Instance.SelectedGameScene = scanes[change.value];
        }

        private void OnDestroy()
        {
            ApplicationManager.Instance.MainMenuManager = null;
        }
    }
}
