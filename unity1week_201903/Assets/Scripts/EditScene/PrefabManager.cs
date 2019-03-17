using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Edit{
    public class PrefabManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("プレイヤー")]
        private GameObject _playerObjectPrefab;
        [SerializeField, Tooltip("ゴール")]
        private GameObject _goalObjectPrefab;
        [SerializeField, Tooltip("ブロック")]
        private GameObject _blockObjectPrefab;
        [SerializeField, Tooltip("坂ブロック")]
        private GameObject _hillBlockObjectPrefab;
        [SerializeField, Tooltip("坂ブロック右")]
        private GameObject _hillBlockLeftObjectPrefab;
        [SerializeField, Tooltip("固定ブロック")]
        private GameObject _fixedBlockObjectPrefab;
        [SerializeField, Tooltip("スプリングブロック")]
        private GameObject _springObjectPrefab;
        [SerializeField, Tooltip("落下ブロック")]
        private GameObject _fallBlockObjectPrefab;
        [SerializeField, Tooltip("スプリング左")]
        private GameObject _springLeftObjectPrefab;
        [SerializeField, Tooltip("スプリング右")]
        private GameObject _springRightObjectPrefab;
        [SerializeField, Tooltip("固定坂ブロック左")]
        private GameObject _fixedHillBlockLeftObjectPrefab;
        [SerializeField, Tooltip("固定坂ブロック右")]
        private GameObject _fixedHillBlockRightObjectPrefab;
        [SerializeField, Tooltip("固定落下ブロック")]
        private GameObject _fixedFallBlockObjectPrefab;
        #endregion

        #region access
        public GameObject PlayerObjectPrefab{
            get{return _playerObjectPrefab;}
        }
        public GameObject GoalObjectPrefab{
            get{return _goalObjectPrefab;}
        }
        public GameObject BlockObjectPrefab{
            get{return _blockObjectPrefab;}
        }
        public GameObject HillBlockObjectPrefab{
            get{return _hillBlockObjectPrefab;}
        }
        public GameObject HillBlockLeftObjectPrefab{
            get{return _hillBlockLeftObjectPrefab;}
        }
        public GameObject FixedBlockObjectPrefab{
            get{return _fixedBlockObjectPrefab;}
        }
        public GameObject SpringObjectPrefab{
            get{return _springObjectPrefab;}
        }
        public GameObject FallBlockObjectPrefab{
            get{return _fallBlockObjectPrefab;}
        }
        public GameObject SpringLeftObjectPrefab{
            get{return _springLeftObjectPrefab;}
        }
        public GameObject SpringRightObjectPrefab{
            get{return _springRightObjectPrefab;}
        }
        public GameObject FixedHillBlockLeftObjectPrefab{
            get{return _fixedHillBlockLeftObjectPrefab;}
        }
        public GameObject FixedHillBlockRightObjectPrefab{
            get{return _fixedHillBlockRightObjectPrefab;}
        }
        public GameObject FixedFallBlockObjectPrefab{
            get{return _fixedFallBlockObjectPrefab;}
        }
        #endregion
    }
}
