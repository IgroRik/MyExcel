using OOP_2;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	class File
	{
		public bool SaveAs()
		{
			StreamWriter myStream;
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.Filter = "DataGridView files (*.dgv)|*.dgv|All files (*.*)|*.*";
			saveFileDialog1.FilterIndex = 1;
			saveFileDialog1.RestoreDirectory = true;
			saveFileDialog1.DefaultExt = ".dvg";

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				myStream = new StreamWriter(saveFileDialog1.OpenFile());
				if (myStream != null)
				{
					myStream.WriteLine(Info.ColumnCount + " " + Info.RowCount);
					for (int i = 0; i < Info.ColumnCount; i++)
					{
						for (int j = 0; j < Info.RowCount; j++)
						{
							myStream.WriteLine(Inicialize.cells[i, j].Value);
							myStream.WriteLine(Inicialize.cells[i, j].Expression);
						}
					}
					myStream.Flush();
					myStream.Close();
					Info.PATH = saveFileDialog1.FileName;
					saveFileDialog1.Dispose();
					myStream.Dispose();
					return true;
				}
			}
			return false;
		}
		public bool Save()
		{
			StreamWriter myStream;
				myStream = new StreamWriter(Info.PATH);
				if (myStream != null)
				{
					myStream.WriteLine(Info.ColumnCount + " " + Info.RowCount);
					for (int i = 0; i < Info.ColumnCount; i++)
					{
						for (int j = 0; j < Info.RowCount; j++)
						{
							myStream.WriteLine(Inicialize.cells[i, j].Value);
							myStream.WriteLine(Inicialize.cells[i, j].Expression);
						}
					}
					myStream.Flush();
					myStream.Close();
					myStream.Dispose();
					return true;
				}
			
			return false;
		}
		public bool Open()
		{
			StreamReader myStream;
			OpenFileDialog saveFileDialog1 = new OpenFileDialog();

			saveFileDialog1.Filter = "DataGridView files (*.dvg)|*.dvg|All files (*.*)|*.*";
			saveFileDialog1.FilterIndex = 2;
			saveFileDialog1.RestoreDirectory = true;
			saveFileDialog1.DefaultExt = "dvg";
			saveFileDialog1.CheckPathExists = true;
			saveFileDialog1.CheckFileExists = true;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				myStream = new StreamReader(saveFileDialog1.OpenFile());

				if (myStream != null)
				{
					string c;
					c = myStream.ReadLine();
					string[] a = new string[2];
					a = c.Split(' ');
					Info.ColumnCount = Convert.ToInt32(a[0]);
					Info.RowCount = Convert.ToInt32(a[1]);
					Inicialize.cells = new Cell[Info.ColumnCount, Info.RowCount];
					for (int i = 0; i < Info.ColumnCount; i++)
					{
						for (int j = 0; j < Info.RowCount; j++)
						{
							var b = new Cell(To26Sys.TO(i) + (j + 1).ToString(), i, j);
							b.Value = myStream.ReadLine();
							b.Expression = myStream.ReadLine();
							Inicialize.cells[i, j] = b;
						}
					}
					Info.PATH = saveFileDialog1.FileName;
					myStream.Close();
					myStream.Dispose();
					saveFileDialog1.Dispose();
					return true;
				}
			}
			return false;
		}
	}
}
