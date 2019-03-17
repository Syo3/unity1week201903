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
        #endregion

        // Use this for initialization
        void Start ()
        {
            _character.Init(this);
            _startButton.onClick.AddListener(()=>{
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