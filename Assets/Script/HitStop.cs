using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    // Start is called before the first frame update
    bool waiting; 
    public void Stop(float duration)
    {
        if (waiting) return; 
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }
    public void WaitSeconds(float duration)
    {
        StartCoroutine(Coroutine(duration));
    }
    IEnumerator Wait(float duration)
    {
        waiting = true; 
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        waiting = false; 
    }
    IEnumerator Coroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
