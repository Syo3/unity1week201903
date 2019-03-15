using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    /// <summary>
    /// プレハブを動的に読み込む場合はここから
    /// </summary>
    public class PrefabManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("プレイヤープレハブ")]
        private GameObject _playerPrefab;
        [SerializeField, Tooltip("ゴールプレハブ")]
        private GameObject _goalPrefab;
        [SerializeField, Tooltip("ブロックプレハブ")]
        private GameObject _blockPrefab;
        [SerializeField, Tooltip("坂ブロック")]
        private GameObject _hillBlockPrefab;
        [SerializeField, Tooltip("坂ブロック右")]
        private GameObject _hillBlockRightPrefab;
        [SerializeField, Tooltip("スプリング")]
        private GameObject _springPrefab;

        #endregion

        #region access
        public GameObject PlayerPrefab{
            get{return _playerPrefab;}
        }
        public GameObject GoalPrefab{
            get{return _goalPrefab;}
        }
        public GameObject BlockPrefab{
            get{return _blockPrefab;}
        }
        public GameObject HillBlockPrefab{
            get{return _hillBlockPrefab;}
        }
        public GameObject HillBlockRightPrefab{
            get{return _hillBlockRightPrefab;}
        }
        public GameObject SpringPrefab{
            get{return _springPrefab;}
        }
        #endregion
    }
}