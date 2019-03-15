﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene{
    public class BlockBase : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler{

        #region SerializeField
        [SerializeField, Tooltip("スプライト")]
        protected SpriteRenderer _sprite;
        [SerializeField, Tooltip("rigidbody")]
        protected Rigidbody2D _rigidBody;
        [SerializeField, Tooltip("Animator")]
        protected Animator _animator;
        #endregion
        // コライダー追加する


        #region private field
        protected Common.Const.ObjectType _objectType;
        protected StageManager _stageManager;
        protected bool _moveFlg;
        protected bool _fallFlg;
        #endregion

        #region access
        public bool FallFlg{
            get{return _fallFlg;}
        }
        public Common.Const.ObjectType GetObjectType{
            get{return _objectType;}
        }
        #endregion

        void Awake()
        {
            _objectType = Common.Const.ObjectType.kBlock;
        }

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="stageManager"></param>
        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _stageManager = stageManager;
            _moveFlg      = true;

            Invoke("AnimationPlay", animationTime);
        }

        private void AnimationPlay()
        {
            _animator.Play("BlockBasePop");
        }

        /// <summary>
        /// 落下開始
        /// </summary>
        public void SetFall()
        {
            _fallFlg            = true;
            _rigidBody.bodyType = RigidbodyType2D.Dynamic;
            _rigidBody.AddForce(new Vector2(Random.Range(-100.5f, 100.5f), 0.0f));
            StartCoroutine(FallCheckCoroutine());
        }

        /// <summary>
        /// 落下チェックコルーチン
        /// </summary>
        /// <returns></returns>
        protected IEnumerator FallCheckCoroutine()
        {
            while(_fallFlg){
                yield return null;
                FallCheck();
            }
        }
        #endregion

        #region 継承 function
        public void OnBeginDrag(PointerEventData eventData)
        {
            _sprite.sortingOrder = 2;
            _sprite.color        = new Color(0.8f, 0.8f, 0.8f, 1.0f);
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
            _sprite.color        = Color.white;

        }

        /// <summary>
        /// 衝突開始　トリガー
        /// </summary>
        /// <param name="other"></param>
        protected void OnTriggerEnter2D(Collider2D other)
        {
//            Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
        }

        /// <summary>
        /// 衝突開始　物体
        /// </summary>
        /// <param name="collision"></param>
        protected void OnCollisionEnter2D(Collision2D collision)
        {
            
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


        /// <summary>
        /// 落下チェック
        /// </summary>
        private void FallCheck()
        {
            if(transform.position.y < Common.Const.BLOCK_SIZE_HALF * -Common.Const.NUM_HEIGHT ||
            transform.position.x < Common.Const.BLOCK_SIZE_HALF * -Common.Const.NUM_WIDTH ||
            transform.position.x > Common.Const.BLOCK_SIZE_HALF * Common.Const.NUM_WIDTH){
                _fallFlg = false;
            }
        }

    }
}
