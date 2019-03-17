using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene{
    public class DefaultView : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("canvasgroup")]
        private CanvasGroup _canvasGroup;
        [SerializeField, Tooltip("ポーズボタン")]
        private Button _pauseButton;
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
                // プレイヤーの動きを止めて　ポーズ画面を表示する
                _sceneManager.StageManager.PlayerPause(true);
                _sceneManager.PauseView.Show(true);
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