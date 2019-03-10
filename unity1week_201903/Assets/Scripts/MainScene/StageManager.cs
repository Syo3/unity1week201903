using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class StageManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("文字")]
        private TMPro.TextMeshProUGUI _goalText;
        #endregion

        #region private field
        private MainSceneManager _mainSceneManager;
        private int _stageID;
        #endregion

        public void Init(MainSceneManager sceneManager)
        {
            _mainSceneManager = sceneManager;
            _stageID          = 0;
            _goalText.enabled = false;

            Reset();
        }

        public void ShowGoalMessage()
        {
            _goalText.enabled = true;
        }


        private void Reset()
        {

        }

    }
}