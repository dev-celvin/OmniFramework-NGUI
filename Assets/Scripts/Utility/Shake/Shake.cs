using UnityEngine;
using System.Collections;

public class Shake {

    public Vector3 originVec = new Vector3(-1000, -1000, -1000);
    /// <summary>
    /// set the value to 1,1,1 to activate 3d shake, 0,0,0 to inactivate shake on all direction
    /// </summary>
    public Vector3 vecDirection;
    public float intensity;
    /// <summary>
    /// in random shake mode, obj will shake every frequency time, 1 means shake every frame
    /// <para>
    /// in curve shake mode, the frequency means the number of curve key point, if the value is too big, the shake will look like a random shake
    /// </para>
    /// </summary>
    public int frequency;
    public bool usePause;
    public bool once;
    /// <summary>
    /// duration is limit to the application frame rate, if the duration is too short, you will not see any shake
    /// </summary>
    public float duration;
    public TargetType targetType = TargetType.Position;
    protected float curTime = 0;

    /// <summary>
    /// <returns>return a integer,1 is success,0 is shakeover</returns>
    /// </summary>
    public virtual int ObjShake(Transform transform) {
        return 0;
    }

    public virtual bool Generate() {
        return true;
    }

    public virtual void Stop(Transform trans) {
        if (originVec != -1000 * Vector3.one)
            SetTargetVec(trans, originVec);
    }

    public virtual void Reset() {
        curTime = 0;
    }

    public void SetTargetVec(Transform transform, Vector3 tarVec) {
        switch (targetType) {
            case TargetType.Position:
                transform.localPosition = tarVec;
                break;
            case TargetType.Scale:
                transform.localScale = tarVec;
                break;
        }
    }

    public Vector3 GetTargetVec(Transform transform) {
        switch (targetType)
        {
            case TargetType.Position:
                return transform.localPosition;
            case TargetType.Scale:
                return transform.localScale;
        }
        return Vector3.zero;
    }

    public enum TargetType {
        Position,
        Scale,
        EulerAngle,
        Digit,
    }

}
