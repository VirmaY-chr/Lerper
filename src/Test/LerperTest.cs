using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Virmay.Lerper;

public class LerperTest : MonoBehaviour
{
    public GameObject go;
    public TMPro.TextMeshPro text;
    void Start()
    {
        text.LerpText(@"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt 
mollit anim id est laborum.", 5, "▌").Delay(1f).Ease(Ease.InOutCirc);

        go.transform.LerpPosition(Vector2.right * 18, 2).Ease(Ease.InSine).Loop(LoopType.Yoyo, 3);
    }
    void Update()
    {
        LerperSystem.Update();
    }
}
