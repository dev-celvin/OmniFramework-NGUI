using UnityEngine;
using System.Collections;

public class TsetShake : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //ShakeUtility su = ShakeUtility.Shake<CurveShake>(gameObject, Shake.TargetType.Scale, true, Vector3.right, 1f, 30, 3);
            //CurveShake cs = (CurveShake)su.OmniShake;
            //cs.maxOffset = new Vector2(1.5f, -0.5f);
            //cs.curveMode = CurveShake.CurveMode.Smooth;
            //su.OmniShake.Generate();
            //su.StartShake();
            ShakeUtility.Shake<RandomShake>(gameObject, Shake.TargetType.Scale, false, Vector3.one, 0.2f, 2, false, true, false, 2);
        }
    }
}
