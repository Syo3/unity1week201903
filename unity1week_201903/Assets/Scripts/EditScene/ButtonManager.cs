using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Edit{
    public class ButtonManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("開始ボタン")]
        private Button _playButton;
        [SerializeField, Tooltip("データ出力ボタン")]
        private Button _dataOutputButton;
        [SerializeField, Tooltip("プレイヤー作成ボタン")]
        private Button _playerCreateButton;
        [SerializeField, Tooltip("ゴール作成ボタン")]
        private Button _goalCreateButton;
        [SerializeField, Tooltip("ブロック作成ボタン")]
        private Button _blockCreateButton;
        [SerializeField, Tooltip("坂ブロック作成ボタン")]
        private Button _hillBlockCreateButton;
        #endregion

        #region private field
        private EditSceneManager _sceneManager;
        #endregion

        #region public function
        public void Init(EditSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            // 開始ボタン
            // _playButton.onClick.AddListener(()=>{
            //     Debug.Log("test");
            // });
            // データ出力
            _dataOutputButton.onClick.AddListener(()=>{
                _sceneManager.EditObjectManager.DataOutput();
            });
            // プレイヤー作成ボタン
            _playerCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kPlayer);
            });
            // ゴール作成ボタン
            _goalCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kGoal);
            });
            // ブロック作成ボタン
            _blockCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kBlock);
            });
            // 坂ブロック作成ボタン
            _hillBlockCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kHillBlock);
            });
        }
        #endregion
    }
}
