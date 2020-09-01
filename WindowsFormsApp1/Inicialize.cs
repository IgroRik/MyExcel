using OOP_2;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	class Inicialize
	{
		public static Cell[,] cells = new Cell[Info.ColumnCount, Info.RowCount];
		public void New()
		{
			var dataGridView1 = new DataGridView();

			dataGridView1.ColumnCount = Info.ColumnCount;
			dataGridView1.RowCount = Info.RowCount;

			for (int i = 0; i < Info.ColumnCount; i++)
			{
				for (int j = 0; j < Info.RowCount; j++)
				{
					var a = new Cell(To26Sys.TO(i) + (j + 1).ToString(), i, j);
					a.Name = To26Sys.TO(i) + (j + 1).ToString();
					cells[i, j] = a;
					dataGridView1[i, j].Value = cells[i, j].Value;
				}
			}
		}
		public static bool Search(string name, out int i, out int j)
		{
			foreach(Cell c in cells)
			{
				if (c.Name == name)
				{
					i = c.ColumnIndex;
					j = c.RowIndex;
					return true;
				}
			}
			i = -1; j = -1;
			return false;
		}
		public static void AddRow(int index)
		{
			Info.RowCount++;
			
			var a = new Cell[Info.ColumnCount, Info.RowCount - 1];
			//--------------------Copy of cells-----------------------//
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				for (int j = 0; j < Info.RowCount - 1; j++)
				{
					a[i, j] = new Cell(Inicialize.cells[i, j].Name, i, j);
					a[i, j].Value = Inicialize.cells[i, j].Value;
					a[i, j].Expression = Inicialize.cells[i, j].Expression;
				}
			}
			//#-----------------------Upgrade-cells---------------------//
			Inicialize.cells = new Cell[Info.ColumnCount, Info.RowCount];
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				for (int j = 0; j < Info.RowCount - 1; j++)
				{
					Inicialize.cells[i, j] = new Cell(a[i, j].Name, i, j);
					Inicialize.cells[i, j].Value = a[i, j].Value;
					Inicialize.cells[i, j].Expression = a[i, j].Expression;
				}
			}
			//-------------------------Name last row---------------------------------//
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				Inicialize.cells[i, Info.RowCount - 1] = new Cell(To26Sys.TO(i) + (Info.RowCount).ToString(), i, Info.RowCount - 1);
			}
			//----------------------------Cdvig----------------------------------------//
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				for (int j = Info.RowCount - 1; j >= index + 1; j--)
				{
					Inicialize.cells[i, j].Expression = Inicialize.cells[i, j - 1].Expression;
				}
			}
			//---------------------------Clear start row--------------------//
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				Inicialize.cells[i,index].Value = "";
				Inicialize.cells[i, index].Expression = "";
			}
		}
		public static void AddColumn(int index)
		{
			Info.ColumnCount++;
			
			var a = new Cell[Info.ColumnCount - 1, Info.RowCount];
			//--------------------Copy of cells-----------------------//
			for (int i = 0; i < Info.ColumnCount - 1; i++)
			{
				for (int j = 0; j < Info.RowCount; j++)
				{
					a[i, j] = new Cell(Inicialize.cells[i, j].Name, i, j);
					a[i, j].Value = Inicialize.cells[i, j].Value;
					a[i, j].Expression = Inicialize.cells[i, j].Expression;
				}
			}
			//#-----------------------Upgrade-cells---------------------//
			Inicialize.cells = new Cell[Info.ColumnCount, Info.RowCount];
			for (int i = 0; i < Info.ColumnCount - 1; i++)
			{
				for (int j = 0; j < Info.RowCount; j++)
				{
					Inicialize.cells[i, j] = new Cell(a[i, j].Name, i, j);
					Inicialize.cells[i, j].Value = a[i, j].Value;
					Inicialize.cells[i, j].Expression = a[i, j].Expression;
				}
			}
			//-------------------------Name last col---------------------------------//
			for (int i = 0; i < Info.RowCount; i++)
			{
				Inicialize.cells[Info.ColumnCount - 1, i] = new Cell(To26Sys.TO(Info.ColumnCount) + (i + 1).ToString(), Info.ColumnCount - 1, i);
			}
			//----------------------------Cdvig----------------------------------------//
			for (int i = 0; i < Info.RowCount; i++)
			{
				for (int j = Info.ColumnCount - 1; j >= index + 1; j--)
				{
					Inicialize.cells[j, i].Expression = Inicialize.cells[j - 1, i].Expression;
				}
			}
			//---------------------------Clear start col--------------------//
			for (int i = 0; i < Info.RowCount; i++)
			{
				Inicialize.cells[index, i].Value = "";
				Inicialize.cells[index, i].Expression = "";
			}
		}
		public static void DeleteRow(int index)
		{
			Info.RowCount--;

			var a = new Cell[Info.ColumnCount, Info.RowCount + 1];
			//--------------------Copy of cells-----------------------//
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				for (int j = 0; j < Info.RowCount + 1; j++)
				{
					a[i, j] = new Cell(Inicialize.cells[i, j].Name, i, j);
					a[i, j].Value = Inicialize.cells[i, j].Value;
					a[i, j].Expression = Inicialize.cells[i, j].Expression;
				}
			}
			//------------------------Sdvig--------------------------//
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				for (int j = index; j < Info.RowCount; j++)
				{
					a[i, j].Expression = a[i, j + 1].Expression;
				}
			}
			//#-----------------------Upgrade-cells---------------------//
			Inicialize.cells = new Cell[Info.ColumnCount, Info.RowCount];
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				for (int j = 0; j < Info.RowCount; j++)
				{
					Inicialize.cells[i, j] = new Cell(a[i, j].Name, i, j);
					Inicialize.cells[i, j].Expression = a[i, j].Expression;
				}
			}
		}
		public static void DeleteColumn(int index)
		{
			Info.ColumnCount--;

			var a = new Cell[Info.ColumnCount + 1, Info.RowCount];
			//--------------------Copy of cells-----------------------//
			for (int i = 0; i < Info.ColumnCount + 1; i++)
			{
				for (int j = 0; j < Info.RowCount; j++)
				{
					a[i, j] = new Cell(Inicialize.cells[i, j].Name, i, j);
					a[i, j].Value = Inicialize.cells[i, j].Value;
					a[i, j].Expression = Inicialize.cells[i, j].Expression;
				}
			}
			//------------------------Sdvig--------------------------//
			for (int i = index; i < Info.ColumnCount; i++)
			{
				for (int j = 0; j < Info.RowCount; j++)
				{
					a[i, j].Expression = a[i + 1, j].Expression;
				}
			}
			//#-----------------------Upgrade-cells---------------------//
			Inicialize.cells = new Cell[Info.ColumnCount, Info.RowCount];
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				for (int j = 0; j < Info.RowCount; j++)
				{
					Inicialize.cells[i, j] = new Cell(a[i, j].Name, i, j);
					Inicialize.cells[i, j].Expression = a[i, j].Expression;
				}
			}
		}
		public static void UpdateDependencesRowAdded(int RowIndex)
		{
			foreach(Cell c in cells)
			{
				var parser = new Parser();
				for (int i = 0; i < c.Expression.Length; i++)
				{
					if (parser.Cell(c.Expression, i, out string cell))
					{
						if (Search(cell, out int index, out int jndex) && jndex >= RowIndex)
						{
							c.Expression = c.Expression.Remove(i, cell.Length);
							c.Expression = c.Expression.Insert(i, NextCell(cell, false));
							i += NextCell(cell, false).Length;
						}
					}
				}
			}
		}
		public static void UpdateDependencesColumnAdded(int ColumnIndex)
		{
			foreach (Cell c in cells)
			{
				var parser = new Parser();
				for (int i = 0; i < c.Expression.Length; i++)
				{
					if (parser.Cell(c.Expression, i, out string cell))
					{
						if (Search(cell, out int index, out int jndex) && index >= ColumnIndex)
						{
							c.Expression = c.Expression.Remove(i, cell.Length);
							c.Expression = c.Expression.Insert(i, NextCell(cell, true));
							i += NextCell(cell, true).Length;
						}
					}
				}
			}
		}
		public static void UpdateDependencesRowDeleted(int RowIndex)
		{
			foreach (Cell c in cells)
			{
				var parser = new Parser();
				for (int i = 0; i < c.Expression.Length; i++)
				{
					if (parser.Cell(c.Expression, i, out string cell))
					{
						if (Search(cell, out int index, out int jndex) && jndex >= RowIndex)
						{
							c.Expression = c.Expression.Remove(i, cell.Length);
							c.Expression = c.Expression.Insert(i, PreviousCell(cell, false));
							i += PreviousCell(cell, false).Length;
						}
					}
				}
			}
		}
		public static void UpdateDependencesColumnDeleted(int ColumnIndex)
		{
			foreach (Cell c in cells)
			{
				var parser = new Parser();
				for (int i = 0; i < c.Expression.Length; i++)
				{
					if (parser.Cell(c.Expression, i, out string cell))
					{
						if (Search(cell, out int index, out int jndex) && index >= ColumnIndex)
						{
							c.Expression = c.Expression.Remove(i, cell.Length);
							c.Expression = c.Expression.Insert(i, PreviousCell(cell, true));
							i += PreviousCell(cell, true).Length;
						}
					}
				}
			}
		}

		private static string NextCell(string cell, bool IsRow)
		{
			if (IsRow)
			{
				string cellRes = "";
				cell += " ";
				int index = 0;
				while (cell[index] >= 65 && cell[index] <= 90)
				{
					cellRes += cell[index];
					index++;
				}
				cellRes = To26Sys.TO(To26Sys.FROM(cellRes) + 1);
				while (cell[index] >= 48 && cell[index] <= 57)
				{
					cellRes += cell[index];
					index++;
				}
				return cellRes;
			}
			else
			{
				string cellRes = "";
				cell += " ";
				int index = 0;
				while (cell[index] >= 65 && cell[index] <= 90)
				{
					cellRes += cell[index];
					index++;
				}
				
				string cellRes1 = "";
				while (cell[index] >= 48 && cell[index] <= 57)
				{
					cellRes1 += cell[index];
					index++;
				}
				cellRes += (Convert.ToInt32(cellRes1) + 1).ToString();
				return cellRes;
			}
		}
		private static string PreviousCell(string cell, bool IsRow)
		{
			if (IsRow)
			{
				string cellRes = "";
				cell += " ";
				int index = 0;
				while (cell[index] >= 65 && cell[index] <= 90)
				{
					cellRes += cell[index];
					index++;
				}
				cellRes = To26Sys.TO(To26Sys.FROM(cellRes) - 1);
				while (cell[index] >= 48 && cell[index] <= 57)
				{
					cellRes += cell[index];
					index++;
				}
				return cellRes;
			}
			else
			{
				string cellRes = "";
				cell += " ";
				int index = 0;
				while (cell[index] >= 65 && cell[index] <= 90)
				{
					cellRes += cell[index];
					index++;
				}

				string cellRes1 = "";
				while (cell[index] >= 48 && cell[index] <= 57)
				{
					cellRes1 += cell[index];
					index++;
				}
				cellRes += (Convert.ToInt32(cellRes1) - 1).ToString();
				return cellRes;
			}
		}
	}
}
