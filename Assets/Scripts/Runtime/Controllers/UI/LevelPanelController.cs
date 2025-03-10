using System.Collections.Generic;
using DG.Tweening;
using Runtime.Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Controllers.UI
{
    public class LevelPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Seriazlied Variables

        [SerializeField] private List<Image> stageImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI>();
        
        #endregion

        #endregion
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onSetlevelValue += OnSetLevelValue;
            UISignals.Instance.onSetStageColor += OnSetStageColor;
        }

        private void OnSetLevelValue(byte levelValue)
        {
            var additionalValue = ++levelValue;
            levelTexts[0].text = additionalValue.ToString();
            additionalValue++;
            levelTexts[1].text = additionalValue.ToString();
        }
        
        private void OnSetStageColor(byte stageValue)
        {
            stageImages[stageValue].DOColor(Color.yellow, 0.5f);
        }
        
        private void UnsubscribeEvents()
        {
            UISignals.Instance.onSetlevelValue -= OnSetLevelValue;
            UISignals.Instance.onSetStageColor -= OnSetStageColor;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
    }
}