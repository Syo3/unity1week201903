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
        [SerializeField, Tooltip("ブラックアウト用")]
        private Image _blackOutImage;
        [SerializeField, Tooltip("リアル羊アニメーター")]
        private Animator _realAnimator;
        [SerializeField, Tooltip("クリア文字")]
        private TMPro.TextMeshProUGUI _clearText;
        [SerializeField, Tooltip("羊")]
        private Animator _merryAnimator;
        #endregion

        #region private field
        private MainSceneManager _sceneManager;
        #endregion

        public Button NextButton{
            get{return _nextButton;}
        }


        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            // ボタン設定
            _nextButton.enabled = false;
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

        public void EndAnimation()
        {
            Show(true);
            StartCoroutine(EndAnimationCoroutine());
            _sceneManager.SoundManager.StopBgm();
        }

        private IEnumerator EndAnimationCoroutine()
        {
            // 羊が近づく
            _merryAnimator.Play("Move");
            while(Vector3.Distance(_merryAnimator.transform.position, new Vector3(-1.0f, -5.1f, 0.0f)) > 1.0f){
                Debug.Log(Vector3.Distance(_merryAnimator.transform.position, new Vector3(-1.0f, -5.1f, 0.0f)));
                yield return null;
                _merryAnimator.transform.Translate(new Vector3(0.025f, 0.0f, 0.0f));
            }
            _merryAnimator.enabled = false;
            // キャラ起きる
            var character = GameObject.Find("Character");
            character.GetComponent<Animator>().Play("CharacterGetUp");
            yield return null;
            for(var i = 0; i < 120; ++i){
                yield return null;
            }
            // 画面暗転
            _blackOutImage.color = Color.black;

            // 羊表示 から　消える
            _realAnimator.Play("RealPop");
            yield return null;
            var stateInfo = _realAnimator.GetCurrentAnimatorStateInfo(0);
            while(stateInfo.normalizedTime < 1.0f ){
                yield return null;
                stateInfo = _realAnimator.GetCurrentAnimatorStateInfo(0);
            }
            _realAnimator.gameObject.SetActive(false);
            
            // クリア表示
            var color = _clearText.color;
            while(color.a < 1.0f ){
                yield return null;
                color.a += 0.05f;
                _clearText.color = color;
            }
            
            // ボタンオン
            _nextButton.enabled = true;
        }
    }
}