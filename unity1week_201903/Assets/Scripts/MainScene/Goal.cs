using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public void Init(StageManager stageManager)
        {
            _goalFlg = false;
            base.Init(stageManager);
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

    }
}