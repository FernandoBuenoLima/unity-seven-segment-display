using UnityEngine;

public class SevenSegmentDisplay : MonoBehaviour
{
    #region Properties

    private Segment[] segments;
    private BinaryNumber[] numbersToDisplay;
    private DisplayInstruction[] instructions;

    #endregion

    #region Loading

    void Awake()
    {
        segments = GetComponentsInChildren<Segment>();

        if (segments.Length != 7)
            Debug.LogError("SevenSegmentDisplay.Awake() - Oops, number of segments should be 7 but it's actually: " + segments.Length);

        numbersToDisplay = new BinaryNumber[10];
        instructions = new DisplayInstruction[10];

        fillBinaryNumbers();
        fillInstructions();
    }

    private void fillBinaryNumbers()
    {
        BinaryNumber biNum = null;
        int num = 0;

        for (int a = 0; a <= 1; a++)
        {
            for (int b = 0; b <= 1; b++)
            {
                for (int c = 0; c <= 1; c++)
                {
                    for (int d = 0; d <= 1; d++)
                    {
                        biNum = new BinaryNumber(a, b, c, d);
                        num = biNum.integer;

                        if (num > 9)
                            break;

                        numbersToDisplay[num] = biNum;
                    }
                }
            }
        }
    }

    private void fillInstructions()
    {
        instructions[0] = new DisplayInstruction(a: true, b: true, c: true, d: true, e: true, f: true);
        instructions[1] = new DisplayInstruction(b: true, c: true);
        instructions[2] = new DisplayInstruction(a: true, b: true, d: true, e: true, g: true);
        instructions[3] = new DisplayInstruction(a: true, b: true, c: true, d: true, g: true);
        instructions[4] = new DisplayInstruction(b: true, c: true, f: true, g: true);
        instructions[5] = new DisplayInstruction(a: true, c: true, d: true, f: true, g: true);
        instructions[6] = new DisplayInstruction(a: true, c: true, d: true, e: true, f: true, g: true);
        instructions[7] = new DisplayInstruction(a: true, b: true, c: true);
        instructions[8] = new DisplayInstruction(a: true, b: true, c: true, d: true, e: true, f: true, g: true);
        instructions[9] = new DisplayInstruction(a: true, b: true, c: true, d: true, f: true, g: true);
    }

    #endregion

    #region Displaying

    public void TurnOff()
    {
        for (int i = 0; i < 7; i++)
        {
            segments[i].TurnOff();
        }
    }

    /// <summary>
    /// Displays the number with the segments
    /// </summary>
    /// <param name="number">a number between 0 and 9</param>
    public void DisplayNumber(int number)
    {
        if (number < 0 || number > 9)
        {
            Debug.LogError("SevenSegmentDisplay.DisplayNumber() - can't display number: " + number);
            return;
        }

        displayByReasonableMethod(instructions[number]);
        //displayByRidiculousMethod(numbersToDisplay[number]);
    }

    private void displayByReasonableMethod(DisplayInstruction instruction)
    {
        for (int i = 0; i < 7; i++)
        {
            this.segments[i].on = instruction.segments[i];
        }
    }

    private void displayByRidiculousMethod(BinaryNumber num)
    {
        //segment A
        segments[0].on = (!num.A && !num.B && !num.D) || (!num.A && num.C) || (!num.A && num.B && num.D) || (num.A && !num.B && !num.C);

        //segment B
        segments[1].on = (!num.A && !num.B) || (!num.A && !num.C && !num.D) || (!num.A && num.C && num.D) || (num.A && !num.B && !num.C);

        //segment C
        segments[2].on = num.a || num.b || !num.c || num.d;

        //segment D
        segments[3].on = !(!num.a && (!num.b && !num.c && num.d || num.b && (!num.c && !num.d || num.c && num.d)));

        //segment E
        segments[4].on = (!num.a && !num.b && !num.d) || (!num.a && num.b && num.c && !num.d) || (num.a && !num.b && !num.c && !num.d);

        //segment F
        segments[5].on = (!num.A && !num.C && !num.D) || (!num.A && num.B && !num.C) || (!num.A && num.B && !num.D) || (num.A && !num.B && !num.C);

        //segment G
        segments[6].on = (!num.A && !num.B && num.C) || (!num.A && num.B && !num.C) || (!num.A && num.B && !num.D) || (num.A && !num.B && !num.C);
    }

    #endregion
}
