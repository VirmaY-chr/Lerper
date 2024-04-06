using System.Collections.Generic;
using System;
using Virmay.Lerper.Core;

namespace Virmay.Lerper
{
    public static class LerperSystem
    {
        public static float globalSpeed = 1;

        public static void Update() => LerperCore.Update();

        //SEARCHES ===================================================================
        public static ILerper FindByTag(object tag)
        {
            foreach (var i in LerperCore.groups) return i.Value.Find(x => x.tag == tag);
            return null;
        }
        public static List<ILerper> FindAllByTag(object tag)
        {
            foreach (var i in LerperCore.groups) return i.Value.FindAll(x => x.tag == tag);
            return null;
        }
        public static ILerper Find(ILerper l)
        {
            foreach (var i in LerperCore.groups) return i.Value.Find(x => x == l);
            return null;
        }
        public static ILerper Find(Predicate<ILerper> p)
        {
            foreach (var i in LerperCore.groups) return i.Value.Find(p);
            return null;
        }
        public static List<ILerper> FindAll(Predicate<ILerper> p)
        {
            foreach (var i in LerperCore.groups) return i.Value.FindAll(p);
            return null;
        }
        //
        public static void KillAllByTag(object tag)
        {
            var list = FindAll(x => x.tag == tag);
            foreach (var i in list) i.Kill();
        }
    }
}