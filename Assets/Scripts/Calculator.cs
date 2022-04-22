using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace JuniperJackal
{
	public static class Calculator
	{
		private static readonly string[] operators = new string[] { "+", "-", "*", "/" };

		private static int Precedence(string value)
		{
			switch (value)
			{
				case "-":
				case "+": return 0;
				case "/":
				case "*": return 1;
				case "^": return 2;
				case "(":
				case ")": return 3;
				default: throw new System.ArgumentException("Invalid operator");
			}
		}

		private static float Apply(float a, float b, string op)
		{
			switch (op)
			{
				case "+": return a + b;
				case "-": return a - b;
				case "*": return a * b;
				case "/": return a / b;
				default: throw new System.ArgumentException("Invalid operator");
			}
		}

		private static bool IsOperator(string value)
		{
			return operators.Contains(value);
		}

		private static string SanitizeInput(string input)
		{
			var spaced = Regex.Replace(
				input,
				@"(\D)",
				@" $1 "
			);

			return Regex.Replace(
				spaced,
				@"\s+",
				@" "
			);
		}

		public static float Evaluate(string arithmetic)
		{
			var prefix = ToPostfix(SanitizeInput(arithmetic));
			var operands = new Stack<float>();

			while (prefix.TryDequeue(out string result))
			{
				if (float.TryParse(result, out float value))
				{
					operands.Push(value);
				}
				else
				{
					float a = operands.Pop();
					float b = operands.Pop();

					operands.Push(Apply(b, a, result));
				}
			}

			return operands.Pop();
		}

		// Shunting-yard algorithm
		private static Queue<string> ToPostfix(string input)
		{
			var output = new Queue<string>();
			var operators = new Stack<string>();
			var tokens = input.Split(' ');

			for (int i = 0; i < tokens.Length; i++)
			{
				var token = tokens[i];
				if (float.TryParse(token, out float value))
				{
					output.Enqueue(token);
				}
				else if (IsOperator(token))
				{
					while (operators.TryPeek(out string next) && IsOperator(next) && Precedence(next) >= Precedence(token))
					{
						output.Enqueue(operators.Pop());
					}

					operators.Push(token);
				}
				else if (token == "(")
				{
					operators.Push(token);
				}
				else if (token == ")")
				{
					var next = "";
					while (operators.TryPop(out next) && next != "(")
					{
						output.Enqueue(next);
					}
					if (next != "(") throw new System.ArgumentException("Mismatched parenthesis.");
				}
			}

			while (operators.Count > 0)
			{
				var token = operators.Pop();
				output.Enqueue(token);
			}

			return output;
		}

	}
}
