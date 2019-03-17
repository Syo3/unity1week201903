using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class TutorialView : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("CanvasGroup")]
        private CanvasGroup _canvasGroup;
        [SerializeField, Tooltip("TapTutorialCanvasGroup")]
        private CanvasGroup _tapCanvasGroup;
        [SerializeField, Tooltip("DragCanvasGroup")]
        private CanvasGroup _dragCanvasGroup;
        #endregion

        #region private field
        private MainSceneManager _sceneManager;
        private int _tutorialCnt;
        #endregion

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            _tutorialCnt  = 0;
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


        public void ShowDragTutorial()
        {
            ++_tutorialCnt;
            _tapCanvasGroup.alpha           = 1;
            _tapCanvasGroup.interactable    = false;
            _tapCanvasGroup.blocksRaycasts  = false;
            _dragCanvasGroup.alpha          = 0;
            _dragCanvasGroup.interactable   = false;
            _dragCanvasGroup.blocksRaycasts = false;
            _dragCanvasGroup.gameObject.SetActive(false);
        }

        public void EndTutorial()
        {
            if(_tutorialCnt > 0){
                if(_tapCanvasGroup.gameObject.activeSelf){
                    _tapCanvasGroup.alpha = 0;
                }
                Show(false);
            }
        }
        #endregion
    }
}