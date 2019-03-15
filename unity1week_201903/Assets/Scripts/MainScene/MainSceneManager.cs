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
        [SerializeField, Tooltip("ステージ管理")]
        private StageManager _stageManager;
        [SerializeField, Tooltip("ゲーム親要素")]
        private Transform _worldParent;
        [SerializeField, Tooltip("クリア表示")]
        private ClearView _clearView;
        [SerializeField, Tooltip("リトライ表示")]
        private RetryView _retryView;
        [SerializeField, Tooltip("クリア表示")]
        private GameClearView _gameClearView;
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
        public StageManager StageManager{
            get{return _stageManager;}
        }
        public FadeManager FadeManager{
            get{return _fadeManager;}
        }
        public Transform WorldParent{
            get{return _worldParent;}
        }
        public ClearView ClearView{
            get{return _clearView;}
        }
        public RetryView RetryView{
            get{return _retryView;}
        }
        public GameClearView GameClearView{
            get{return _gameClearView;}
        }
        #endregion

        // Use this for initialization
        void Start ()
        {
            // ステージ作成
            _stageManager.Init(this);
            _clearView.Init(this);
            _retryView.Init(this);
            _gameClearView.Init(this);
            _stageManager.PlayerInit();
            // フェードイン
            _fadeManager.SetCallBack(()=>{
            });
            StartCoroutine(_fadeManager.FadeIn());
        }
        
        // Update is called once per frame
        void Update ()
        {
            
        }

        #region public function
        #endregion

        #region private function
        #endregion
    }
}