using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleScene{
    public class Character : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("アニメーター")]
        private Animator _animator;

        [SerializeField, Tooltip("ベッドスプライト")]
        private SpriteRenderer _bedSprite;
        #endregion

        #region private field
        private TitleSceneManager _sceneManager;
        #endregion

        #region public function
        public void Init(TitleSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            _animator.Play("CharacterWait");
        }

        public void GameStart()
        {
            StartCoroutine(GameStartCoroutine());
        }
        #endregion

        private IEnumerator GameStartCoroutine()
        {
            _animator.Play("CharacterGrowth");
            yield return null;
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            while(stateInfo.normalizedTime < 1.0f ){
                Debug.Log("check");
                yield return null;
                stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            }
            _animator.Play("CharacterMove");
            while(Vector3.Distance(transform.position, _bedSprite.transform.position) > 0.05f){
                Debug.Log("check");

                yield return null;
                _bedSprite.transform.Translate(new Vector3(-0.05f, 0.0f, 0.0f));
            }
            _bedSprite.transform.position = transform.position;
            yield return null;
            _animator.Play("CharacterGotoBed");
            yield return null;
            _bedSprite.enabled = false;
            stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            while(stateInfo.normalizedTime < 1.0f ){
                Debug.Log("check");
                yield return null;
                stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            }

            // -5.1まで移動
            while(Vector3.Distance(transform.position, new Vector3(0.0f, -5.1f, 0.0f)) > 0.05f){
                Debug.Log("check");

                yield return null;
                transform.Translate(new Vector3(0.0f, -0.05f, 0.0f));
            }
            _animator.Play("CharacterSleep");
            yield return null;
            stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            while(stateInfo.normalizedTime < 0.8f ){
                yield return null;
                stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }
    }
}