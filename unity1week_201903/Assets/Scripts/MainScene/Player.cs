using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class Player : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("スプライト")]
        private SpriteRenderer _sprite;
        [SerializeField, Tooltip("アニメーター")]
        private Animator _animator;
        [SerializeField, Tooltip("四角コライダー")]
        private BoxCollider2D _boxCollider2D;
        [SerializeField, Tooltip("円コライダー")]
        private CircleCollider2D _circleCollider2D;
        #endregion

        #region private field
        private bool _updateFlg;
        private bool _fallFlg;
        private bool _rollingFlg;
        private Vector3 _framePosition;
        #endregion

        #region access
        public bool FallFlg{
            get{return _fallFlg;}
        }
        #endregion

        public void Init()
        {
            _updateFlg = true;
            _fallFlg   = false;
            _framePosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if(_updateFlg != true){
                return;
            }
            Debug.Log(Vector3.Distance(_framePosition, transform.position));
            if(Vector3.Distance(_framePosition, transform.position) > 0.03f){
                _boxCollider2D.enabled    = false;
                _circleCollider2D.enabled = true;
            }
            _framePosition = transform.position;
            // 移動
            var pos                 = transform.localPosition;
            pos.x                  += Common.Const.MOVE_SPEED * Time.deltaTime;
            transform.localPosition = pos;
            FallCheck();
        }

        /// <summary>
        /// 衝突開始　トリガー
        /// </summary>
        /// <param name="other"></param>
        protected void OnTriggerEnter2D(Collider2D other)
        {

            // Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
            // if(other.GetComponent<HillBlock>() != null){
            //     _boxCollider2D.enabled    = false;
            //     _circleCollider2D.enabled = true;
            // }
        }


        /// <summary>
        /// 落下チェック
        /// </summary>
        private void FallCheck()
        {
            if(transform.position.y < Common.Const.BLOCK_SIZE_HALF * -Common.Const.NUM_HEIGHT){
                _fallFlg = true;
            }
        }

    }
}