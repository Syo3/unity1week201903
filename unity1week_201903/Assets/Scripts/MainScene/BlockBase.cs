using System.Collections;
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
        protected bool _fixedFlg;
        protected bool _fallFlg;
        protected int  _posX;
        protected int  _posY;
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
            _moveFlg    = true;
            _fixedFlg   = false;
        }

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="stageManager"></param>
        public void Init(StageManager stageManager, float animationTime=0.0f)
        {
            _stageManager = stageManager;
            var pos       = transform.localPosition;
            _posX         = (int)((pos.x - Common.Const.START_POS_X) / Common.Const.BLOCK_SIZE);
            _posY         = (int)((pos.y - Common.Const.START_POS_Y) / Common.Const.BLOCK_SIZE);
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
            if(!_moveFlg || _fixedFlg){
                StartCoroutine(MoveFalseAnimation());
                return;
            }
            _sprite.sortingOrder = 2;
            _sprite.color        = new Color(0.8f, 0.8f, 0.8f, 1.0f);
        }

        /// <summary>
        /// ドラッグ
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            if(!_moveFlg || _fixedFlg){
                return;
            }
            // マウスの位置に動かす
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z   = 0;
            var x   = (int)((pos.x - Common.Const.START_POS_X) / Common.Const.BLOCK_SIZE);
            var y   = (int)((pos.y - Common.Const.START_POS_Y) / Common.Const.BLOCK_SIZE);
            pos.x   = (float)x * Common.Const.BLOCK_SIZE + Common.Const.START_POS_X + Common.Const.BLOCK_SIZE_HALF;
            pos.y   = (float)y * Common.Const.BLOCK_SIZE + Common.Const.START_POS_Y + Common.Const.BLOCK_SIZE_HALF;
            // そこに置けるか確認する処理
            Debug.Log((_posX != x || _posY != y)+"_"+_posX+"="+x+"_"+_posY+"="+y);
            if((_posX != x || _posY != y) && !_stageManager.CheckStageMap(x, y)){
                _sprite.color = new Color(1.0f, 0.8f, 0.8f, 1.0f);
            }
            else{
                _sprite.color = new Color(0.8f, 0.8f, 0.8f, 1.0f);
            }
            transform.position = pos;
        }

        /// <summary>
        /// ドラッグ終了
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            if(!_moveFlg || _fixedFlg){
                return;
            }
            _sprite.sortingOrder = 1;
            _sprite.color        = Color.white;
            // そこに置けるか確認する処理
            var pos      = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var x        = (int)((pos.x - Common.Const.START_POS_X) / Common.Const.BLOCK_SIZE);
            var y        = (int)((pos.y - Common.Const.START_POS_Y) / Common.Const.BLOCK_SIZE);
            var position = Vector3.zero;
            if(_stageManager.CheckStageMap(x, y)){
                _stageManager.SetStageMap(_posX, _posY, x, y);
                _posX = x;
                _posY = y;               
            }
            position                = new Vector3((float)_posX * Common.Const.BLOCK_SIZE + Common.Const.START_POS_X + Common.Const.BLOCK_SIZE_HALF, (float)_posY * Common.Const.BLOCK_SIZE + Common.Const.START_POS_Y + Common.Const.BLOCK_SIZE_HALF, 0.0f);
            transform.localPosition = position;
            _stageManager.SceneManager.SoundManager.PlayOnShot(0);
//            _stageManager.SceneManager.TutorialView.EndTutorial();
            _stageManager.SceneManager.TutorialView.ShowDragTutorial();

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
            // 移動可能か判定 上方向にプレイヤーがイルカ
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

        /// <summary>
        /// 持てなかった場合の処理
        /// </summary>
        /// <returns></returns>
        private IEnumerator MoveFalseAnimation()
        {
            _stageManager.SceneManager.SoundManager.PlayOnShot(3);
            var basePosition = transform.localPosition;
            var yRate        = 1.0f;
            if(!_fixedFlg){
                yRate = 0.0f;
            }

            Debug.Log(basePosition);
            for(var i = 0; i < 5; ++i){

                transform.localPosition = basePosition + new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f) * yRate, 0.0f);
                yield return null;
            }
            var pos = Vector3.zero;
            pos.x   = (float)_posX * Common.Const.BLOCK_SIZE + Common.Const.START_POS_X + Common.Const.BLOCK_SIZE_HALF;
            pos.y   = (float)_posY * Common.Const.BLOCK_SIZE + Common.Const.START_POS_Y + Common.Const.BLOCK_SIZE_HALF;
            transform.localPosition = pos;
            Debug.Log(basePosition);

        }
    }
}
