using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class FixedHillBlock : BlockBase {

        #region SerializeField
        [SerializeField, Tooltip("オブジェクトタイプ")]
        private Common.Const.ObjectType _setObjectType;
        #endregion

        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _moveFlg    = false;
            _objectType = _setObjectType;
            base.Init(stageManager);
        }
    }
}