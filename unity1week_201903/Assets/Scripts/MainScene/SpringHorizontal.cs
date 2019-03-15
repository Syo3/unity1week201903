using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MainScene{
    public class SpringHorizontal : BlockBase {

        #region SerializeField
        [SerializeField, Tooltip("")]
        private Common.Const.ObjectType _setObjectType;
        #endregion

        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _objectType = _setObjectType;
            base.Init(stageManager);
        }

        /// <summary>
        /// 衝突開始　物体
        /// </summary>
        /// <param name="collision"></param>
        protected void OnCollisionEnter2D(Collision2D collision)
        {
            // アニメーションさせる
            _animator.Play("SpringUp");
        }

    }
}