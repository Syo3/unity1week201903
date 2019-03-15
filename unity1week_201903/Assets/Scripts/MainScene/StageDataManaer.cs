using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public static class StageDataManaer{

        #region public function
        /// <summary>
        /// ステージデータ取得 WebGLで時間がないから仕方ない...
        /// </summary>
        /// <param name="stageID"></param>
        /// <returns></returns>
        public static List<StageData> GetStageData(int stageID)
        {
            var stageData = new List<StageData>();
            switch(stageID){
            case 1:
                // stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 3, 3));
                // stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 5, 3));
                // stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 3, 2));
                // stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 4, 2));
                // stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 5, 2));

                // stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 2, 4));
                // stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 2, 3));
                // stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 3, 3));
                // stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 5, 3));
                // stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 5, 4));

                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 2, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 6, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 2, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 3, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 4, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 6, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kSpring, 6, 1));


                break;
            case 2:
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 2, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 3, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 6, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 6, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 6, 0));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 4, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 0, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 0, 4));
                break;
            }
            return stageData;
        }

        public static int GetStageGoalCnt(int stageID)
        {
            var goalCnt = 0;
            switch(stageID){
            default:
                goalCnt = 1;
                break;
            }
            return goalCnt;
        }
        #endregion
    }
}