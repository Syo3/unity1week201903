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

        private bool _updateFlg;

        public void Init()
        {
            _updateFlg = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(_updateFlg != true){
                return;
            }
            var pos = transform.localPosition;
            pos.x += Common.Const.MOVE_SPEED;
            transform.localPosition = pos;
        }
    }
}