using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TitleScene{
    public class TitleSceneManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("フェード管理")]
        private FadeManager _fadeManager;
        [SerializeField, Tooltip("スタートボタン")]
        private Button _startButton;
        [SerializeField, Tooltip("")]
        private Character _character;
        [SerializeField, Tooltip("CanvasGroup")]
        private CanvasGroup _canvasGroup;
        [SerializeField, Tooltip("サウンド管理")]
        private MainScene.SoundManager _soundManager;
        #endregion

        #region access
        public MainScene.SoundManager SoundManager{
            get{return _soundManager;}
        }
        #endregion

        // Use this for initialization
        void Start ()
        {
            _character.Init(this);
            _startButton.onClick.AddListener(()=>{
                _soundManager.PlayOnShot(2);
                // _fadeManager.SetCallBack(()=>{
                //     UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
                // });
                // StartCoroutine(_fadeManager.FadeOut());
                DontDestroyOnLoad(_character);
                _character.GameStart();
                _canvasGroup.alpha = 0.0f;

            });
            StartCoroutine(_fadeManager.FadeIn());
        }
        

    }
}