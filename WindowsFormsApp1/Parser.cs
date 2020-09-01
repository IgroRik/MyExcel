using OOP_2;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
	class Parser
	{
		Dictionary<string, int> Distionary { get; } = new Dictionary<string, int>{
			{ "+" , 1 },
			{ "-" , 1 },
			{ "*" , 2 },
			{ "/" , 2 },
			{ "^" , 3 },
			{ "min" , 3 },
			{ "max" , 3 },
			{ "inc" , 3 },
			{ "dec" , 3 },
			{ ";" , 0 },
		};


		private bool Number(string a, int index, out double value)
		{
			var f = false;
			var d = false;
			string res = "";
			a += " ";

			while (!f)
			{
				if (a[index] - 48 <= 9 && a[index] - 48 >= 0 || (a[index] == ',' && !d))
				{
					if (a[index] == ',')
						d = true;
					res += a[index];
					index++;
				}
				else f = true;
			}
			if (res == "" || res == "-")
			{
				value = 0.0;
				return false;
			}
			value = Convert.ToDouble(res);
			return true;
		}
		private bool Func(string a, int index, out string operation)
		{
			if (a[index] == '+' || a[index] == '-' || a[index] == '*' || a[index] == '/'
				|| a[index] == '^' || a[index] == '(' || a[index] == ')')
			{
				operation = a[index].ToString();
				return true;
			}
			operation = null;
			return false;
		}
		public bool Cell(string a, int index, out string cell)
		{
			cell = "";
			a += " ";
			while (a[index] >= 65 && a[index] <= 90)
			{
				cell += a[index];
				index++;
			}
			if (cell == "")
			{
				return false;
			}
			while (a[index] >= 48 && a[index] <= 57)
			{
				cell += a[index];
				index++;
			}
			foreach (Cell c in Inicialize.cells)
			{
				if (c.Name == cell)
				{
					return true;
				}
			}
			return false;
		}

		public string Parse(string formula, string nameCell)
		{
			try
			{
				formula = formula.Trim();
				if (formula.Length != 0)
					if (formula[0] == '=')
					{
						formula = formula.Replace(" ", "");
						formula = formula.Remove(0, 1);
						formula = ParseC(formula, nameCell);
						formula = formula.Replace(" ", "");
						formula = formula.ToLower();
						formula = ParseF(formula);
						formula = ParseV(formula);
						return formula;
					}
				return formula;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		private bool TryParseF(string formula)
		{
			if (formula.Contains("min")) return true;
			if (formula.Contains("max")) return true;
			if (formula.Contains("inc")) return true;
			if (formula.Contains("dec")) return true;
			return false;
		}
		private bool TryParseV(string formula)
		{
			if (ParseV(formula) != null)
				return true;
			else
				return false;

		}
		private string ParseF(string formula)
		{
			while (formula.Contains("min"))
			{
				int ind = formula.IndexOf("min");
				formula = Parametrs(formula, ind, out string func1, out string func2);

				if (TryParseF(func1))
					func1 = ParseF(func1);
				if (TryParseF(func2))
					func2 = ParseF(func2);

				if (TryParseV(func1) && TryParseV(func2))
				{
					func1 = ParseV(func1);
					func2 = ParseV(func2);
					var tm = Calc(Convert.ToDouble(func1), Convert.ToDouble(func2), "min");
					formula = formula.Insert(ind, tm.ToString());
				}

			}
			while (formula.Contains("max"))
			{
				int ind = formula.IndexOf("max");
				formula = Parametrs(formula, ind, out string func1, out string func2);

				if (TryParseF(func1))
					func1 = ParseF(func1);
				if (TryParseF(func2))
					func2 = ParseF(func2);

				if (TryParseV(func1) && TryParseV(func2))
				{
					func1 = ParseV(func1);
					func2 = ParseV(func2);
					var tm = Calc(Convert.ToDouble(func1), Convert.ToDouble(func2), "max");
					formula = formula.Insert(ind, tm.ToString());
				}

			}
			while (formula.Contains("inc"))
			{
				int ind = formula.IndexOf("inc");
				formula = Parametrs(formula, ind, out string func1);
				if (TryParseF(func1))
					func1 = ParseF(func1);
				if (TryParseV(func1))
				{
					func1 = ParseV(func1);
					var tm = (Convert.ToDouble(func1) + 1.0).ToString();
					formula = formula.Insert(ind, tm.ToString());
				}
			}
			while (formula.Contains("dec"))
			{
				int ind = formula.IndexOf("dec");
				formula = Parametrs(formula, ind, out string func1);
				if (TryParseF(func1))
					func1 = ParseF(func1);
				if (TryParseV(func1))
				{
					func1 = ParseV(func1);
					var tm = (Convert.ToDouble(func1) - 1.0).ToString();
					formula = formula.Insert(ind, tm.ToString());
				}
			}

			return formula;

		}
		private string ParseV(string formyla)
		{
			try
			{
				Stack<double> val = new Stack<double>();
				Stack<string> op = new Stack<string>();
				void Step()
				{
					if (val.Count >= 2 && Distionary[op.Peek()] >= 1)
					{
						var a = val.Pop();
						var b = val.Pop();
						var c = op.Pop();
						var res = Calc(b, a, c);
						val.Push(res);
					}
					else throw (new Exception("Don`t have operation or value in stack"));
				}
				bool f = false;
				bool f1 = false;
				for (int i = 0; i < formyla.Length; i++)
				{
					if (formyla[i] == '-' && (f1 || val.Count == 0) && Number(formyla, i + 1, out double value))
					{
						val.Push(-1 * value);
						var c = value.ToString();
						i += c.Length;
						f = false;
						f1 = false;
						continue;
					}
					if (formyla[i] == '+' && (f1 || val.Count == 0) && Number(formyla, i + 1, out double value1))
					{
						i++;
						val.Push(value1);
						var c = value1.ToString();
						i += c.Length - 1;
						f = false;
						f1 = false;
						continue;
					}
					if (Number(formyla, i, out double num))
					{
						val.Push(num);
						var c = num.ToString();
						i += c.Length - 1;
						f = false;
						f1 = false;
						continue;
					}
					if (Func(formyla, i, out string oprand))
					{
						if (f && oprand != "(") throw new Exception("More than one operation");
						else
						{
							f = true;
							while (true)
							{
								if (op.Count == 0 || oprand == "(")
								{
									if (oprand == "(")
									{
										f1 = true;
										f = false;
									}
									op.Push(oprand);
									break;
								}
								if (oprand == ")")
								{
									while (true)
										try
										{
											f = false;
											f1 = false;
											Step();
										}
										catch { break; }
									if (op.Peek() == "(" && oprand == ")")
									{
										op.Pop();
										f = false;
										f1 = false;
										break;
									}
								}
								if (op.Peek() == "(" || Distionary[oprand] > Distionary[op.Peek()])
								{
									op.Push(oprand);
									break;
								}
								try
								{
									Step();
								}
								catch { break; }
							}
						}
					}
					else
						throw new Exception("Not a number or function");
				}
				while (true)
					try
					{
						Step();
					}
					catch { break; }

				if (val.Count == 1 && op.Count == 0)
					return val.Pop().ToString();
				else
					throw new Exception("Wrong expression");
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
		private string ParseC(string formyla, string nameCell)
		{
			var Root = new List<string>();
			Root.Add(nameCell);
			for (int i = 0; i < formyla.Length;)
			{
				if (Cell(formyla, i, out string cell))
				{
					if (Root.Contains(cell))
						throw new Exception("Circle");
					Root.Add(cell);
					formyla = formyla.Remove(i, cell.Length);
					Inicialize.Search(cell, out int index, out int jndex);
					string exp = Inicialize.cells[index, jndex].Expression;
					exp = exp.Replace(" ", "");
					if (exp[0] == '=')
						exp = exp.Remove(0, 1);
					exp = "(" + exp + ")";
					formyla = formyla.Insert(i, exp);
				}
				else
				{
					i++;
				}
			}
			return formyla;
		}

		private double Calc(double a, double b, string operation)
		{
			switch (operation)
			{
				case "+": return (a + b);
				case "-": return (a - b);
				case "*": return (a * b);
				case "/": if (b != 0.0) return (a / b); else throw new Exception("Деление на ноль");
				case "^": return Math.Pow(a, b);
				case "min": return Math.Min(a, b);
				case "max": return Math.Max(a, b);
				default: throw new Exception("Unknown operation!");
			}
		}
		private string Parametrs(string formula, int ind, out string func1, out string func2)
		{
			int c = 0;
			int i = ind + 4;
			while (formula[i] != ';' || c != 0)
			{
				if (formula[i] == '(')
					c++;
				if (formula[i] == ')')
					c--;
				i++;
			}
			c = 1;
			int i2 = i;
			while (c != 0)
			{
				if (formula[i2] == '(')
					c++;
				if (formula[i2] == ')')
					c--;
				i2++;
			}

			func1 = formula.Substring(ind + 4, i - ind - 4);
			func2 = formula.Substring(i + 1, i2 - i - 2);
			formula = formula.Remove(ind, i2 - ind);

			return formula;
		}
		private string Parametrs(string formula, int ind, out string func1)
		{
			int c = 1;
			int i = ind + 4;
			while (c != 0)
			{
				if (formula[i] == '(')
					c++;
				if (formula[i] == ')')
					c--;
				i++;
			}
			i--;
			func1 = formula.Substring(ind + 4, i - ind - 4);
			formula = formula.Remove(ind, i - ind + 1);

			return formula;
		}

	}
}
