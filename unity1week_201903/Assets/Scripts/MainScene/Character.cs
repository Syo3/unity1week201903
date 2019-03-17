using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class Character : BlockBase {

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="stageManager"></param>
        public void Init(StageManager stageManager, float animationTime)
        {
            _moveFlg    = false;
            _fixedFlg   = true;
            _objectType = Common.Const.ObjectType.kGoal;
            base.Init(stageManager, animationTime);
        }
        #endregion

        /// <summary>
        /// 接触した場合
        /// </summary>
        /// <param name="other"></param>
        protected void OnTriggerEnter2D(Collider2D other)
        {
            _rigidBody.bodyType = RigidbodyType2D.Dynamic;
            _rigidBody.AddForce(new Vector2(20.0f, 30.0f));
            _animator.enabled   = false;
            _stageManager.AddGoalCnt();
        }

    }
}