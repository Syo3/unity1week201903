using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Edit{
    public class EditObjectManager : MonoBehaviour {

        #region private field
        private EditSceneManager _sceneManager;
        private List<EditObjectBase> _editObjectList;
        #endregion

        #region public function
        /// <summary>
        /// 初期化
        /// </summary>
        public void Init(EditSceneManager sceneManager)
        {
            _sceneManager   = sceneManager;
            _editObjectList = new List<EditObjectBase>();
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="editObject"></param>
        public void Add(EditObjectBase editObject)
        {
            _editObjectList.Add(editObject);
        }

        /// <summary>
        /// 情報出力
        /// </summary>
        public void DataOutput()
        {
            var outputText = "";
            for(var i = 0; i < _editObjectList.Count; ++i){

                if(_editObjectList[i] == null){
                    continue;
                }
                outputText += _editObjectList[i].GetOutputText();
            }
            Debug.Log(outputText);
        }
        #endregion
    }
}
