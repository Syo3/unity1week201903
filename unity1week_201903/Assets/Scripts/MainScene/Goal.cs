﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene{
    public class Goal : BlockBase {

        [SerializeField, Tooltip("クリア画像")]
        private Sprite _clearImage;

        #region private field
        private bool _goalFlg;
        private Vector3 _defaultPosition;
        #endregion

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="stageManager"></param>
        public void Init(StageManager stageManager, float animationTime)
        {
            _moveFlg    = false;
            _fixedFlg   = true;
            _goalFlg    = false;
            _objectType = Common.Const.ObjectType.kGoal;
            _defaultPosition = transform.localPosition;
            base.Init(stageManager, animationTime);
        }
        #endregion

        /// <summary>
        /// 接触した場合
        /// </summary>
        /// <param name="other"></param>
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if(_goalFlg){
                return;
            }
            _animator.enabled = false;
            _sprite.sprite    = _clearImage;
            _stageManager.AddGoalCnt();
            _goalFlg = true;
        }
    }
}