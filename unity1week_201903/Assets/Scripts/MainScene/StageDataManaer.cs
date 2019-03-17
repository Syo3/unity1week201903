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



                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 3, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 5, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 4, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 2));

                break;
            case 2:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 3, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 6, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 4, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 7, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 6, 2));


                // stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 2, 5));
                // stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 3, 3));
                // stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 6, 2));
                // stageData.Add(new StageData(Common.Const.ObjectType.kHillBlockRight, 7, 2));
                // stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 6, 1));
                // stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 6, 0));
                // stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 4, 4));
                // stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 0, 3));
                // stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 0, 4));
                break;
            case 3:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 2, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 6, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 2, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 5, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 6, 2));
                break;

            case 4:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 1, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 4, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 1, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 4, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 3, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 3, 1));
                break;

            case 5:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 0, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 6, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 0, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 6, 0));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 3, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 3, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 4, 4));
                break;

            case 6:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 1, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 6, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 1, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 2, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 4, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 6, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 6, 0));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 5, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 6, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 7, 3));
                break;

            case 7:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 2, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 3, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlockRight, 1, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlockRight, 2, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 2, 3));
                break;

            case 8:
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedHillBlockLeft, 4, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlockRight, 2, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 4, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 4, 0));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 7, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 0, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 0, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 4, 4));
                break;
            case 9:
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedHillBlockLeft, 1, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlockRight, 3, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 7, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 7, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 6, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 6, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 0, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 0, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 0, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 2, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 6, 4));
                break;
            
            case 10:
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 5, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 2, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 2, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kSpring, 6, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 0, 1));
                break;

            case 11:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 0, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 7, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 2, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 0, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 7, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kSpring, 5, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 4, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 4, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 4, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 0, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 2, 3));
                break;
            
            case 12:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 2, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 2, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 5, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFallBlock, 3, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFallBlock, 4, 3));
                break;
            
            case 13:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 1, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 5, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 1, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFallBlock, 1, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 4, 3));
                break;

            case 14:
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 0, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 7, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 0, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 7, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFallBlock, 3, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedHillBlockLeft, 2, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kSpringLeft, 5, 4));
                break;
            
            case 15:
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedFallBlock, 2, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 1, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 6, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 1, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 4, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 0, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 6, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 7, 5));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 6, 0));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 3, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 3, 2));
                stageData.Add(new StageData(Common.Const.ObjectType.kSpringLeft, 2, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlock, 5, 2));
                break;
            
            case 16:
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedFallBlock, 3, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kPlayer, 1, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 5, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 2, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 2, 0));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 4, 4));
                stageData.Add(new StageData(Common.Const.ObjectType.kHillBlockRight, 6, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kGoal, 2, 1));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 3, 0));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 4, 0));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedBlock, 5, 0));
                stageData.Add(new StageData(Common.Const.ObjectType.kFixedFallBlock, 4, 3));
                stageData.Add(new StageData(Common.Const.ObjectType.kBlock, 1, 3));
                break;
            }
            return stageData;
        }

        public static int GetStageGoalCnt(int stageID)
        {
            var goalCnt = 0;
            switch(stageID){
            case 16:
                goalCnt = 2;
                break;
            default:
                goalCnt = 1;
                break;
            }
            return goalCnt;
        }
        #endregion
    }
}