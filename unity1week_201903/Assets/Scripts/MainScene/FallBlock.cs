using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene{
    public class FallBlock : BlockBase {

        private bool _fallFlg;

        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="stageManager"></param>
        /// <param name="animationTime"></param>
        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _objectType = Common.Const.ObjectType.kFixedBlock;
            _fallFlg    = false;
            base.Init(stageManager);
        }

        // void Update()
        // {
        //     if(_fallFlg != true){
        //         return;
        //     }
        // }

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