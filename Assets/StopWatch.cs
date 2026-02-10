using UnityEngine;
using TMPro;

public class StopWatch : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float time;
    public bool run = true;

    void Update()
    {
        if(run)
        {
            time += Time.deltaTime;
            textMesh.text = time.ToString("F3");
        }
    }

    public void Stop()
    {
        run = false;
    }
}