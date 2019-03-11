using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene{
    public class ClearView : MonoBehaviour {

        [SerializeField, Tooltip("canvasgroup")]
        private CanvasGroup _canvasGroup;
        [SerializeField, Tooltip("次のステージへボタン")]
        private Button _nextStageButton;

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
            _nextStageButton.onClick.AddListener(()=>{
                // フェード
                _sceneManager.FadeManager.SetCallBack(()=>{
                    // ステージ初期化
                    _sceneManager.StageManager.Reset();
                    _sceneManager.FadeManager.SetCallBack(()=>{
                        _sceneManager.StageManager.PlayerInit();
                    });
                    StartCoroutine(_sceneManager.FadeManager.FadeIn());
                });
                StartCoroutine(_sceneManager.FadeManager.FadeOut());
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