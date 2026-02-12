using UnityEngine;

public class RockMov : MonoBehaviour
{
    public GameObject Rock1;
    private StopWatch timer;
    private float currentWait = 0.9f;
    //float wait = 0.9f;
    //public GameObject Rock1;
    //StopWatch timer;

    void Start()
    {
        timer = FindFirstObjectByType<StopWatch>();
        InvokeRepeating("Fall", 0.5f, currentWait);
        //InvokeRepeating("Fall", wait, wait);
    }

    void Update()
    {
        if(timer.time >= 20f && currentWait > 0.3f)
        {
            ChangeSpeed(0.3f);
            //wait = 0.3f;
            //CancelInvoke("Fall");
            //InvokeRepeating("Fall", wait, wait);
        }

        else if(timer.time >= 13f && currentWait > 0.5f)
        {
            ChangeSpeed(0.5f);
           //wait = 0.5f;
            //CancelInvoke("Fall");
            //InvokeRepeating("Fall", wait, wait);
        }

        else if(timer.time >= 7f && currentWait > 0.7f)
        {
            ChangeSpeed(0.7f);
            //wait = 0.7f;
            //CancelInvoke("Fall");
            //InvokeRepeating("Fall", wait, wait);
        }
    }

void ChangeSpeed(float newWait){
    currentWait = newWait;
    CancelInvoke("Fall");
    InvokeRepeating("Fall", currentWait, currentWait);
}

    void Fall()
    {
        Instantiate(Rock1, new Vector3(Random.Range(-10f,10f), 20, 0), Quaternion.identity);
    }
}