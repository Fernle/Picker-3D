using System.Collections.Generic;
using Runtime.Enums;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region SerializedFields Variables

        [SerializeField] private List<Transform> layers = new List<Transform>();

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreUISignals.Instance.onOpenPanel += OnOpenPanel;
            CoreUISignals.Instance.onClosePanel += OnClosePanel;
            CoreUISignals.Instance.onCloseAllPanels += OnCloseAllPanels;
        }

        private void OnOpenPanel(UIPanelTypes panelType, int value)
        {
            Instantiate(Resources.Load<GameObject>($"Screens/{panelType}Panel"), layers[value]);
        }

        private void OnClosePanel(int value)
        {
            if (layers[value]. childCount <= 0) return;
#if UNITY_EDITOR
            DestroyImmediate(layers[value].GetChild(0).gameObject);
#else
            Destroy(layers[value].GetChild(0).gameObject);
#endif
        }

        private void OnCloseAllPanels()
        {
            foreach (var layer in layers)
            {
                if (layer.childCount <= 0) return;
#if UNITY_EDITOR
                DestroyImmediate(layer.GetChild(0).gameObject);
#else
                Destroy(layer.GetChild(0).gameObject);
#endif
            }
        }
        
        private void UnsubscribeEvents()
        {
            CoreUISignals.Instance.onOpenPanel -= OnOpenPanel;
            CoreUISignals.Instance.onClosePanel -= OnClosePanel;
            CoreUISignals.Instance.onCloseAllPanels -= OnCloseAllPanels;
        }
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
    }
}