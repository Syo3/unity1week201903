using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class StageData : MonoBehaviour {

        public Common.Const.ObjectType _type;
        public int _posX;
        public int _posY;

        public StageData(Common.Const.ObjectType type, int posX, int posY)
        {
            _type = type;
            _posX = posX;
            _posY = posY;
        }
    }
}