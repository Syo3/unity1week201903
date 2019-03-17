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
        [SerializeField, Tooltip("UI表示")]
        private DefaultView _defaultView;
        [SerializeField, Tooltip("ポーズ画面")]
        private PauseView _pauseView;
        [SerializeField, Tooltip("チュートらる")]
        private TutorialView _tutorialView;

        [SerializeField, Tooltip("デフォルトステージID デバッグ用")]
        private int _stageID;
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
        public DefaultView DefaultView{
            get{return _defaultView;}
        }
        public PauseView PauseView{
            get{return _pauseView;}
        }
        public TutorialView TutorialView{
            get{return _tutorialView;}
        }
        #endregion

        // Use this for initialization
        void Start ()
        {
            // ステージ作成
            _stageManager.StageID = _stageID;
            _stageManager.Init(this);
            _clearView.Init(this);
            _retryView.Init(this);
            _gameClearView.Init(this);
            _defaultView.Init(this);
            _pauseView.Init(this);
            _stageManager.PlayerInit();
            // フェードイン
            //_fadeManager.SetCallBack(()=>{
            //});
            StartCoroutine(_fadeManager.FadeIn());
        }
        
        #region public function
        #endregion

        #region private function
        #endregion
    }
}