
//A 4-bit binary number (0-15) represented by booleans a-d
//a = 2^3
//b = 2^2
//c = 2^1
//d = 2^0

public class BinaryNumber
{
    #region Properties

    public bool A, B, C, D;

    public bool a { get { return A; } }
    public bool b { get { return B; } }
    public bool c { get { return C; } }
    public bool d { get { return D; } }

    #endregion

    #region Constructors

    public BinaryNumber(bool a, bool b, bool c, bool d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public BinaryNumber(int a = 0, int b = 0, int c = 0, int d = 0) : this(a == 1, b == 1, c == 1, d == 1) { }

    #endregion

    #region Conversion

    public int integer
    {
        get
        {
            int v = 0;

            if (A)
                v += 8;
            if (B)
                v += 4;
            if (C)
                v += 2;
            if (D)
                v += 1;

            return v;
        }
    }

    public override string ToString()
    {
        string s = "BinaryNumber[";

        if (A)
            s += "1,";
        else
            s += "0,";
        if (B)
            s += "1,";
        else
            s += "0,";
        if (C)
            s += "1,";
        else
            s += "0,";
        if (D)
            s += "1";
        else
            s += "0";

        s += "]";

        return s;
    }

    #endregion
}
