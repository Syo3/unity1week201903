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
        #endregion

        #region private field
        private bool _updateFlg;
        private bool _fallFlg;
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
        }

        // Update is called once per frame
        void Update()
        {
            if(_updateFlg != true){
                return;
            }
            // 移動
            var pos                 = transform.localPosition;
            pos.x                  += Common.Const.MOVE_SPEED * Time.deltaTime;
            transform.localPosition = pos;
            FallCheck();
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