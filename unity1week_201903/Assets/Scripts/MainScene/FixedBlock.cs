using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene{
    public class FixedBlock : BlockBase {

        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _moveFlg    = false;
            _objectType = Common.Const.ObjectType.kFixedBlock;
            base.Init(stageManager);
        }
    }
}