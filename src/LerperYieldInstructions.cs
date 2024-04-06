using UnityEngine;

namespace Virmay.Lerper
{
    public sealed class WaitForLerperEnd : CustomYieldInstruction
    {
        readonly ILerper lerper;
        public override bool keepWaiting => !lerper.IsEnded;
        public WaitForLerperEnd(ILerper lerper) => this.lerper = lerper;
    }
}