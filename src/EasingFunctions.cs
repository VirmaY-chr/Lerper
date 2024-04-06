using System;

namespace Virmay.Lerper
{
    public enum Ease
    {
        Linear,
        Instant,

        InSine,
        OutSine,
        InOutSine,

        InBack,
        OutBack,
        InOutBack,

        InElastic,
        OutElastic,
        InOutElastic,

        InBounce,
        OutBounce,
        InOutBounce,

        InQuad,
        OutQuad,
        InOutQuad,

        InCirc,
        OutCirc,
        InOutCirc,

        InExpo,
        OutExpo,
        InOutExpo
    }

    public static class EasingFunction
    {
        public static float LerpUnclamped(float a, float b, float t) => a + (b - a) * t;

        public static float Linear(float start, float end, float value)
        {
            return LerpUnclamped(start, end, value);
        }

        public static float Instant(float start, float end, float value)
        {
            if (value >= 1) return end;
            else return start;
        }

        public static float InQuad(float start, float end, float value)
        {
            end -= start;
            return end * value * value + start;
        }

        public static float OutQuad(float start, float end, float value)
        {
            end -= start;
            return -end * value * (value - 2) + start;
        }

        public static float InOutQuad(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value + start;
            value--;
            return -end * 0.5f * (value * (value - 2) - 1) + start;
        }

        public static float InSine(float start, float end, float value)
        {
            end -= start;
            return -end * MathF.Cos(value * (MathF.PI * 0.5f)) + end + start;
        }

        public static float OutSine(float start, float end, float value)
        {
            end -= start;
            return end * MathF.Sin(value * (MathF.PI * 0.5f)) + start;
        }

        public static float InOutSine(float start, float end, float value)
        {
            end -= start;
            return -end * 0.5f * (MathF.Cos(MathF.PI * value) - 1) + start;
        }

        public static float InExpo(float start, float end, float value)
        {
            end -= start;
            return end * MathF.Pow(2, 10 * (value - 1)) + start;
        }

        public static float OutExpo(float start, float end, float value)
        {
            end -= start;
            return end * (-MathF.Pow(2, -10 * value) + 1) + start;
        }

        public static float InOutExpo(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * MathF.Pow(2, 10 * (value - 1)) + start;
            value--;
            return end * 0.5f * (-MathF.Pow(2, -10 * value) + 2) + start;
        }

        public static float InCirc(float start, float end, float value)
        {
            end -= start;
            return -end * (MathF.Sqrt(1 - value * value) - 1) + start;
        }

        public static float OutCirc(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * MathF.Sqrt(1 - value * value) + start;
        }

        public static float InOutCirc(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return -end * 0.5f * (MathF.Sqrt(1 - value * value) - 1) + start;
            value -= 2;
            return end * 0.5f * (MathF.Sqrt(1 - value * value) + 1) + start;
        }

        public static float InBounce(float start, float end, float value)
        {
            end -= start;
            float d = 1f;
            return end - OutBounce(0, end, d - value) + start;
        }

        public static float OutBounce(float start, float end, float value)
        {
            value /= 1f;
            end -= start;
            if (value < (1 / 2.75f))
            {
                return end * (7.5625f * value * value) + start;
            }
            else if (value < (2 / 2.75f))
            {
                value -= (1.5f / 2.75f);
                return end * (7.5625f * (value) * value + .75f) + start;
            }
            else if (value < (2.5 / 2.75))
            {
                value -= (2.25f / 2.75f);
                return end * (7.5625f * (value) * value + .9375f) + start;
            }
            else
            {
                value -= (2.625f / 2.75f);
                return end * (7.5625f * (value) * value + .984375f) + start;
            }
        }

        public static float InOutBounce(float start, float end, float value)
        {
            end -= start;
            float d = 1f;
            if (value < d * 0.5f) return InBounce(0, end, value * 2) * 0.5f + start;
            else return OutBounce(0, end, value * 2 - d) * 0.5f + end * 0.5f + start;
        }

        public static float InBack(float start, float end, float value)
        {
            end -= start;
            value /= 1;
            float s = 1.70158f;
            return end * (value) * value * ((s + 1) * value - s) + start;
        }

        public static float OutBack(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value = (value) - 1;
            return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
        }

        public static float InOutBack(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value /= .5f;
            if ((value) < 1)
            {
                s *= (1.525f);
                return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
            }
            value -= 2;
            s *= (1.525f);
            return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
        }

        public static float InElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < MathF.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * MathF.PI) * MathF.Asin(end / a);
            }

            return -(a * MathF.Pow(2, 10 * (value -= 1)) * MathF.Sin((value * d - s) * (2 * MathF.PI) / p)) + start;
        }

        public static float OutElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < MathF.Abs(end))
            {
                a = end;
                s = p * 0.25f;
            }
            else
            {
                s = p / (2 * MathF.PI) * MathF.Asin(end / a);
            }

            return (a * MathF.Pow(2, -10 * value) * MathF.Sin((value * d - s) * (2 * MathF.PI) / p) + end + start);
        }

        public static float InOutElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d * 0.5f) == 2) return start + end;

            if (a == 0f || a < MathF.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * MathF.PI) * MathF.Asin(end / a);
            }

            if (value < 1) return -0.5f * (a * MathF.Pow(2, 10 * (value -= 1)) * MathF.Sin((value * d - s) * (2 * MathF.PI) / p)) + start;
            return a * MathF.Pow(2, -10 * (value -= 1)) * MathF.Sin((value * d - s) * (2 * MathF.PI) / p) * 0.5f + end + start;
        }


        public static float Calculate01(Ease easing, float value)
        {
            float calc = 0;
            switch (easing)
            {
                case Ease.Linear:
                    calc = Linear(0, 1, value);
                    break;
                case Ease.Instant:
                    calc = Instant(0, 1, value);
                    break;


                case Ease.InSine:
                    calc = InSine(0, 1, value);
                    break;
                case Ease.OutSine:
                    calc = OutSine(0, 1, value);
                    break;
                case Ease.InOutSine:
                    calc = InOutSine(0, 1, value);
                    break;


                case Ease.InBack:
                    calc = InBack(0, 1, value);
                    break;
                case Ease.OutBack:
                    calc = OutBack(0, 1, value);
                    break;
                case Ease.InOutBack:
                    calc = InOutBack(0, 1, value);
                    break;


                case Ease.InElastic:
                    calc = InElastic(0, 1, value);
                    break;
                case Ease.OutElastic:
                    calc = OutElastic(0, 1, value);
                    break;
                case Ease.InOutElastic:
                    calc = InOutElastic(0, 1, value);
                    break;


                case Ease.InBounce:
                    calc = InBounce(0, 1, value);
                    break;
                case Ease.OutBounce:
                    calc = OutBounce(0, 1, value);
                    break;
                case Ease.InOutBounce:
                    calc = InOutBounce(0, 1, value);
                    break;


                case Ease.InQuad:
                    calc = InQuad(0, 1, value);
                    break;
                case Ease.OutQuad:
                    calc = OutQuad(0, 1, value);
                    break;
                case Ease.InOutQuad:
                    calc = InOutQuad(0, 1, value);
                    break;


                case Ease.InCirc:
                    calc = InCirc(0, 1, value);
                    break;
                case Ease.OutCirc:
                    calc = OutCirc(0, 1, value);
                    break;
                case Ease.InOutCirc:
                    calc = InOutCirc(0, 1, value);
                    break;


                case Ease.InExpo:
                    calc = InExpo(0, 1, value);
                    break;
                case Ease.OutExpo:
                    calc = OutExpo(0, 1, value);
                    break;
                case Ease.InOutExpo:
                    calc = InOutExpo(0, 1, value);
                    break;
            }
            return calc;
        }
    }
}
