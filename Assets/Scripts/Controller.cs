using UnityEngine;

public class Controller : MonoBehaviour
{
    #region Properties

    SevenSegmentDisplay display;
    int number;
    bool auto;
    float timer;
    public float autoDelay;

    #endregion

    #region MonoBehaviour

    void Awake()
    {
        display = FindObjectOfType<SevenSegmentDisplay>();
        number = 0;
        auto = false;

        if (!display)
            Debug.LogError("Controller.Awake() - SevenSegmentDisplay was not found!");
    }

    void Start()
    {
        display.DisplayNumber(number);
    }

    void Update()
    {
        if (auto)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Increment();
                timer = autoDelay;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    #endregion

    #region Buttons

    public void Auto()
    {
        auto = true;
        timer = autoDelay;
    }

    public void StopAuto()
    {
        auto = false;
    }

    public void Increment()
    {
        number++;
        if (number > 9)
            number = 0;

        display.DisplayNumber(number);
    }

    public void Decrement()
    {
        number--;
        if (number < 0)
            number = 9;

        display.DisplayNumber(number);
    }

    #endregion
}
