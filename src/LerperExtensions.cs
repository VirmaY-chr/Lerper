using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Virmay.Lerper
{
    public static class LerperExtensionsForTransform
    {
        //FUNCS =============================================================
        public static void SetGlobalScale(this Transform transform, Vector3 globalScale)
        {
            transform.localScale = Vector3.one;
            transform.localScale = new Vector3(globalScale.x / transform.lossyScale.x, globalScale.y / transform.lossyScale.y, globalScale.z / transform.lossyScale.z);
        }


        //GLOBAL POSITION =================================================================================================================
        public static Vec3Lerper LerpGlobalPosition(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.position = x, e, d, group);
        //==========
        public static Vec3Lerper LerpGlobalPosition(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.position, x => t.position = x, e, d, group);


        //POSITION =================================================================================================================
        public static Vec3Lerper LerpPosition(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.localPosition = x, e, d, group);
        //==========
        public static Vec3Lerper LerpPosition(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.localPosition, x => t.localPosition = x, e, d, group);


        //POSITION X =================================================================================================================
        public static FloatLerper LerpPositionX(this Transform t, float s, float e, float d, string group = null) =>
            new(s, x => t.localPosition = new(x, t.localPosition.y, t.localPosition.z), e, d, group);
        //==========
        public static FloatLerper LerpPositionX(this Transform t, float e, float d, string group = null) =>
            new(t.localPosition.x, x => t.localPosition = new(x, t.localPosition.y, t.localPosition.z), e, d, group);


        //POSITION Y =================================================================================================================
        public static FloatLerper LerpPositionY(this Transform t, float s, float e, float d, string group = null) =>
            new(s, y => t.localPosition = new(t.localPosition.x, y, t.localPosition.z), e, d, group);
        //==========
        public static FloatLerper LerpPositionY(this Transform t, float e, float d, string group = null) =>
            new(t.localPosition.y, y => t.localPosition = new(t.localPosition.x, y, t.localPosition.z), e, d, group);


        //POSITION Z =================================================================================================================
        public static FloatLerper LerpPositionZ(this Transform t, float s, float e, float d, string group = null) =>
            new(s, z => t.localPosition = new(t.localPosition.x, t.localPosition.y, z), e, d, group);
        //==========
        public static FloatLerper LerpPositionZ(this Transform t, float e, float d, string group = null) =>
            new(t.localPosition.z, z => t.localPosition = new(t.localPosition.x, t.localPosition.y, z), e, d, group);


        //GLOBAL SCALE =======================================================================================================
        public static Vec3Lerper LerpGlobalScale(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.SetGlobalScale(x), e, d, group);
        //==========
        public static Vec3Lerper LerpGlobalScale(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.lossyScale, x => t.SetGlobalScale(x), e, d, group);


        //SCALE =================================================================================================================
        public static Vec3Lerper LerpScale(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.localScale = x, e, d, group);
        //==========
        public static Vec3Lerper LerpScale(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.localScale, x => t.localScale = x, e, d, group);


        //SCALE X =================================================================================================================
        public static FloatLerper LerpScaleX(this Transform t, float s, float e, float d, string group = null) =>
            new(s, x => t.localScale = new(x, t.localScale.y, t.localScale.z), e, d, group);
        //==========
        public static FloatLerper LerpScaleX(this Transform t, float e, float d, string group = null) =>
            new(t.localScale.x, x => t.localScale = new(x, t.localScale.y, t.localScale.z), e, d, group);


        //SCALE Y =================================================================================================================
        public static FloatLerper LerpScaleY(this Transform t, float s, float e, float d, string group = null) =>
            new(s, y => t.localScale = new(t.localScale.x, y, t.localScale.z), e, d, group);
        //==========
        public static FloatLerper LerpScaleY(this Transform t, float e, float d, string group = null) =>
            new(t.localScale.y, y => t.localScale = new(t.localScale.x, y, t.localScale.z), e, d, group);


        //SCALE Z =================================================================================================================
        public static FloatLerper LerpScaleZ(this Transform t, float s, float e, float d, string group = null) =>
            new(s, z => t.localScale = new(t.localScale.x, t.localScale.y, z), e, d, group);
        //==========
        public static FloatLerper LerpScaleZ(this Transform t, float e, float d, string group = null) =>
            new(t.localScale.z, z => t.localScale = new(t.localScale.x, t.localScale.y, z), e, d, group);


        //GLOBAL ANGLE =================================================================================================================
        public static Vec3Lerper LerpGlobalAngles(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.eulerAngles = x, e, d, group);
        //==========
        public static Vec3Lerper LerpGlobalAngles(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.eulerAngles, x => t.eulerAngles = x, e, d, group);


        //ANGLE =================================================================================================================
        public static Vec3Lerper LerpAngles(this Transform t, Vector3 s, Vector3 e, float d, string group = null) =>
            new(s, x => t.localEulerAngles = x, e, d, group);
        //==========  
        public static Vec3Lerper LerpAngles(this Transform t, Vector3 e, float d, string group = null) =>
            new(t.localEulerAngles, x => t.localEulerAngles = x, e, d, group);


        //ANGLE X =================================================================================================================
        public static FloatLerper LerpAngleX(this Transform t, float s, float e, float d, string group = null) =>
            new(s, x => t.localEulerAngles = new(x, t.localEulerAngles.y, t.localEulerAngles.z), e, d, group);
        //==========
        public static FloatLerper LerpAngleX(this Transform t, float e, float d, string group = null) =>
            new(t.localEulerAngles.x, x => t.localEulerAngles = new(x, t.localEulerAngles.y, t.localEulerAngles.z), e, d, group);


        //ANGLE Y =================================================================================================================
        public static FloatLerper LerpAngleY(this Transform t, float s, float e, float d, string group = null) =>
            new(s, y => t.localEulerAngles = new(t.localEulerAngles.x, y, t.localEulerAngles.z), e, d, group);
        //==========
        public static FloatLerper LerpAngleY(this Transform t, float e, float d, string group = null) =>
            new(t.localEulerAngles.y, y => t.localEulerAngles = new(t.localEulerAngles.x, y, t.localEulerAngles.z), e, d, group);


        //ANGLE Z =================================================================================================================
        public static FloatLerper LerpAngleZ(this Transform t, float s, float e, float d, string group = null) =>
            new(s, z => t.localEulerAngles = new(t.localEulerAngles.x, t.localEulerAngles.y, z), e, d, group);
        //==========
        public static FloatLerper LerpAngleZ(this Transform t, float e, float d, string group = null) =>
            new(t.localEulerAngles.z, z => t.localEulerAngles = new(t.localEulerAngles.x, t.localEulerAngles.y, z), e, d, group);
    }







    public static class LerperExtensionsForRectTransform
    {
        //DELTA X =================================================================================================================
        public static FloatLerper LerpDeltaX(this RectTransform t, float s, float e, float d, string group = null) =>
            new(s, x => t.sizeDelta = new(x, t.sizeDelta.y), e, d, group);
        //==========
        public static FloatLerper LerpDeltaX(this RectTransform t, float e, float d, string group = null) =>
            new(t.sizeDelta.x, x => t.sizeDelta = new(x, t.sizeDelta.y), e, d, group);


        //DELTA Y =================================================================================================================
        public static FloatLerper LerpDeltaY(this RectTransform t, float s, float e, float d, string group = null) =>
            new(s, y => t.sizeDelta = new(t.sizeDelta.x, y), e, d, group);
        //==========
        public static FloatLerper LerpDeltaY(this RectTransform t, float e, float d, string group = null) =>
            new(t.sizeDelta.y, y => t.sizeDelta = new(t.sizeDelta.x, y), e, d, group);


        //PIVOT X =================================================================================================================
        public static FloatLerper LerpPivotX(this RectTransform t, float s, float e, float d, string group = null) =>
            new(s, x => t.pivot = new(x, t.pivot.y), e, d, group);
        //==========
        public static FloatLerper LerpPivotX(this RectTransform t, float e, float d, string group = null) =>
            new(t.pivot.x, x => t.pivot = new(x, t.pivot.y), e, d, group);


        //PIVOT Y =================================================================================================================
        public static FloatLerper LerpPivotY(this RectTransform t, float s, float e, float d, string group = null) =>
            new(s, y => t.pivot = new(t.pivot.x, y), e, d, group);
        //==========
        public static FloatLerper LerpPivotY(this RectTransform t, float e, float d, string group = null) =>
            new(t.pivot.y, y => t.pivot = new(t.pivot.x, y), e, d, group);
    }








    public static class LerperExtensionsForMaterial
    {
        //MATERIAL COLOR ================================================================================================================
        public static ColorLerper LerpColor(this Material cls, Color s, Color e, float d, string group = null) =>
         new(s, x => cls.color = x, e, d, group);
        //==========
        public static ColorLerper LerpColor(this Material cls, Color e, float d, string group = null) =>
            new(cls.color, x => cls.color = x, e, d, group);


        //MATERIAL ALPHA ================================================================================================================
        public static FloatLerper LerpAlpha(this Material cls, float s, float e, float d, string group = null) =>
            new(s, x => cls.color = new(cls.color.r, cls.color.r, cls.color.r, x), e, d, group);
        //==========
        public static FloatLerper LerpAlpha(this Material cls, float e, float d, string group = null) =>
            new(cls.color.a, x => cls.color = new(cls.color.r, cls.color.r, cls.color.r, x), e, d, group);
    }









    public static class LerperExtensionsForSpriteRenderer
    {
        //SPRITE COLOR ================================================================================================================
        public static ColorLerper LerpColor(this SpriteRenderer cls, Color s, Color e, float d, string group = null) =>
            new(s, x => cls.color = x, e, d, group);
        //==========
        public static ColorLerper LerpColor(this SpriteRenderer cls, Color e, float d, string group = null) =>
            new(cls.color, x => cls.color = x, e, d, group);


        //SPRITE ALPHA ================================================================================================================
        public static FloatLerper LerpAlpha(this SpriteRenderer cls, float s, float e, float d, string group = null) =>
            new(s, x => cls.color = new(cls.color.r, cls.color.r, cls.color.r, x), e, d, group);
        //==========
        public static FloatLerper LerpAlpha(this SpriteRenderer cls, float e, float d, string group = null) =>
            new(cls.color.a, x => cls.color = new(cls.color.r, cls.color.r, cls.color.r, x), e, d, group);

    }








    public static class LerperExtensionsForTMP
    {
        public static StringLerper LerpText(this TMP_Text o, string e, float d, string cursor = "", string group = null) =>
            new(x => o.text = x, e, d, group, cursor);
        //TMP COLOR ================================================================================================================
        public static ColorLerper LerpColor(this TMP_Text o, Color s, Color e, float d, string group = null) =>
            new(s, x => o.color = x, e, d, group);
        //==========
        public static ColorLerper LerpColor(this TMP_Text o, Color e, float d, string group = null) =>
            new(o.color, x => o.color = x, e, d, group);


        //TMP ALPHA ================================================================================================================
        public static FloatLerper LerpAlpha(this TMP_Text o, float s, float e, float d, string group = null) =>
            new(s, x => o.color = new(o.color.r, o.color.r, o.color.r, x), e, d, group);
        //==========
        public static FloatLerper LerpAlpha(this TMP_Text o, float e, float d, string group = null) =>
            new(o.color.a, x => o.color = new(o.color.r, o.color.r, o.color.r, x), e, d, group);
    }









    public static class LerperExtensionsForUIGraphics
    {
        //UI GRAPHIC COLOR ================================================================================================================
        public static ColorLerper LerpColor(this Graphic o, Color s, Color e, float d, string group = null) =>
            new(s, x => o.color = x, e, d, group);
        //==========
        public static ColorLerper LerpColor(this Graphic o, Color e, float d, string group = null) =>
            new(o.color, x => o.color = x, e, d, group);


        //UI GRAPHIC ALPHA ================================================================================================================
        public static FloatLerper LerpAlpha(this Graphic o, float s, float e, float d, string group = null) =>
            new(s, x => o.color = new(o.color.r, o.color.r, o.color.r, x), e, d, group);
        //==========
        public static FloatLerper LerpAlpha(this Graphic o, float e, float d, string group = null) =>
            new(o.color.a, x => o.color = new(o.color.r, o.color.r, o.color.r, x), e, d, group);


        //CANVAS GROUP ALPHA ================================================================================================================
        public static FloatLerper LerpAlpha(this CanvasGroup o, float s, float e, float d, string group = null) =>
            new(s, x => o.alpha = x, e, d, group);
        //==========
        public static FloatLerper LerpAlpha(this CanvasGroup o, float e, float d, string group = null) =>
            new(o.alpha, x => o.alpha = x, e, d, group);
    }








    public static class LerperExtensionsForAudio
    {
        //AUDIO VOLUME ================================================================================================================
        public static FloatLerper LerpVolume(this AudioSource a, float s, float e, float d, string group = null) =>
            new(s, x => a.volume = x, e, d, group);
        //==========
        public static FloatLerper LerpVolume(this AudioSource a, float e, float d, string group = null) =>
            new(a.volume, x => a.volume = x, e, d, group);


        //AUDIO PITCH ================================================================================================================
        public static FloatLerper LerpPitch(this AudioSource a, float s, float e, float d, string group = null) =>
            new(s, x => a.pitch = x, e, d, group);
        //==========
        public static FloatLerper LerpPitch(this AudioSource a, float e, float d, string group = null) =>
            new(a.pitch, x => a.pitch = x, e, d, group);


        //AUDIO TIME ================================================================================================================
        public static FloatLerper LerpTime(this AudioSource a, float s, float e, float d, string group = null) =>
            new(s, x => a.time = x, e, d, group);
        //==========
        public static FloatLerper LerpTime(this AudioSource a, float e, float d, string group = null) =>
            new(a.time, x => a.time = x, e, d, group);
    }
}
