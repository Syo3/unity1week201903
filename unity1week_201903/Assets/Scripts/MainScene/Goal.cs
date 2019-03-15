using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene{
    public class Goal : BlockBase {

        #region private field
        private bool _goalFlg;
        #endregion

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="stageManager"></param>
        public void Init(StageManager stageManager, float animationTime)
        {
            _goalFlg    = false;
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
            if(_goalFlg){
                return;
            }
            Debug.Log("Clear");
            _stageManager.AddGoalCnt();
            _goalFlg = true;
        }

        /// <summary>
        /// ドラッグ
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            // 振動させるとか
            // 動かせない演出
        }
    }
}