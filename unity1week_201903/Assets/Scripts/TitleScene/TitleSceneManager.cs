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
        #endregion

        // Use this for initialization
        void Start ()
        {
            _startButton.onClick.AddListener(()=>{
                _fadeManager.SetCallBack(()=>{
                    UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
                });
            });
            StartCoroutine(_fadeManager.FadeIn());
        }
        
        // Update is called once per frame
        void Update ()
        {
            
        }
    }
}