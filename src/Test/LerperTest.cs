using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Virmay.Lerper;

public class LerperTest : MonoBehaviour
{
    public GameObject go;
    void Start()
    {
        for (int i = 0; i < 1; i++)
        {

        }
        go.transform.LerpLocalPosition(Vector2.right * 18, 2).Ease(Ease.InSine).Loop(LoopType.Yoyo, 3);
    }
    void Update()
    {
        LerperSystem.Update();
    }
}
