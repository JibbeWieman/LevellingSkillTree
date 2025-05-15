using System.Collections;
using TMPro;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI // FIX UI BAR 
{
    public class PlayerXpBar : MonoBehaviour
    {
        [Tooltip("Image component displaying current XP")]
        public Image XpFillImage;

        public TextMeshProUGUI PlayerLevelText;

        [SerializeField, Tooltip("Speed of the XP bar transition")]
        private float LerpSpeed = 5f;

        [SerializeField]
        private SceneTypeObject ST_GameManager;

        private XpManager _xpManager;
        private Coroutine currentLerpCoroutine;


        void Start()
        {
            _xpManager = ST_GameManager.Objects[0].GetComponent<XpManager>();

            // Handle error if XpManager is null
            DebugUtility.HandleErrorIfNullGetComponent<XpManager, PlayerXpBar>(_xpManager, this, gameObject);

            EventManager.AddListener<XpUpdateEvent>(UpdateXpBar);

            XpFillImage.fillAmount = 0;
        }

        /*void Update()
        {
            if (m_XpManager != null)
            {
                // Calculate target fill amount based on current XP
                float targetXpFill = (float)(m_XpManager.m_PlayerXP - m_XpManager.m_PrevThreshold)
                    / (float)m_XpManager.m_CurThreshold;

                // Slowly update xp bar value
                XpFillImage.fillAmount = Mathf.Lerp(XpFillImage.fillAmount, targetXpFill, Time.deltaTime * LerpSpeed);
                PlayerLevelText.text = m_XpManager.m_PlayerLevel.ToString();
            }
        }*/

        private void UpdateXpBar(XpUpdateEvent evt)
        {
            // Calculate target fill amount based on current XP
            float targetXpFill = (float)(_xpManager.PlayerXP - _xpManager.PrevThreshold)
                / (float)(_xpManager.CurThreshold - _xpManager.PrevThreshold);

            // If there's an active Lerp coroutine, stop it
            if (currentLerpCoroutine != null)
            {
                StopCoroutine(currentLerpCoroutine);
            }

            // Start a new Lerp coroutine
            currentLerpCoroutine = StartCoroutine(LerpXpFill(targetXpFill));

            //// Slowly update xp bar value
            //XpFillImage.fillAmount = Mathf.Lerp(XpFillImage.fillAmount, targetXpFill, Time.deltaTime * LerpSpeed);
            PlayerLevelText.text = _xpManager.PlayerLevel.ToString();
        }

        private IEnumerator LerpXpFill(float targetXpFill)
        {
            // Continuously lerp until the fill amount reaches the target value
            while (Mathf.Abs(XpFillImage.fillAmount - targetXpFill) > 0.01f)
            {
                XpFillImage.fillAmount = Mathf.Lerp(XpFillImage.fillAmount, targetXpFill, Time.deltaTime * LerpSpeed);
                yield return null;  // Wait until the next frame
            }

            // Set the final value to make sure it's accurate
            XpFillImage.fillAmount = targetXpFill;
        }

        private void OnDestroy()
        {
            EventManager.RemoveListener<XpUpdateEvent>(UpdateXpBar);
        }
    }
}
