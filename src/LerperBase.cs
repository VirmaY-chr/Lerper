using System;
using Virmay.Lerper.Core;

namespace Virmay.Lerper
{
    public delegate void Setter<T>(T newValue);
    public enum LoopType { None, Repeat, Yoyo }

    public interface ILerper
    {
        public object tag { get; }
        public LerperGroup group { get; }
        public bool IsEnded { get; }
        public bool NeedToKill { get; }
        public bool ForcedKill { get; }
        public bool IsPlaying { get; }
        public void Update(float delta);
        public void Kill(bool andFinish = false);
        //CONTROL ==============================================================
        public ILerper Seek(float _time);
        public ILerper Play();
        public ILerper Pause();
        public ILerper Stop(bool andPlay = false);
        //MODIFICATIONS =======================================================
        public ILerper Ease(Ease ease);
        public ILerper Delay(float delay);
        public ILerper Loop(LoopType type, int count);
        public ILerper Speed(float spd);
        public ILerper Autokill(bool ak);
        public ILerper OnComplete(Action callback);
        public ILerper Tag(object id);
        public ILerper DependsOnSpeed(bool dos);
    }

    public abstract class LerperBase<T> : ILerper
    {
        protected Action completeCallback;
        public object tag { get; private set; }
        public LerperGroup group { get; }

        public bool IsPlaying => !_isPaused || _speed > 0;

        protected Setter<T> setter;
        protected T startValue;
        protected T endValue;
        protected float duration;

        float _speed;
        bool _isPaused;
        bool _dependsOnSpeed;

        Ease ease;

        bool _autokill;
        public bool IsEnded { get; private set; }
        public bool ForcedKill { get; private set; }
        public bool NeedToKill => _autokill && IsEnded;

        float _time;
        float _delay;
        float _loopTime;
        int _loopCount;
        protected LoopType loop;
        //CONSTRUCTORS =============================================================================
        public LerperBase() { }
        public LerperBase(T startValue, Setter<T> setter, T endValue, float duration, string groupName = null)
        {
#if DEBUG
            if (groupName != null && !LerperCore.groups.ContainsKey(groupName)) throw new Exception($"The specified group \"{groupName}\" does not exist.");
#endif
            this.startValue = startValue;
            this.setter = setter;
            this.endValue = endValue;
            this.duration = duration > 0 ? duration : 0.001f;
            _time = 0;
            _loopCount = 1;
            _speed = 1;
            IsEnded = false;
            ForcedKill = false;
            _isPaused = false;
            _autokill = true;
            _dependsOnSpeed = true;
            group = LerperCore.groups[groupName ?? "main"];
            LerperCore.Insert(this);
        }
        //UPDATE ======================================================================
        float Wrap(float v, float a, float b) => a + v % (b - a);
        float Oscillate(float v, float a, float b)
        {
            float range = b - a;
            return a + Math.Abs(((v + range) % (range * 2)) - range);
        }
        public void Update(float delta)
        {
            //BEYOND DELAY (KILL IMMIDEATELY)
            if (_time < -_delay)
            {
                Set(0);
                ForcedKill = true;
                return;
            }
            //DELAY
            delta *= _dependsOnSpeed ? _speed * group.speed * LerperSystem.globalSpeed : 1;
            if (0 >= _time)
            {
                IsEnded = false;
                Set(0);
                _time += delta;
                return;
            }
            //PLAYING
            float endTime = duration * (loop == LoopType.None ? 1 : _loopCount * (loop == LoopType.Yoyo ? 2 : 1));
            if (0 < _time && _time < endTime)
            {
                IsEnded = false;
                switch (loop)
                {
                    case LoopType.None:
                        _loopTime = _time;
                        break;
                    case LoopType.Repeat:
                        _loopTime = Wrap(_time, 0, duration);
                        break;
                    case LoopType.Yoyo:
                        _loopTime = Oscillate(_time, 0, duration);
                        break;
                }
                Set(EasingFunction.Calculate01(ease, _loopTime / duration));
                _time += delta;
                return;
            }
            //END
            if (_time >= endTime)
            {
                if (IsEnded) return;
                IsEnded = true;
                Set(loop != LoopType.Yoyo ? 1 : 0);
                completeCallback?.Invoke();
                return;
            }
        }
        protected abstract void Set(float progress);


        //CONTROL ==============================================================
        public ILerper Seek(float _time)
        {
            this._time = _time;
            Update(0);
            return this;
        }
        public ILerper Play()
        {
            _isPaused = false;
            return this;
        }
        public ILerper Pause()
        {
            _isPaused = true;
            return this;
        }
        public ILerper Stop(bool andPlay = false)
        {
            _time = -_delay;
            _isPaused = !andPlay;
            Update(0);
            return this;
        }
        public void Kill(bool andFinish = false)
        {
            _time = andFinish ? duration : _time;
            ForcedKill = true;
            Update(0);
        }


        //MODIFICATIONS =======================================================
        public ILerper Ease(Ease ease)
        {
            this.ease = ease;
            return this;
        }
        public ILerper Delay(float delay)
        {
            _delay = delay;
            _time = -delay;
            return this;
        }
        public ILerper Loop(LoopType type, int count)
        {
            loop = type;
            _loopCount = count;
            return this;
        }
        public ILerper Speed(float spd)
        {
            _speed = spd;
            return this;
        }
        public ILerper Autokill(bool ak)
        {
            _autokill = ak;
            return this;
        }
        public ILerper OnComplete(Action callback)
        {
            completeCallback = callback;
            return this;
        }
        public ILerper Tag(object id)
        {
            tag = id;
            return this;
        }
        public ILerper DependsOnSpeed(bool dos)
        {
            _dependsOnSpeed = dos;
            return this;
        }
    }
}