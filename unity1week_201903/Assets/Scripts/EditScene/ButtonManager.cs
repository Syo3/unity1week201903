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
        [SerializeField, Tooltip("坂ブロック左生成")]
        private Button _hillBlockRightCreateButton;
        [SerializeField, Tooltip("固定ブロック")]
        private Button _fixedBlockCreateButton;
        [SerializeField, Tooltip("スプリング生成ボタン")]
        private Button _springCreateButton;
        [SerializeField, Tooltip("落下ブロック生成ボタン")]
        private Button _fallBlockCreateButton;
        [SerializeField, Tooltip("スプリング左")]
        private Button _springLeftCreateButton;
        [SerializeField, Tooltip("スプリング右")]
        private Button _springRightCraeteButton;
        [SerializeField, Tooltip("固定坂ブロック左")]
        private Button _fixedHillBlockLeftCreateButton;
        [SerializeField, Tooltip("固定坂ブロック右")]
        private Button _fixedHillBlockRightCreateButton;
        [SerializeField, Tooltip("固定落下ブロック生成")]
        private Button _fixedFallBlockCreateButton;
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
            // 坂ブロック左
            _hillBlockRightCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kHillBlockRight);
            });
            // 固定ブロック
            _fixedBlockCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kFixedBlock);
            });
            // スプリング
            _springCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kSpring);
            });
            // 落下ブロック
            _fallBlockCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kFallBlock);
            });
            // スプリング左
            _springLeftCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kSpringLeft);
            });
            // スプリング右
            _springRightCraeteButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kSpringRight);
            });
            // 固定坂左
            _fixedHillBlockLeftCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kFixedHillBlockLeft);
            });
            // 固定坂右
            _fixedHillBlockRightCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kFixedHillBlockRight);
            });
            // 固定落下
            _fixedFallBlockCreateButton.onClick.AddListener(()=>{
                _sceneManager.CreateManager.Create(Common.Const.ObjectType.kFixedFallBlock);
            });
        }
        #endregion
    }
}
