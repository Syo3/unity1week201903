using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class FixedFallBlock : BlockBase {

        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _fixedFlg   = true;
            _moveFlg    = false;
            _objectType = Common.Const.ObjectType.kFixedFallBlock;
            base.Init(stageManager);
        }


        /// <summary>
        /// 衝突終了 物体
        /// </summary>
        /// <param name="collision"></param>
        protected void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.GetComponent<Player>() == null){
                return;
            }
            _fixedFlg = true;
            _fallFlg  = true;
            _rigidBody.bodyType       = RigidbodyType2D.Dynamic;
            _rigidBody.constraints    = RigidbodyConstraints2D.FreezePositionX;
            _rigidBody.freezeRotation = true;
        }


    }
}