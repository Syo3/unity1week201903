using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class MainSceneManager : MonoBehaviour {

        #region SeriazlizeField
        [SerializeField, Tooltip("プレハブ管理")]
        private PrefabManager _prefabManager;
        [SerializeField, Tooltip("サウンド管理")]
        private SoundManager _soundManager;
        [SerializeField, Tooltip("フェード管理")]
        private FadeManager _fadeManager;
        #endregion

        #region private field
        #endregion
        
        #region access
        public PrefabManager PrefabManager{
            get{return _prefabManager;}
        }
        public SoundManager SoundManager{
            get{return _soundManager;}
        }
        #endregion

        // Use this for initialization
        void Start () {
            StartCoroutine(_fadeManager.FadeIn());
        }
        
        // Update is called once per frame
        void Update () {
            
        }

        #region public function
        #endregion

        #region private function
        #endregion
    }
}