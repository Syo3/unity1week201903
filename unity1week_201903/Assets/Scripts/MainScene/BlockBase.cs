using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene{
    public class BlockBase : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler{

        [SerializeField, Tooltip("スプライト")]
        protected SpriteRenderer _sprite;
        // コライダー追加する


        #region private field
        protected StageManager _stageManager;
        protected bool _moveFlg;
        #endregion

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="stageManager"></param>
        public void Init(StageManager stageManager)
        {
            _stageManager = stageManager;
            _moveFlg      = true;
        }
        #endregion

        #region 継承 function
        public void OnBeginDrag(PointerEventData eventData)
        {
            _sprite.sortingOrder = 2;
        }

        /// <summary>
        /// ドラッグ
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            if(!_moveFlg){
                return;
            }
            // マウスの位置に動かす
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log((int)((pos.x - Common.Const.START_POS_X) / Common.Const.BLOCK_SIZE));
            Debug.Log((int)((pos.x) / Common.Const.BLOCK_SIZE));
            pos.x   = (float)(int)((pos.x - Common.Const.START_POS_X) / Common.Const.BLOCK_SIZE) * Common.Const.BLOCK_SIZE + Common.Const.START_POS_X + Common.Const.BLOCK_SIZE_HALF;
//            pos.x   = (float)(int)((pos.x + Common.Const.BLOCK_SIZE_HALF) / Common.Const.BLOCK_SIZE) * Common.Const.BLOCK_SIZE - Common.Const.BLOCK_SIZE_HALF;
//            pos.y   = (float)(int)((pos.y - Common.Const.BLOCK_SIZE_HALF) / Common.Const.BLOCK_SIZE) * Common.Const.BLOCK_SIZE + Common.Const.BLOCK_SIZE_HALF;
            pos.y   = (float)(int)((pos.y - Common.Const.START_POS_Y) / Common.Const.BLOCK_SIZE) * Common.Const.BLOCK_SIZE + Common.Const.START_POS_Y + Common.Const.BLOCK_SIZE_HALF;
            pos.z   = 0;
            transform.position = pos;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _sprite.sortingOrder = 1;
        }

        /// <summary>
        /// 衝突開始　トリガー
        /// </summary>
        /// <param name="other"></param>
        protected void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
        }

        /// <summary>
        /// 衝突開始　物体
        /// </summary>
        /// <param name="collision"></param>
        protected void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("OnCollisionEnter2D: " + collision.gameObject.name);
            Debug.Log(_sprite.size.y);
            
        }

        /// <summary>
        /// 衝突中　物体
        /// </summary>
        /// <param name="collision"></param>
        protected void OnCollisionStay2D(Collision2D collision)
        {
            // 移動可能か判定
            _moveFlg = collision.transform.position.y > transform.position.y + _sprite.size.y / 2.0f ? false : true;
        }

        /// <summary>
        /// 衝突終了 物体
        /// </summary>
        /// <param name="collision"></param>
        protected void OnCollisionExit2D(Collision2D collision)
        {
            _moveFlg = true;
        }
        #endregion

    }
}
