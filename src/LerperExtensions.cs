using UnityEngine;
using System.Runtime.CompilerServices;

namespace Virmay.Lerper
{
    public static class LerperExtensions
    {
        //FUNCS =============================================================
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetGlobalScale(this Transform transform, Vector3 globalScale)
        {
            transform.localScale = Vector3.one;
            transform.localScale = new Vector3(globalScale.x / transform.lossyScale.x, globalScale.y / transform.lossyScale.y, globalScale.z / transform.lossyScale.z);
        }
        //TRANSFORM =========================================================
        public static Vec3Lerper LerpGlobalPosition(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.position = x, e, d, group);
        public static Vec3Lerper LerpGlobalPosition(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.position, x => t.position = x, e, d, group);
        public static Vec3Lerper LerpPosition(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.localPosition = x, e, d, group);
        public static Vec3Lerper LerpPosition(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.localPosition, x => t.localPosition = x, e, d, group);
        public static Vec3Lerper LerpGlobalScale(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.SetGlobalScale(x), e, d, group);
        public static Vec3Lerper LerpGlobalScale(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.lossyScale, x => t.SetGlobalScale(x), e, d, group);
        public static Vec3Lerper LerpScale(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.localScale = x, e, d, group);
        public static Vec3Lerper LerpScale(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.localScale, x => t.localScale = x, e, d, group);
        public static Vec3Lerper LerpGlobalAngles(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.eulerAngles = x, e, d, group);
        public static Vec3Lerper LerpGlobalAngles(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.eulerAngles, x => t.eulerAngles = x, e, d, group);
        public static Vec3Lerper LerpAngles(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.localEulerAngles = x, e, d, group);
        public static Vec3Lerper LerpAngles(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.localEulerAngles, x => t.localEulerAngles = x, e, d, group);
        //SPRITE ============================================================
        //MATERIAL ==========================================================
        public static ColorLerper LerpColor(this Material cls, Color s, Color e, float d, string group = null) =>
            new(s, x => cls.color = x, e, d, group);
        public static ColorLerper LerpColor(this Material cls, Color e, float d, string group = null) =>
            new(cls.color, x => cls.color = x, e, d, group);
        public static ColorLerper LerpColor(this SpriteRenderer sr, Color s, Color e, float d, string group = null) =>
            new(s, x => sr.color = x, e, d, group);
        public static ColorLerper LerpColor(this SpriteRenderer sr, Color e, float d, string group = null) =>
            new(sr.color, x => sr.color = x, e, d, group);
        //AUDIO =============================================================
        // public static FloatLerper LerpVolume(this AudioSource a, float s, float e, float d, bool relative = false)
        //     => !relative ? new(s, x => a.volume = x, e, d) : new(a.volume, x => a.volume = x, e, d);
        // public static FloatLerper LerpPitch(this AudioSource a, float s, float e, float d, bool relative = false)
        //     => !relative ? new(s, x => a.pitch = x, e, d) : new(a.pitch, x => a.pitch = x, e, d);
        // public static FloatLerper LerpTime(this AudioSource a, float s, float e, float d, bool relative = false)
        //     => !relative ? new(s, x => a.time = x, e, d) : new(a.time, x => a.time = x, e, d);
        //CANVAS GROUP ======================================================
        // public static FloatLerper LerpAlpha(this CanvasGroup cg, float s, float e, float d, bool relative = false)
        //     => !relative ? new(s, x => cg.alpha = x, e, d) : new(cg.alpha, x => cg.alpha = x, e, d);
    }
}
