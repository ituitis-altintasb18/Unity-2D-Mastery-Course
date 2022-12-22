using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private CheckPoint[] checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = GetComponentsInChildren<CheckPoint>();
    }

    public CheckPoint GetLastCheckpointThatWasPassed()
    {
        return checkpoints.Last(t=>t.Passed);
    }
}
