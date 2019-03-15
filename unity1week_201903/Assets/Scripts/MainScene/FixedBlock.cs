using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene{
    public class FixedBlock : BlockBase {

        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _objectType = Common.Const.ObjectType.kFixedBlock;
            base.Init(stageManager);
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