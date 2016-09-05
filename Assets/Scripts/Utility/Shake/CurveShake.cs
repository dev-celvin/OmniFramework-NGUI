using UnityEngine;
using System.Collections;

/// <summary>
/// one directoinal shake support only, horizontal or vertical or z direction, use RandomShake to apply multi-dirctional shake
/// </summary>
public class CurveShake : Shake {

    public AnimationCurve shakeCurve;
    public CurveMode curveMode = CurveMode.Linear;
    /// <summary>
    /// x means passitive offset, y means negative offset
    /// </summary>
    public Vector2 maxOffset = new Vector2(1, -1);
    /// <summary>
    /// the value will only be used in curve shake mode, negative value means start from a lower position, passitive means start from a higher position
    /// </summary>
    public int beginSign = 1;

    public override bool Generate()
    {
        base.Generate();
        //the max length of keyframe array is duration / frame-costtime - 1
        int aryLenth = Mathf.Clamp((int)frequency, 3, 99);
        if (aryLenth <= 0) return false;
        int tangentMode = (int)curveMode;
        float timeOffset = 0, segTime = duration / (aryLenth - 1), tmpValue;
        Vector2 offset = maxOffset * intensity;
        Keyframe[] keyframes = new Keyframe[aryLenth];
        keyframes[0] = new Keyframe(0, 0, 0, 0);
        keyframes[0].tangentMode = tangentMode;
        keyframes[aryLenth - 1] = new Keyframe(duration, 0);
        keyframes[aryLenth - 1].tangentMode = tangentMode;
        for (int i = 1; i < aryLenth - 1; i++) {
            timeOffset += segTime;
            tmpValue = beginSign == 1 ? i % 2 == 0 ? offset.y : offset.x : i % 2 == 0 ? offset.x : offset.y;
            keyframes[i] = new Keyframe(timeOffset, tmpValue);
            keyframes[i].tangentMode = tangentMode;
            offset *= .618f;
        }
        shakeCurve = new AnimationCurve(keyframes);
        return true;
    }

    public override int ObjShake(Transform transform)
    {
        if (curTime <= duration)
        {
            curTime += Time.deltaTime;
            if (originVec == -1000 * Vector3.one)
                SetTargetVec(transform, GetTargetVec(transform) + GetDirectionalOffset());
            else
                SetTargetVec(transform, originVec + GetDirectionalOffset());
            return 1;
        }
        else if (!once)
        {
            curTime = 0;
            return ObjShake(transform);
        }
        else return 0;
    }

    Vector3 GetDirectionalOffset() {
        if (vecDirection == Vector3.right) return new Vector3(shakeCurve.Evaluate(curTime), 0, 0);
        else if (vecDirection == Vector3.up) return new Vector3(0, shakeCurve.Evaluate(curTime), 0);
        else if (vecDirection == Vector3.forward) return new Vector3(0, 0, shakeCurve.Evaluate(curTime));
        Debug.LogError("CurveShake don't support multi direction.");
        return Vector3.zero;
    }

    public enum CurveMode {
        Smooth = 0,
        Linear = 21,
    }


}
