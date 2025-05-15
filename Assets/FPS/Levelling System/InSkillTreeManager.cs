using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.FPS.UI
{
    public class InSkillTreeManager : Manager
    {
        #region Variables

        [Tooltip("Root GameObject of the skill tree menu used to toggle its activation")]
        [SerializeField] private GameObject skillTreeRoot;

        [Tooltip("Reference to the in-game menu to prevent conflicts")]
        [SerializeField] private GameObject inGameMenuRoot;

        [Tooltip("Master volume when skill tree menu is open")]
        [Range(0.001f, 1f)]
        [SerializeField] private float volumeWhenMenuOpen = 0.5f;

        //private UIManager uiManager; //Can replace this with a scenetype but prob gonna change it into a event thing

        #endregion

        #region Unity Methods

        public override void Start()
        {
            base.Start();
            skillTreeRoot.SetActive(false);

            //uiManager = GameObject.FindAnyObjectByType<UIManager>();
        }

        public override void Update()
        {
            if (Input.GetButtonDown(GameConstants.k_ButtonNameSkillTree)
                || (skillTreeRoot.activeSelf && Input.GetButtonDown(GameConstants.k_ButtonNameCancel)))
            {
                ToggleSkillTree();
            }
        }

        #endregion

        #region Custom Methods

        private void ToggleSkillTree()
        {
            bool isActive = !skillTreeRoot.activeSelf;
            SetSkillTreeActivation(isActive);
            if (!inGameMenuRoot.activeSelf)
            {
                SetCursorState(isActive);
            }
        }

        public void CloseSkillTreeMenu()
        {
            SetSkillTreeActivation(false);
            if (!inGameMenuRoot.activeSelf)
            {
                SetCursorState(false);
            }
        }

        private void SetSkillTreeActivation(bool active)
        {
            skillTreeRoot.SetActive(active);
            Time.timeScale = active ? 0f : 1f;
            AudioUtility.SetMasterVolume(active ? volumeWhenMenuOpen : 1f);
            EventSystem.current.SetSelectedGameObject(null);

            if (!active)
            {
                EventManager.Broadcast(Events.SkillTreeUIClosedEvent);
            }
        }

        private void SetCursorState(bool isActive)
        {
            Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isActive;
        }

        #endregion
    }
}
