
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace OOP_2
{
	public class Cell : DataGridViewCell
	{
		public string Name;
		public bool Ok = true;
		public List<string> depend = new List<string>();
		public string Expression;
		public new int ColumnIndex;
		public new int RowIndex;
		
		public Cell(string a, int index, int jndex)
		{
			ValueType = typeof(string);
			Value = "";
			Expression = "";
			Name = a;
			ColumnIndex = index;
			RowIndex = jndex;
		}
		public string Parse(string nameCell)
		{
			var parser = new Parser();
			try
			{
				Value = parser.Parse(Expression, nameCell);
				Ok = true;
				
			}
			catch (Exception ex)
			{
				Ok = false;
				throw ex;
			}
		/*	finally
			{
				int index = 0;
				for (index = 0; index < Expression.Length; index++)
				{
					if (parser.Cell(Expression, index, out string cell))
					{
						if (Inicialize.Search(cell, out int i, out int j))
							Inicialize.cells[i, j].depend.Add(this.Name);
						index += cell.Length;
					}
				}
			}*/
			return Value.ToString();
		}
		public string ParseIn(string nameCell)
		{
			var parser = new Parser();
			try
			{
				Value = parser.Parse(Expression, nameCell);
				Ok = true;
				return Value.ToString();
			}
			catch (Exception ex)
			{
				Ok = false;
				throw ex;
			}
		}
	}
}
