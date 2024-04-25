using UnityEngine;
using UnityEngine.Events;

public class SimpleTimer : MonoBehaviour
{
    public static SimpleTimer Instance { get; private set; }
    public float timeLeft = 60f; // default time
    public bool timerIsActive = false;

    public UnityEvent onTimerComplete;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (timerIsActive)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Timer Complete!");
                timerIsActive = false;
                onTimerComplete.Invoke();
                timeLeft = 0;
            }
        }
    }

    public void StartTimer(float duration)
    {
        timeLeft = duration;
        timerIsActive = true;
    }

    public void StopTimer()
    {
        timerIsActive = false;
    }
}
