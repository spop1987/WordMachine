public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(solution("4 5 6 - 7 +"));
    }

    public static List<int> stack = new List<int>();
    public static int solution(string S)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        var operations = S.Split(new[] { ' ' });
        short integerX = 0;
        foreach (var op in operations)
        {
            if (Int16.TryParse(op, out integerX))
            {
                stack.Add(integerX);
            }

            switch (op)
            {
                case "POP":
                    stack.Remove(GetTopMostFromStack());
                    break;

                case "DUP":
                    var number = GetTopMostFromStack();
                    stack.Add(number);
                    break;

                case "+":
                    var number1 = GetTopMostFromStack();
                    stack.Remove(number1);
                    var number2 = GetTopMostFromStack();
                    stack.Remove(number2);
                    stack.Add(number1 + number2);
                    break;

                case "-":
                    if(stack.Count > 1)
                    {
                        var number3 = GetTopMostFromStack();
                        stack.Remove(number3);
                        var number4 = GetTopMostFromStack();
                        stack.Remove(number4);
                        stack.Add(number3 - number4);
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                default:
                    break;
            }
        }

        return GetTopMostFromStack();
    }

    public static int GetTopMostFromStack()
    {
        return stack.Last();
    }

}