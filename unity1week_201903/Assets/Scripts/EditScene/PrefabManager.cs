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
        #endregion
    }
}
