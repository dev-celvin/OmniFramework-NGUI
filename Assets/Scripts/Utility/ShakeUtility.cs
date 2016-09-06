using UnityEngine;
using System.Collections;

public class ShakeUtility : MonoBehaviour {

    public Shake OmniShake;

    public static ShakeUtility Shake<T>(GameObject obj, Shake.TargetType targetType, bool delayStart, Vector3 vecDirection, float intensity, int frequency, float duration, bool dynamic = false) where T : Shake, new()
    {
        return Shake<T>(obj, targetType, delayStart, vecDirection, intensity, frequency, dynamic, true, true, duration);
    }

    /// <param name="duration">the duration requires at least three times bigger than the application framerate so you can see a shake</param>
    public static ShakeUtility Shake<T>(GameObject obj, Shake.TargetType targetType, bool delayStart, Vector3 vecDirection, float intensity, int frequency, bool dynamic = false, bool usePause = true, bool once = true, float duration = 0.2f) where T : Shake, new(){
        ShakeUtility su = obj.GetComponent<ShakeUtility>();
        if (su != null){
            su.StopShake();
            su.OmniShake.Reset();
        }
        else {
            su = obj.AddComponent<ShakeUtility>();
        }
        if (su.OmniShake == null) {
            su.OmniShake = new T();
        }
        su.OmniShake.targetType = targetType;
        su.OmniShake.frequency = frequency;
        su.OmniShake.originVec = dynamic ? -1000 * Vector3.one : su.OmniShake.GetTargetVec(obj.transform);
        su.OmniShake.intensity = intensity;
        su.OmniShake.vecDirection = vecDirection;
        su.OmniShake.usePause = usePause;
        su.OmniShake.once = once;
        su.OmniShake.duration = duration;
        if (!delayStart) {
            su.OmniShake.Generate();
            su.StartShake();
        }
        return su;
    }

    public void StopShake() {
        OmniShake.Stop(transform);
        StopCoroutine("objShake");
    }

    public void StartShake() {
        StopCoroutine("objShake");
        StartCoroutine("objShake");
    }

    IEnumerator objShake() {
        while (OmniShake.ObjShake(transform) == 1) {
            yield return 0;
        }
        OmniShake.Stop(transform);
        Destroy(this);
    }

    public void PauseGame(bool paused) {
        if (OmniShake.usePause) {
            if (!paused){
                StopCoroutine("objShake");
            }
            else{
                StartCoroutine("objShake");
            }
        }
    }

}
