using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class Goal : BlockBase {


        public void Init(StageManager stageManager)
        {
            base.Init(stageManager);
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Clear");
            var stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
            stageManager.ShowGoalMessage();
            //_stageManager.ShowGoalMessage();
        }

    }
}