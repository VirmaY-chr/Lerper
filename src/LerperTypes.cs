using System.Text;
#if UNITY_64
using UnityEngine;
#endif


namespace Virmay.Lerper
{
    //FLOAT =========================================================================================
    public sealed class FloatLerper : LerperBase<float>
    {
        public FloatLerper(float startValue, Setter<float> setter, float endValue, float duration, string group = null) : base(startValue, setter, endValue, duration, group) { }

        protected override void Set(float progress)
        {
            setter(EasingFunction.LerpUnclamped(startValue, endValue, progress));
        }
    }

    //STRING (ALLOC UNSTABLE) =========================================================================================
    public sealed class StringLerper : LerperBase<string>
    {
        readonly StringBuilder sb;
        readonly int length;
        public StringLerper(Setter<string> setter, string endValue, float duration, string group = null, string cursor = "") : base(cursor, setter, endValue, duration, group)
        { sb = new(); length = endValue.Length; }

        protected override void Set(float progress)
        {
            //if (startValue != "")
            //setter(endValue[..Mathf.RoundToInt(progress * length)] + (0 < progress && progress < 1 ? startValue : string.Empty));
            //else setter(endValue[..Mathf.RoundToInt(progress * length)]);
            sb.Append(endValue[..Mathf.RoundToInt(progress * length)]);
            if (startValue != "" && 0 < progress && progress < 1) sb.Append(startValue);
            setter(sb.ToString());
            sb.Clear();
        }
    }
#if UNITY_64
    //VECTOR2 =========================================================================================
    public sealed class Vec2Lerper : LerperBase<Vector2>
    {
        public Vec2Lerper(Vector2 startValue, Setter<Vector2> setter, Vector2 endValue, float duration, string group = null) : base(startValue, setter, endValue, duration, group) { }

        protected override void Set(float progress)
        {
            setter(Vector2.LerpUnclamped(startValue, endValue, progress));
        }
    }

    //VECTOR3 =========================================================================================
    public sealed class Vec3Lerper : LerperBase<Vector3>
    {
        public Vec3Lerper(Vector3 startValue, Setter<Vector3> setter, Vector3 endValue, float duration, string group = null) : base(startValue, setter, endValue, duration, group) { }

        protected override void Set(float progress)
        {
            setter(Vector3.LerpUnclamped(startValue, endValue, progress));
        }
    }

    //COLOR =========================================================================================
    public sealed class ColorLerper : LerperBase<Color>
    {
        public ColorLerper(Color startValue, Setter<Color> setter, Color endValue, float duration, string group = null) : base(startValue, setter, endValue, duration, group) { }

        protected override void Set(float progress)
        {
            setter(Color.LerpUnclamped(startValue, endValue, progress));
        }
    }
#endif
}