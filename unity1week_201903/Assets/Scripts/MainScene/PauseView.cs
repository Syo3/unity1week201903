using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene{
    public class PauseView : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("canvasgroup")]
        private CanvasGroup _canvasGroup;
        [SerializeField, Tooltip("ポーズ終了ボタン")]
        private Button _pauseButton;
        [SerializeField, Tooltip("リトライボタン")]
        private Button _retryButton;
        [SerializeField, Tooltip("戻るボタン")]
        private Button _returnButton;
        #endregion

        #region private field
        private MainSceneManager _sceneManager;
        #endregion

        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            // ボタン設定
            _pauseButton.onClick.AddListener(()=>{
                _sceneManager.StageManager.PlayerPause(false);
                _sceneManager.DefaultView.Show(true);
                Show(false);
            });
            _retryButton.onClick.AddListener(()=>{
                _sceneManager.StageManager.Reset();
                _sceneManager.DefaultView.Show(true);
                Show(false);
            });
        }

        /// <summary>
        /// 表示設定
        /// </summary>
        /// <param name="flg"></param>
        public void Show(bool flg)
        {
            _canvasGroup.alpha          = flg ? 1.0f : 0.0f;
            _canvasGroup.interactable   = flg;
            _canvasGroup.blocksRaycasts = flg;
        }        

    }
}