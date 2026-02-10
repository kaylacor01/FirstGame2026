using UnityEngine;

public class RockMov : MonoBehaviour
{
    float wait = 0.9f;
    public GameObject Rock1;
    StopWatch timer;

    void Start()
    {
        timer = FindFirstObjectByType<StopWatch>();
        InvokeRepeating("Fall", wait, wait);
    }

    void Update()
    {
        if(timer.time >= 20f && wait != 0.3f)
        {
            wait = 0.3f;
            CancelInvoke("Fall");
            InvokeRepeating("Fall", wait, wait);
        }

        else if(timer.time >= 13f && wait != 0.5f)
        {
            wait = 0.5f;
            CancelInvoke("Fall");
            InvokeRepeating("Fall", wait, wait);
        }

        else if(timer.time >= 7f && wait != 0.7f)
        {
            wait = 0.7f;
            CancelInvoke("Fall");
            InvokeRepeating("Fall", wait, wait);
        }
    }

    void Fall()
    {
        Instantiate(Rock1, new Vector3(Random.Range(-10f,10f), 20, 0), Quaternion.identity);
    }
}
