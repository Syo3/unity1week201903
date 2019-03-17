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
            case Common.Const.ObjectType.kHillBlockRight:
                prefab = _sceneManager.PrefabManager.HillBlockLeftObjectPrefab;
                break;
            case Common.Const.ObjectType.kFixedBlock:
                prefab = _sceneManager.PrefabManager.FixedBlockObjectPrefab;
                break;
            case Common.Const.ObjectType.kSpring:
                prefab = _sceneManager.PrefabManager.SpringObjectPrefab;
                break;
            case Common.Const.ObjectType.kFallBlock:
                prefab = _sceneManager.PrefabManager.FallBlockObjectPrefab;
                break;
            case Common.Const.ObjectType.kSpringLeft:
                prefab = _sceneManager.PrefabManager.SpringLeftObjectPrefab;
                break;
            case Common.Const.ObjectType.kSpringRight:
                prefab = _sceneManager.PrefabManager.SpringRightObjectPrefab;
                break;
            case Common.Const.ObjectType.kFixedHillBlockLeft:
                prefab = _sceneManager.PrefabManager.FixedHillBlockLeftObjectPrefab;
                break;
            case Common.Const.ObjectType.kFixedHillBlockRight:
                prefab = _sceneManager.PrefabManager.FixedHillBlockRightObjectPrefab;
                break;
            case Common.Const.ObjectType.kFixedFallBlock:
                prefab = _sceneManager.PrefabManager.FixedFallBlockObjectPrefab;
                break;
            }

            var editObject = Instantiate(prefab, Vector3.zero, prefab.transform.rotation, _sceneManager.WorldParent).GetComponent<EditObjectBase>();
            editObject.Init(_sceneManager.EditObjectManager);
            _sceneManager.EditObjectManager.Add(editObject);
        }
        #endregion
    }
}
