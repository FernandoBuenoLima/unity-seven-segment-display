using System; //getting the time
using UnityEngine;

public class Clock : MonoBehaviour
{
    #region Properties

    public SevenSegmentDisplay hourTensDisplay;
    public SevenSegmentDisplay hourUnitsDisplay;
    public SevenSegmentDisplay minuteTensDisplay;
    public SevenSegmentDisplay minuteUnitsDisplay;

    int hours;
    int minutes;

    #endregion

    #region Methods

    private void Awake()
    {
        hours = -1;
        minutes = -1;
    }

    private void Update()
    {
        DateTime time = DateTime.Now;

        if (minutes != time.Minute)
        {
            hours = time.Hour;
            minutes = time.Minute;
            setTime();
        }
    }

    private void setTime()
    {
        int hourTens = hours / 10;
        int hourUnits = hours % 10;
        int minuteTens = minutes / 10;
        int minuteUnits = minutes % 10;

        hourTensDisplay.DisplayNumber(hourTens);
        hourUnitsDisplay.DisplayNumber(hourUnits);
        minuteTensDisplay.DisplayNumber(minuteTens);
        minuteUnitsDisplay.DisplayNumber(minuteUnits);
    }

    #endregion
}
