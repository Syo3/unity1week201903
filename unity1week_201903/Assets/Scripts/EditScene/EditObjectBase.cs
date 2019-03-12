using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Edit{
    public class EditObjectBase : MonoBehaviour, IDragHandler{

        #region SerializeField
        [SerializeField, Tooltip("オブジェクトタイプ")]
        protected Common.Const.ObjectType _objectType;
        #endregion

        #region private field
        protected int _posX;
        protected int _posY;
        private EditObjectManager _editObjectManager;
        #endregion

        #region access

        #endregion

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        public void Init(EditObjectManager editObjectManager)
        {
            _editObjectManager = editObjectManager;
            _posX = 2;
            _posY = 2;
            var position       = Vector3.zero;
            position.x         = _posX * Common.Const.BLOCK_SIZE + Common.Const.START_POS_X + Common.Const.BLOCK_SIZE_HALF;
            position.y         = _posY * Common.Const.BLOCK_SIZE + Common.Const.START_POS_Y + Common.Const.BLOCK_SIZE_HALF;
            transform.position = position;
        }

        /// <summary>
        /// ドラッグ
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            // マウスの位置に動かす
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _posX   = (int)((pos.x - Common.Const.START_POS_X) / Common.Const.BLOCK_SIZE);
            _posY   = (int)((pos.y - Common.Const.START_POS_Y) / Common.Const.BLOCK_SIZE);
            // 削除チェック
            if(DeleteCheck()){
                return;
            }
            pos.x   = (float)(int)((pos.x - Common.Const.START_POS_X) / Common.Const.BLOCK_SIZE) * Common.Const.BLOCK_SIZE + Common.Const.START_POS_X + Common.Const.BLOCK_SIZE_HALF;
            pos.y   = (float)(int)((pos.y - Common.Const.START_POS_Y) / Common.Const.BLOCK_SIZE) * Common.Const.BLOCK_SIZE + Common.Const.START_POS_Y + Common.Const.BLOCK_SIZE_HALF;
            pos.z   = 0;
            transform.position = pos;
        }

        /// <summary>
        /// データアウトプット用文字列作成
        /// </summary>
        /// <returns></returns>
        public string GetOutputText()
        {
            return "stageData.Add(new StageData(Common.Const.ObjectType."+_objectType.ToString()+", "+_posX+", "+_posY+"));\n";
        }
        #endregion

        #region private function
        private bool DeleteCheck()
        {
            if(_posX < 0 || _posY < 0 || _posX > Common.Const.NUM_WIDTH-1 || _posY > Common.Const.NUM_HEIGHT-1){

                Destroy(gameObject);
                return true;
            }
            return false;
        }
        #endregion
    }
}	