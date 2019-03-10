using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleScene{
    public class TitleSceneManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("フェード管理")]
        private FadeManager _fadeManager;
        #endregion

        // Use this for initialization
        void Start ()
        {
            StartCoroutine(_fadeManager.FadeIn());
        }
        
        // Update is called once per frame
        void Update ()
        {
            
        }
    }
}