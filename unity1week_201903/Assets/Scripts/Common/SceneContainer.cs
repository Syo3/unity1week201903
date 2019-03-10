using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContainer : MonoBehaviour {

	#region public field
	private bool _debugFlg;
	#endregion

	#region access
	public bool DebugFlg{
		get{return _debugFlg;}
		set{_debugFlg = value;}
	}
	#endregion
}
