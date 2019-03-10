using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene{
    public class BlockBase : MonoBehaviour, IDragHandler{

        [SerializeField, Tooltip("スプライト")]
        protected SpriteRenderer _sprite;
        // コライダー追加する


        #region private field
        protected StageManager _stageManager;
        #endregion

        #region public function
        public void Init(StageManager stageManager)
        {
            _stageManager = stageManager;
        }
        #endregion

        #region 継承 function
            // ドラッグ
        public void OnDrag(PointerEventData eventData)
        {
            // マウスの位置に動かす
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            Debug.Log(pos.x);
            Debug.Log(Common.Const.BLOCK_SIZE);

            pos.x = (float)(int)((pos.x + Common.Const.BLOCK_SIZE_HALF) / Common.Const.BLOCK_SIZE) * Common.Const.BLOCK_SIZE;
            pos.y = (float)(int)((pos.y - Common.Const.BLOCK_SIZE_HALF) / Common.Const.BLOCK_SIZE) * Common.Const.BLOCK_SIZE;
            Debug.Log(pos.x);
            Debug.Log((int)(pos.x / Common.Const.BLOCK_SIZE));
            
            transform.position = pos;
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("OnCollisionEnter2D: " + collision.gameObject.name);
        }

        #endregion

    }
}
