using System.Collections.Generic;
using System;
using Virmay.Lerper.Core;

namespace Virmay.Lerper
{
    public sealed class LerperGroup
    {
        readonly List<ILerper> lerpers;
        public ILerper this[int index] { get => lerpers[index]; set { lerpers[index] = value; } }
        public int ActivesCount;
        public int Count;
        public float speed = 1;

        public LerperGroup() { lerpers = new(1024); }
        public LerperGroup(string name)
        {
            lerpers = new(1024);
            ActivesCount = Count = 0;
            speed = 1;
            LerperCore.groups.Add(name, this);
        }
        public LerperGroup(string name, int capacity)
        {
            lerpers = new(capacity);
            ActivesCount = Count = 0;
            speed = 1;
            LerperCore.groups.Add(name, this);
        }


        public void Add(ILerper item) => lerpers.Add(item);
        public LerperGroup Get(string name) => LerperCore.groups[name];
        public static LerperGroup Main => LerperCore.groups["main"];
        public void Kill(string name)
        {
            foreach (var i in LerperCore.groups[name].lerpers) i.Kill();
        }
        public void Destroy(string name)
        {
            Kill(name);
            LerperCore.groups.Remove(name);
        }

        //SEARCHES ===================================================================
        public ILerper FindByTag(object tag) => lerpers.Find(x => x.tag == tag);
        public List<ILerper> FindAllByTag(object tag) => lerpers.FindAll(x => x.tag == tag);
        public ILerper Find(ILerper l) => lerpers.Find(x => x == l);
        public ILerper Find(Predicate<ILerper> p) => lerpers.Find(p);
        public List<ILerper> FindAll(Predicate<ILerper> p) => lerpers.FindAll(p);
    }
}