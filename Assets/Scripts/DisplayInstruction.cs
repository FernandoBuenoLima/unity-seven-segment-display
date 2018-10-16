
//booleans for each segment of the SevenSegmentDisplay
public class DisplayInstruction
{
    public bool[] segments;

    public DisplayInstruction(bool a=false, bool b = false, bool c = false, bool d = false, bool e = false, bool f = false, bool g = false)
    {
        segments = new bool[7];

        segments[0] = a;
        segments[1] = b;
        segments[2] = c;
        segments[3] = d;
        segments[4] = e;
        segments[5] = f;
        segments[6] = g;
    }
}
