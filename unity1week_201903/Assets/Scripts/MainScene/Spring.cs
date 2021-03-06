﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class Spring : BlockBase {

        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _objectType = Common.Const.ObjectType.kSpring;
            base.Init(stageManager);
        }

        /// <summary>
        /// 衝突開始　物体
        /// </summary>
        /// <param name="collision"></param>
        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.name.IndexOf("Player") < 0){
                return;
            }
            _stageManager.SceneManager.SoundManager.PlayOnShot(1);

            // アニメーションさせる

            _animator.Play("SpringUp", 0, 0.0f);
        }

    }
}