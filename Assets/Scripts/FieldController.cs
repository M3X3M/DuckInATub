using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    [SerializeField] private ScoreMaster scoreMaster;

    public void AscendDone()
    {
        scoreMaster.StartComplete();
    }

    public void DescendDone()
    {
        scoreMaster.EndComplete();
    }
}
