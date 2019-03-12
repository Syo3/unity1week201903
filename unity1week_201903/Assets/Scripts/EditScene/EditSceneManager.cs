using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Edit{
    public class EditSceneManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("プレハブ管理")]
        private PrefabManager _prefabManager;
        [SerializeField, Tooltip("作成管理")]
        private CreateManager _createManager;
        [SerializeField, Tooltip("配置オブジェクト管理")]
        private EditObjectManager _editObjectManager;
        [SerializeField, Tooltip("ボタン管理")]
        private ButtonManager _buttonManager;
        [SerializeField, Tooltip("エディタ画面ワールド親要素")]
        private Transform _worldParent;
        #endregion

        #region access
        public PrefabManager PrefabManager{
            get{return _prefabManager;}
        }
        public CreateManager CreateManager{
            get{return _createManager;}
        }
        public EditObjectManager EditObjectManager{
            get{return _editObjectManager;}
        }
        public Transform WorldParent{
            get{return _worldParent;}
        }
        #endregion

        void Start()
        {
            _createManager.Init(this);
            _editObjectManager.Init(this);
            _buttonManager.Init(this);
        }
    }
}