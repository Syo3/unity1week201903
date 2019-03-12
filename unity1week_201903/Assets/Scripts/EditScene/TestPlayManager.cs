using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Edit{
    public class TestPlayManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("プレイヤープレハブ")]
        private GameObject _playerPrefab;
        [SerializeField, Tooltip("ゴールプレハブ")]
        private GameObject _goalPrefab;
        [SerializeField, Tooltip("ブロックプレハブ")]
        private GameObject _blockPrefab;
        #endregion

        #region private field
        private EditSceneManager _sceneManager;
        #endregion

        #region public function
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(EditSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }
        #endregion
    }
}