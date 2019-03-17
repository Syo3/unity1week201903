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

        [SerializeField, Tooltip("固定ブロック")]
        private GameObject _fixedBlockPrefab;
        [SerializeField, Tooltip("落下ブロック")]
        private GameObject _fallBlockPrefab;
        [SerializeField, Tooltip("ばね左側")]
        private GameObject _springLeftPrefab;
        [SerializeField, Tooltip("ばね右側")]
        private GameObject _springRightPrefab;
        [SerializeField, Tooltip("固定坂ブロック左")]
        private GameObject _fixedHillBlockLeftPrefab;
        [SerializeField, Tooltip("固定坂ブロック右")]
        private GameObject _fixedHillBlockRightPrefab;
        [SerializeField, Tooltip("固定落下ブロック")]
        private GameObject _fixedFallBlockPrefab;
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
        public GameObject FixedBlockPrefab{
            get{return _fixedBlockPrefab;}
        }
        public GameObject FallBlockPrefab{
            get{return _fallBlockPrefab;}
        }
        public GameObject SpringLeftPrefab{
            get{return _springLeftPrefab;}
        }
        public GameObject SpringRightPrefab{
            get{return _springRightPrefab;}
        }
        public GameObject FixedHillBlockLeftPrefab{
            get{return _fixedHillBlockLeftPrefab;}
        }
        public GameObject FixedHillBlockRightPrefab{
            get{return _fixedHillBlockRightPrefab;}
        }
        public GameObject FixedFallBlockPrfab{
            get{return _fixedFallBlockPrefab;}
        }
        #endregion
    }
}