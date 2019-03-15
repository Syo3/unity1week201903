using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class HillBlock : BlockBase {

        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _objectType = Common.Const.ObjectType.kHillBlock;
            base.Init(stageManager);
        }
    }
}