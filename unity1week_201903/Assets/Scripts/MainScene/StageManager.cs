using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class StageManager : MonoBehaviour {

        #region SerializeField
        #endregion

        #region private field
        private MainSceneManager _mainSceneManager;
        private int _stageID;
        private List<List<int>> _stageMapList;
        private List<Player> _playerList;
        private List<BlockBase> _blockList;
        private List<StageData> _stageData;
        private int _targetGoalCnt;
        private int _goalCnt;
        private bool _clearFlg;
        private bool _failedFlg;
        #endregion

        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(MainSceneManager sceneManager)
        {
            _mainSceneManager = sceneManager;
            _stageID          = 1;
            _stageMapList     = new List<List<int>>();
            for(var i = 0; i < Common.Const.NUM_HEIGHT; ++i){

                _stageMapList.Add(new List<int>());
                for(var j = 0; j < Common.Const.NUM_WIDTH; ++j){
                    _stageMapList[i].Add(0);
                }
            }
            Reset();
        }

        void Update()
        {
            if(_clearFlg || _playerList == null){
                return;
            }
            // 落下チェック
            CheckPlayerFall();
        }

        /// <summary>
        /// クリア表示
        /// </summary>
        public void StageClear()
        {
            ++_stageID;
            _mainSceneManager.ClearView.Show(true);            
            Invoke("ObjectFall", 1.0f);
        }



        /// <summary>
        /// ゴールカウントアップ
        /// </summary>
        public void AddGoalCnt()
        {
            ++_goalCnt;
            if(_targetGoalCnt <= _goalCnt){
                _clearFlg = true;
                StageClear();
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Reset()
        {
            DataDelete();
            _clearFlg     = false;
            _failedFlg    = false;
            _goalCnt      = 0;
            _playerList   = new List<Player>();
            _blockList    = new List<BlockBase>();
            for(var i = 0; i < Common.Const.NUM_HEIGHT; ++i){
                for(var j = 0; j < Common.Const.NUM_WIDTH; ++j){
                    _stageMapList[i][j] = 0;
                }
            }
            LoadStage();            
        }

        /// <summary>
        /// プレイヤーは移動するので個別で初期化
        /// </summary>
        public void PlayerInit()
        {
            Debug.Log(_playerList.Count);
            for(var i = 0; i < _playerList.Count; ++i){
                _playerList[i].Init();
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        private void DataDelete()
        {
            if(_playerList == null){
                return;
            }
            for(var i = 0; i < _playerList.Count; ++i){
                Destroy(_playerList[i].gameObject);
            }
            for(var i = 0; i < _blockList.Count; ++i){
                Destroy(_blockList[i].gameObject);
            }
        }

        /// <summary>
        /// ステージ読み込み
        /// </summary>
        private void LoadStage()
        {
            _targetGoalCnt = StageDataManaer.GetStageGoalCnt(_stageID);
            _stageData     = StageDataManaer.GetStageData(_stageID);
            var blockCnt   = 0;
            for(var i = 0; i < _stageData.Count; ++i){

                Debug.Log(_stageData[i]._type);
                switch(_stageData[i]._type){
                // プレイヤー
                case Common.Const.ObjectType.kPlayer:
                    var player                     = Instantiate(_mainSceneManager.PrefabManager.PlayerPrefab, Vector3.zero, Quaternion.identity, _mainSceneManager.WorldParent).GetComponent<Player>();
                    player.transform.localPosition = GetObjectInitPosition(_stageData[i]._posX, _stageData[i]._posY);
                    _playerList.Add(player);
                    break;
                // ゴール
                case Common.Const.ObjectType.kGoal:
                    var goal                     = Instantiate(_mainSceneManager.PrefabManager.GoalPrefab, Vector3.zero, Quaternion.identity, _mainSceneManager.WorldParent).GetComponent<Goal>();
                    goal.transform.localPosition = GetObjectInitPosition(_stageData[i]._posX, _stageData[i]._posY);
                    goal.Init(this, 0.1f * blockCnt);
                    _blockList.Add(goal);
                    ++blockCnt;
                    break;
                // ブロック
                case Common.Const.ObjectType.kBlock:
                    var block                     = Instantiate(_mainSceneManager.PrefabManager.BlockPrefab, Vector3.zero, Quaternion.identity, _mainSceneManager.WorldParent).GetComponent<BlockBase>();
                    block.transform.localPosition = GetObjectInitPosition(_stageData[i]._posX, _stageData[i]._posY);
                    block.Init(this, 0.1f * blockCnt);
                    _blockList.Add(block);
                    ++blockCnt;
                    break;
                // 坂ブロック
                case Common.Const.ObjectType.kHillBlock:
                    var hillBlock                     = Instantiate(_mainSceneManager.PrefabManager.HillBlockPrefab, Vector3.zero, Quaternion.identity, _mainSceneManager.WorldParent).GetComponent<HillBlock>();
                    hillBlock.transform.localPosition = GetObjectInitPosition(_stageData[i]._posX, _stageData[i]._posY);
                    hillBlock.Init(this, 0.1f * blockCnt);
                    _blockList.Add(hillBlock);
                    ++blockCnt;
                    break;
                // 坂ブロック　右
                case Common.Const.ObjectType.kHillBlockRight:
                    var hillBlockRight                     = Instantiate(_mainSceneManager.PrefabManager.HillBlockRightPrefab, Vector3.zero, Quaternion.identity, _mainSceneManager.WorldParent).GetComponent<HillBlock>();
                    hillBlockRight.transform.localPosition = GetObjectInitPosition(_stageData[i]._posX, _stageData[i]._posY);
                    hillBlockRight.Init(this, 0.1f * blockCnt);
                    _blockList.Add(hillBlockRight);
                    ++blockCnt;
                    break;
                // スプリング
                case Common.Const.ObjectType.kSpring:
                    var spring                     = Instantiate(_mainSceneManager.PrefabManager.SpringPrefab, Vector3.zero, Quaternion.identity, _mainSceneManager.WorldParent).GetComponent<Spring>();
                    spring.transform.localPosition = GetObjectInitPosition(_stageData[i]._posX, _stageData[i]._posY);
                    spring.Init(this, 0.1f * blockCnt);
                    _blockList.Add(spring);
                    ++blockCnt;
                    break;

                
                }
                _stageMapList[_stageData[i]._posY][_stageData[i]._posX] = (int)_stageData[i]._type;
            }
        }

        /// <summary>
        /// プレハブの初期座標取得
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <returns></returns>
        private Vector3 GetObjectInitPosition(int posX, int posY)
        {
            return new Vector3(Common.Const.BLOCK_SIZE * posX + Common.Const.BLOCK_SIZE_HALF + Common.Const.START_POS_X, Common.Const.BLOCK_SIZE * posY + Common.Const.BLOCK_SIZE_HALF + Common.Const.START_POS_Y, 0.0f);
        }

        /// <summary>
        /// 全てのプレイヤーが落ちたかチェック
        /// </summary>
        private void CheckPlayerFall()
        {
            if(_failedFlg){
                return;
            }
            for(var i = 0; i < _playerList.Count; ++i){
                
                if(!_playerList[i].FallFlg){
                    return;
                }
            }
            //_mainSceneManager.RetryView.Show(true);
            // フェード
            _mainSceneManager.FadeManager.SetCallBack(()=>{
                // ステージ初期化
                _mainSceneManager.StageManager.Reset();
                _mainSceneManager.FadeManager.SetCallBack(()=>{
                    _mainSceneManager.StageManager.PlayerInit();
                });
                StartCoroutine(_mainSceneManager.FadeManager.FadeIn());
            });
            StartCoroutine(_mainSceneManager.FadeManager.FadeOut());


            _failedFlg = true;
        }

        private void ObjectFall()
        {
            for(var i = 0; i < _blockList.Count; ++i){
                _blockList[i].SetFall();
            }
            StartCoroutine(FallCheckCoroutine());
        }

        private IEnumerator FallCheckCoroutine()
        {
            var fallFlg = true;
            while(fallFlg){

                yield return null;
                fallFlg = false;
                for(var i = 0; i < _blockList.Count; ++i){

                    if(_blockList[i].FallFlg == true){
                        fallFlg = true;
                        break;
                    }
                }
            }
            Reset();
            PlayerInit();
            _mainSceneManager.ClearView.Show(false);
        }
    }
}