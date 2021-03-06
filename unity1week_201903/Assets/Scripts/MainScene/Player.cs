﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainScene{
    public class Player : MonoBehaviour, IPointerDownHandler {

        #region const
        public enum State{
            kBallon,
            kMove,
            kRolling,
            kGetUp,
            kStartFall,
        }
        private readonly float kCheckTime = 1.0f;
        private readonly float kRotateSpeed = 180.0f;
        private readonly float kRollingStartRot = 20.0f;
        #endregion


        #region SerializeField
        [SerializeField, Tooltip("スプライト")]
        private SpriteRenderer _sprite;
        [SerializeField, Tooltip("アニメーター")]
        private Animator _animator;
        [SerializeField, Tooltip("四角コライダー")]
        private BoxCollider2D _boxCollider2D;
        [SerializeField, Tooltip("円コライダー")]
        private CircleCollider2D _circleCollider2D;
        [SerializeField, Tooltip("rigidBody")]
        private Rigidbody2D _rigidBody;
        [SerializeField, Tooltip("風船のアニメーター")]
        private Animator _ballonAnimator;
        [SerializeField, Tooltip("風船コライダー")]
        private BoxCollider2D _ballonColider;
        #endregion

        #region private field
        private StageManager _stageManager;
        private bool _updateFlg;
        private bool _fallFlg;
        private bool _timeUpdateFlg;
        private bool _ballonInitFlg;
        private Vector3 _framePosition;
        private Transform _transform;
        private State _state;
        private float _time;
        private Vector3 _defaultPosition;
        private float _moveVecRate;
    	public Vector2 _velocity;
    	public float _angularVelocity;
        #endregion

        #region access
        public bool FallFlg{
            get{return _fallFlg;}
        }
        #endregion


        void Start()
        {
            _time          = 0;
            _state         = State.kBallon;
            _transform     = transform;
            _ballonInitFlg = false;
            _defaultPosition = _transform.localPosition;
            _transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
            _fallFlg       = false;
            _timeUpdateFlg = false;
            _framePosition = _transform.localPosition;
            _moveVecRate   = 1.0f;
        }


        public void Init(StageManager stageManager)
        {
            _stageManager = stageManager;
        }

        // Update is called once per frame
        void Update()
        {
            // 落下チェック
            FallCheck();

            if(_updateFlg != true){
                if(_transform == null){
                    return;
                }
                if(_state == State.kBallon){
                    if(_ballonInitFlg == false){
                        if(Vector3.Distance(_transform.localPosition, _defaultPosition) < 0.2f){
                            _transform.localPosition = _defaultPosition;
                            _ballonInitFlg = true;
                        }
                        _transform.localPosition = Vector3.Lerp(_transform.localPosition, _defaultPosition, 0.1f);
                    }
                    else{
                        _transform.localPosition = new Vector3(_transform.localPosition.x, _defaultPosition.y + Mathf.Sin (180 * Time.time * Mathf.Deg2Rad) * 0.1f, transform.localPosition.z);
                    }
                }
                return;
            }
            TimeCheck();
            // 状態ごとの処理
            switch(_state){
            case State.kBallon:
                break;
            case State.kMove:
                Move();
                RollingCheck();
                break;
            case State.kRolling:
                Rolling();
                break;
            case State.kGetUp:
                GetUp();
                break;
            }
        }

        /// <summary>
        /// ポーズ管理
        /// </summary>
        /// <param name="flg"></param>
        public void Pause(bool flg)
        {
            if(flg){
                _angularVelocity    = _rigidBody.angularVelocity;
                _velocity           = _rigidBody.velocity;
                _rigidBody.bodyType = RigidbodyType2D.Kinematic;
                this.enabled        = false;
            }
            else{
                this.enabled               = true;
                _rigidBody.bodyType        = RigidbodyType2D.Dynamic;
                _rigidBody.angularVelocity = _angularVelocity;
                _rigidBody.velocity        = _velocity;
            }
        }

        public void BallonDestroy()
        {
            Destroy(_ballonAnimator.gameObject);
        }

        /// <summary>
        /// 衝突開始　トリガー
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {

            // Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
            // if(other.GetComponent<HillBlock>() != null){
            //     _boxCollider2D.enabled    = false;
            //     _circleCollider2D.enabled = true;
            // }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("collision");
            switch(_state){
            // case State.kBallon:                
            //     break;
            // case State.kStartFall:
            //     _state                 = State.kMove;
            //     _transform.eulerAngles = Vector3.zero;
            //     _updateFlg     = true;
            //     _animator.Play("Move");
            //     break;
            case State.kMove:
                var block = collision.gameObject.GetComponent<BlockBase>();
                switch(block.GetObjectType){
                case Common.Const.ObjectType.kSpring:
                    _rigidBody.AddForce(new Vector2(0.0f, 500.0f));
                    break;
                case Common.Const.ObjectType.kSpringLeft:
                    _rigidBody.AddForce(new Vector2(200.0f, 400.0f));
                    break;
                case Common.Const.ObjectType.kSpringRight:
                    _rigidBody.AddForce(new Vector2(-200.0f, 400.0f));
                    break;
                }
                // 真横判定
                if(collision.transform.position.y > _transform.position.y - Common.Const.BLOCK_SIZE_HALF){
                    Debug.Log("collision horizontal");
                    if(_moveVecRate > 0.0f){
                        Debug.Log(collision.transform.position.x);
                        Debug.Log(_transform.position.x);
                        if(collision.transform.position.x > _transform.position.x){
                            _moveVecRate *= -1.0f;
                            var rot = _transform.eulerAngles;
                            rot.y   = 180.0f;
                            _transform.eulerAngles = rot;
                        }
                    }
                    else{
                        if(collision.transform.position.x < _transform.position.x){
                            _moveVecRate *= -1.0f;
                            var rot = _transform.eulerAngles;
                            rot.y   = 0.0f;
                            _transform.eulerAngles = rot;
                        }                        
                    }
                }

                break;
            case State.kRolling:
            case State.kGetUp:
                var checkBlock = collision.gameObject.GetComponent<BlockBase>();
                switch(checkBlock.GetObjectType){
                case Common.Const.ObjectType.kSpring:
                    _rigidBody.AddForce(new Vector2(0.0f, 500.0f));
                    break;
                case Common.Const.ObjectType.kSpringLeft:
                    _rigidBody.AddForce(new Vector2(200.0f, 400.0f));
                    break;
                case Common.Const.ObjectType.kSpringRight:
                    _rigidBody.AddForce(new Vector2(-200.0f, 400.0f));
                    break;
                }
                break;
            }


            // Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
            // if(other.GetComponent<HillBlock>() != null){
            //     _boxCollider2D.enabled    = false;
            //     _circleCollider2D.enabled = true;
            // }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
           switch(_state){
            case State.kBallon:                
                break;
            case State.kStartFall:
                _state                 = State.kMove;
                _transform.eulerAngles = Vector3.zero;
                _updateFlg     = true;
                _animator.Play("Move");
                break;
           }
        }



        public void OnPointerDown(PointerEventData eventData)
        {
            switch(_state){
            case State.kBallon:
                _state                 = State.kStartFall;
                _rigidBody.bodyType    = RigidbodyType2D.Dynamic;
                _ballonColider.enabled = false;
                _ballonAnimator.Play("BallonDestroy");
                _ballonAnimator.transform.parent = _transform.parent;
                Invoke("BallonDestroy", 5.0f);
                Debug.Log(_stageManager);
                Debug.Log(_stageManager.SceneManager);
                Debug.Log(_stageManager.SceneManager.TutorialView);
                if(_stageManager.SceneManager.TutorialView != null){
                    _stageManager.SceneManager.TutorialView.EndTutorial();
                }
                break;
            }
        }

        /// <summary>
        /// 落下チェック
        /// </summary>
        private void FallCheck()
        {
            if(_transform.position.y < Common.Const.BLOCK_SIZE_HALF * -Common.Const.NUM_HEIGHT ||
            _transform.position.x < Common.Const.BLOCK_SIZE_HALF * -Common.Const.NUM_WIDTH ||
            _transform.position.x > Common.Const.BLOCK_SIZE_HALF * Common.Const.NUM_WIDTH){
                _fallFlg = true;
            }
        }

        /// <summary>
        /// 秒計測
        /// </summary>
        private void TimeCheck()
        {
            _timeUpdateFlg = false;
            _time         += Time.deltaTime;
            if(_time > kCheckTime){
                _time          = _time - kCheckTime;
                _timeUpdateFlg = true;
            }
        }

        private void RollingCheck()
        {
            var checkAngle = Mathf.Abs(_transform.eulerAngles.z) % 360;
            if(checkAngle > kRollingStartRot && checkAngle < 360.0f-kRollingStartRot){
                Debug.Log(_transform.eulerAngles.z);
                _boxCollider2D.enabled    = false;
                _circleCollider2D.enabled = true;
                _state                    = State.kRolling;
                _animator.Play("Rolling");
            }
        }

        private void Move()
        {
            _framePosition = _transform.localPosition;
            // 移動
            var pos                  = _transform.localPosition;
            pos.x                   += Common.Const.MOVE_SPEED * _moveVecRate * Time.deltaTime;
            _transform.localPosition = pos;

        }

        private void Rolling()
        {
            // 停止判定
            if(_timeUpdateFlg){
                Debug.Log(Vector3.Distance(_framePosition, _transform.localPosition));
                if(Vector3.Distance(_framePosition, _transform.localPosition) < 0.1f){
                    _state = State.kGetUp;
                }
                _framePosition = _transform.localPosition;
            }
        }

        /// <summary>
        /// 起き上がり
        /// </summary>
        private void GetUp()
        {
            // 終了チェック
            if(System.Math.Abs(_transform.eulerAngles.z % 360) < 10.0f){
                _transform.eulerAngles    = Vector3.zero;
                _boxCollider2D.enabled    = true;
                _circleCollider2D.enabled = false;
                _animator.Play("Move");
                _state                    = State.kMove;
                return;
            }

            _transform.Rotate(0.0f, 0.0f, -kRotateSpeed * Time.deltaTime);
            // 移動
            var pos                  = _transform.localPosition;
            pos.x                   += Common.Const.MOVE_SPEED * Time.deltaTime;
            _transform.localPosition = pos;
        }
    }
}