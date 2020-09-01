using OOP_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var init = new Inicialize();
			dataGridView1.ColumnCount = Info.ColumnCount;
			dataGridView1.RowCount = Info.RowCount;
			init.New();
			foreach (DataGridViewColumn c in dataGridView1.Columns)
			{
				c.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			FullUpdateGrid();
		}
		private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
				Inicialize.cells[e.ColumnIndex, e.RowIndex].Expression = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
			else
				Inicialize.cells[e.ColumnIndex, e.RowIndex].Expression = "";
			try
			{
				var a = new DataGridViewCellStyle();
				dataGridView1[e.ColumnIndex, e.RowIndex].Style = a;
				UpdateCell(Inicialize.cells[e.ColumnIndex, e.RowIndex].Name);

			}
			catch (Exception ex)
			{
				var a = new DataGridViewCellStyle();
				a.BackColor = Color.Red;
				dataGridView1[e.ColumnIndex, e.RowIndex].Style = a;
				dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = ex.Message;
				dataGridView1[e.ColumnIndex, e.RowIndex].Value = "????";
			}
			UpdateGrid();
		}
		private void FullUpdateGrid()
		{
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				dataGridView1.Columns[i].HeaderText = To26Sys.TO(i);
				for (int j = 0; j < Info.RowCount; j++)
				{
					UpdateCell(Inicialize.cells[i, j].Name);
				}
			}
			for (int i = 0; i < Info.RowCount; i++)
				dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
		}
		private void UpdateGrid()
		{
			for (int i = 0; i < Info.ColumnCount; i++)
			{
				for (int j = 0; j < Info.RowCount; j++)
				{
					UpdateCell(Inicialize.cells[i, j].Name);
				}
			}
		}
		private void UpdateGrid(bool f)
		{
			if (!f)
			{
				for (int i = 0; i < Info.ColumnCount; i++)
				{
					for (int j = 0; j < Info.RowCount; j++)
					{
						dataGridView1[i, j].Value = Inicialize.cells[i, j].Value;
					}
				}
			}
			else
			{
				for (int i = 0; i < Info.ColumnCount; i++)
				{
					for (int j = 0; j < Info.RowCount; j++)
					{
						dataGridView1[i, j].Value = Inicialize.cells[i, j].Expression;
					}
				}
			}
		}
		private void UpdateCell(string name)
		{
			Inicialize.Search(name, out int i, out int j);
			try
			{
				//-------------------------
				var parser = new Parser();
				for (int index = 0; index < Inicialize.cells[i, j].Expression.Length; index++)
				{
					if (parser.Cell(Inicialize.cells[i, j].Expression, index, out string cell))
					{
						if (cell == name)
						{
							throw new Exception("Call this cell");
						}
					}
				}

				//-------------------------
				Inicialize.cells[i, j].Value = Inicialize.cells[i, j].Parse(Inicialize.cells[i, j].Name);
				var a = new DataGridViewCellStyle();
				dataGridView1[i, j].Style = a;

				if (!ShowExpression.Checked)
					dataGridView1[i, j].Value = Inicialize.cells[i, j].Value;
				else
					dataGridView1[i, j].Value = Inicialize.cells[i, j].Expression;
			}
			catch (Exception ex)
			{
				var a = new DataGridViewCellStyle();
				a.BackColor = Color.Red;
				dataGridView1[i, j].Style = a;
				dataGridView1[i, j].Value = ex.Message;
			}
			/*finally
			{
				List<string> root = new List<string>();
			//	root.Add(name);
				foreach (var item in Inicialize.cells[i, j].depend)
				{
					try
					{
						UpdateCellIn(item, root);
					}
					catch(Exception ex)
					{
						throw ex;
					}
				}
			}*/
		}
		/*private void UpdateCellIn(string name, List<string> root)
		{
			Inicialize.Search(name, out int i, out int j);
			try
			{
				Inicialize.cells[i, j].Value = Inicialize.cells[i, j].ParseIn(Inicialize.cells[i, j].Name);
				var a = new DataGridViewCellStyle();
				dataGridView1[i, j].Style = a;

				if (!ShowExpression.Checked)
					dataGridView1[i, j].Value = Inicialize.cells[i, j].Value;
				else
					dataGridView1[i, j].Value = Inicialize.cells[i, j].Expression;
			}
			catch (Exception ex)
			{
				var a = new DataGridViewCellStyle();
				a.BackColor = Color.Red;
				dataGridView1[i, j].Style = a;
				dataGridView1[i, j].Value = ex.Message;
			}
			finally
			{
				foreach (var item in Inicialize.cells[i, j].depend)
				{
					if (root.Contains(name))
					{ throw new Exception("Circle"); }
					root.Add(name);
					UpdateCellIn(item, root);
				}
			}
		}
	*/

		private void ToolStripButton1_Click(object sender, EventArgs e)
		{
			var file = new File();
			file.Save();
		}

		private void ToolStripButton4_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex]);
		}

		private void ToolStripButton2_Click(object sender, EventArgs e)
		{
			var file = new File();
			try
			{
				file.Open();
				FullUpdateGrid();
			}
			catch { }
		}

		private void ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ShowExpression.Checked = !ShowExpression.Checked;
			UpdateGrid(ShowExpression.Checked);
		}

		private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			dataGridView1[e.ColumnIndex, e.RowIndex].Value = Inicialize.cells[e.ColumnIndex, e.RowIndex].Expression;
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var file = new File();
			file.Save();
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Ви маєте не зберіжені дані. Продовжити?", "Відкрити", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.OK)
			{
				var file = new File();
				try
				{
					if (file.Open())
						SaveMenuButton.Enabled = true;
					dataGridView1.ColumnCount = Info.ColumnCount;
					dataGridView1.RowCount = Info.RowCount;
					FullUpdateGrid();
				}
				catch { MessageBox.Show("Ошибка при відкритті"); }
			}
		}

		private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateGrid();
			UpdateGrid(ShowExpression.Checked);
		}

		private void CreateMenuButton_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Впевнені?", "Створити", MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				Info.PATH = null;
				SaveMenuButton.Enabled = false;
				dataGridView1.Enabled = false;
				dataGridView1.ClearSelection();
				dataGridView1.CurrentCell = null;
				Form1_Load(sender, e);
				UpdateGrid();
				dataGridView1.CurrentCell = dataGridView1[0, 0];
				dataGridView1.Enabled = true;
			}
		}

		private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var file = new File();
			if (file.SaveAs())
				SaveMenuButton.Enabled = true;
		}

		private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult dr = MessageBox.Show("Все зберігли?", "Вихід", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
			{
				e.Cancel = true;
			}
		}

		private void AddColumn_Click(object sender, EventArgs e)
		{
			dataGridView1.Columns.Add(To26Sys.TO(Info.ColumnCount), To26Sys.TO(Info.ColumnCount));
			Inicialize.AddColumn(dataGridView1.SelectedCells[0].ColumnIndex);
			Inicialize.UpdateDependencesColumnAdded(dataGridView1.SelectedCells[0].ColumnIndex);
			FullUpdateGrid();
			ShowExpression.Checked = false;
		}

		private void AddRowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Add();
			Inicialize.AddRow(dataGridView1.SelectedCells[0].RowIndex);
			Inicialize.UpdateDependencesRowAdded(dataGridView1.SelectedCells[0].RowIndex);
			FullUpdateGrid();
			ShowExpression.Checked = false;
		}

		private void DeleteColumn_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Впевнені?", "Видалити стовпчик", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.OK)
			{
				if (Info.ColumnCount > 1)
				{
					dataGridView1.Columns.RemoveAt(Info.ColumnCount - 1);
					Inicialize.DeleteColumn(dataGridView1.SelectedCells[0].ColumnIndex);
					Inicialize.UpdateDependencesColumnDeleted(dataGridView1.SelectedCells[0].ColumnIndex);
					FullUpdateGrid();
					ShowExpression.Checked = false;
				}
				else
					MessageBox.Show("Не можна видалити останній стовпчик!", "Обережно!");
			}
		}

		private void DeleteRow_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Впевнені?", "Видалити строку", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.OK)
			{
				if (Info.RowCount > 1)
				{
					dataGridView1.Rows.RemoveAt(Info.RowCount - 1);
					Inicialize.DeleteRow(dataGridView1.SelectedCells[0].RowIndex);
					Inicialize.UpdateDependencesRowDeleted(dataGridView1.SelectedCells[0].RowIndex);
					FullUpdateGrid();
					ShowExpression.Checked = false;
				}
				else
					MessageBox.Show("Не можна видалити останню строку!", "Обережно!");
			}
		}

		private void допомогаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Лабораторна робота №2 на тему \"Ексель\". Виконано студентом К-26 Дуйловським Ігорем \n." +
				"Дана програма може обраблювати вирази зі значеннями * та змінювати таблицю з діями **. \n " +
				"* Дії: +, -, *, /, ^\n" +
				"Функції: min(;), max(;), inc(), dec(), зі значеннями менше 1е6\n" +
				"**Дії з таблицею: Додати/видалити строку/стовбець\n" +
				"Створити нову таблицю, зберегти або відкрити існуючу.", "Опис", MessageBoxButtons.OK);
		}
	}
}
