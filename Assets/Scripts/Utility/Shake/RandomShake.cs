using UnityEngine;
using System.Collections;

public class RandomShake : Shake {

    int frameCount = 0;

    public override int ObjShake(Transform transform)
    {
        if (curTime <= duration) {
            curTime += Time.deltaTime;
            if (++frameCount % frequency == 0) {
                if (originVec == -1000 * Vector3.one)
                    SetTargetVec(transform, GetTargetVec(transform) + new Vector3(Random.Range(-1f, 1) * vecDirection.x, Random.Range(-1f, 1) * vecDirection.y, Random.Range(-1f, 1) * vecDirection.z) * intensity);
                else SetTargetVec(transform, originVec + new Vector3(Random.Range(-1f, 1) * vecDirection.x, Random.Range(-1f, 1) * vecDirection.y, Random.Range(-1f, 1) * vecDirection.z) * intensity);
            }
            return 1;
        }
        else if (!once) {
            curTime = 0;
            return ObjShake(transform);
        }
        return 0;
    }

    public override void Reset()
    {
        base.Reset();
        frameCount = 0;
    }

}
