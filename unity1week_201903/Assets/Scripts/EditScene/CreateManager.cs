using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Edit{
    public class CreateManager : MonoBehaviour {

        #region private field
        private EditSceneManager _sceneManager;
        #endregion

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(EditSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }

        /// <summary>
        /// オブジェクト作成
        /// </summary>
        /// <param name="type"></param>
        public void Create(Common.Const.ObjectType type)
        {
            GameObject prefab = null;
            switch(type){
            case Common.Const.ObjectType.kPlayer:
                prefab = _sceneManager.PrefabManager.PlayerObjectPrefab;
                break;
            case Common.Const.ObjectType.kGoal:
                prefab = _sceneManager.PrefabManager.GoalObjectPrefab;
                break;
            case Common.Const.ObjectType.kBlock:
                prefab = _sceneManager.PrefabManager.BlockObjectPrefab;
                break;
            case Common.Const.ObjectType.kHillBlock:
                prefab = _sceneManager.PrefabManager.HillBlockObjectPrefab;
                break;
            }
            var editObject = Instantiate(prefab, Vector3.zero, Quaternion.identity, _sceneManager.WorldParent).GetComponent<EditObjectBase>();
            editObject.Init(_sceneManager.EditObjectManager);
            _sceneManager.EditObjectManager.Add(editObject);
        }
        #endregion
    }
}
