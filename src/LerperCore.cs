using UnityEngine;
using System.Collections.Generic;

namespace Virmay.Lerper.Core
{
    public class LerperCore
    {
        //public static readonly List<ILerper> pool = new(4096);
        static readonly Queue<ILerper> _queue = new(64);
        static ILerper _dequeued;

        public static readonly Dictionary<string, LerperGroup> groups = new(8) { { "main", new LerperGroup() } };

        public static void Update()
        {
            foreach (var group in groups)
            {
                for (int i = 0; i < group.Value.Count; i++)
                {
                    //insert lerper from queue to group's empty slot
                    if (group.Value[i] == null)
                    {
                        if (_queue.TryDequeue(out _dequeued) && _dequeued.group == group.Value)
                        {
                            group.Value[i] = _dequeued;
                            group.Value.ActivesCount++;
                        }
                        continue;
                    }
                    //update lerper
                    if (group.Value[i].IsPlaying) { group.Value[i].Update(Time.deltaTime); }
                    //destroy lerper if it's ended
                    if (group.Value[i].NeedToKill || group.Value[i].ForcedKill)
                    {
                        group.Value[i] = null;
                        group.Value.ActivesCount--;
                    }
                }
            }
        }

        public static void Insert(in ILerper newLerper)
        {
            LerperGroup groupDst = newLerper.group;
            //insert into queue
            if (groupDst.ActivesCount < groupDst.Count) _queue.Enqueue(newLerper);
            //if group is overflowed
            else { groupDst.Add(newLerper); groupDst.ActivesCount++; groupDst.Count++; }
        }
    }
}
