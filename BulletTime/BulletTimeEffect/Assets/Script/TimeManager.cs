using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2.0f;

    void DoSlowMotion()
    {
        Time.timeScale = slowDownFactor;
    }
}
