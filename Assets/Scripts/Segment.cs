using UnityEngine;
using UnityEngine.UI;

public class Segment : MonoBehaviour
{
    #region Properties

    private Image graphic;

    #region Turning on and off

    private bool _on;
    public bool on
    {
        get { return _on; }
        set
        {
            _on = value;

            Color c = graphic.color;

            if (value)
                c.a = 1f;
            else
                c.a = 0.25f;

            graphic.color = c;
        }
    }

    public void TurnOn()
    {
        on = true;
    }

    public void TurnOff()
    {
        on = false;
    }

    public void Toggle()
    {
        on = !on;
    }

    #endregion

    #endregion

    void Awake()
    {
        graphic = GetComponent<Image>();
    }
}
