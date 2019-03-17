using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene{
    public class GameClearView : MonoBehaviour {

        #region SerializeField 
        [SerializeField, Tooltip("canvasgroup")]
        private CanvasGroup _canvasGroup;
        [SerializeField, Tooltip("終了ボタン")]
        private Button _nextButton;
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
            _nextButton.onClick.AddListener(()=>{
                if(GameObject.Find("Character") != null){
                    Destroy(GameObject.Find("Character"));
                }
                // フェード
                _sceneManager.FadeManager.SetCallBack(()=>{
                    // ステージ初期化
                    UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
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