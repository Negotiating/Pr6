using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR6_1_2_WF
{
	public partial class Practic6 : Form
	{
		public Practic6()
		{
			InitializeComponent();
		}
		private bool is_three_digit(int num)
		{
			if (Math.Abs(num) < 1000 && Math.Abs(num) >= 100) return true;
			else return false;
		}
		private void count_TextChanged(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(count.Text);
			int[] array = new int[num];
			Random rand = new Random();
			int pr = 1;
			string rez = "";
			for (int i = 0; i < num; i++)
			{
				array[i] = rand.Next(-100, 100);
				pr *= array[i];
				rez += array[i] + " ";
			}
			mas.Text = rez;
			product.Text = pr.ToString();
			three_dig.Text = is_three_digit(pr).ToString();
		}

		private void count_KeyPress(object sender, KeyPressEventArgs e)
		{
			char symbol = e.KeyChar;
			if (!Char.IsDigit(symbol))
			{
				e.Handled = true;
			}
		}

		private void calculate_Click(object sender, EventArgs e)
		{
			int row = Convert.ToInt32(rows.Text);
			int column = Convert.ToInt32(columns.Text);
			int[,] arr = new int[row, column];
			array_tabel.RowCount = row;
			array_tabel.ColumnCount = column;
			Random rand = new Random();
			int pr2 = 1;
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < column; j++)
				{
					arr[i, j] = rand.Next(0, 10);
					pr2 *= arr[i, j];
					array_tabel.Columns[j].Width = 30;

					array_tabel.Rows[i].Cells[j].Value = arr[i, j];
				}
			}
			product2.Text = pr2.ToString();
			three.Text = is_three_digit(pr2).ToString();
		}

		private void diffrence_TextChanged(object sender, EventArgs e)
		{
			Random rand = new Random();
			int num = Convert.ToInt32(quantity.Text);
			int[] array = new int[num];
			int razn = Convert.ToInt32(diffrence.Text);
			int count = 0;
			string rez = "";
			for (int i = 0; i < num; i++)
			{
				array[i] = rand.Next(1, 5);
				rez += array[i].ToString() + " ";
			}
			array_.Text = rez;
			for (int i = 1; i < array.Length; i++)
			{
				if (Math.Abs(array[i] - array[i - 1]) == razn)
				{
					count++;
				}
			}
			rez_count.Text = count.ToString();
		}
		private bool contains(int[,] array)
		{
			int count = 0;
			for (int i = 0; i < array.GetLength(0); ++i)
			{
				Boolean isNegative = false;
				for (int j = 0; j < array.GetLength(1); j++)
				{
					if (array[i, j] < 0)
					{
						isNegative = true;
						break;
					}
				}
				if (!isNegative)
					count++;
			}
			if (count != 0) return true;
			else return false;
		}
		private void quantity3_TextChanged(object sender, EventArgs e)
		{
			int n = Convert.ToInt32(quantity3.Text);
			string str = "";
			try
			{
				if (n <= 0) throw new Exception("Недопустимый рвзмер массива");
				else
				{
					int[,] array = new int[n, n];
					Random rand = new Random();
					for (int i = 0; i < n; i++, str+="\n")
					{
						for (int j = 0; j < n; j++)
						{
							array[i, j] = rand.Next(-10, 10);
							str += array[i, j].ToString() + " ";
						}
					}
					array3_box.Text = str;
					positiv_box.Text = contains(array).ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			Console.ReadLine();
		}
		private int[][] Filling()
		{
			int n = Convert.ToInt32(quantity4_box.Text);
			try
			{
				if (n <= 0) throw new Exception();
			}
			catch
			{
				throw;
			}
			int[][] a = new int[n][];
			Random rand = new Random();
			for (int i = 0; i < n; ++i)
			{
				a[i] = new int[n];
				for (int j = 0; j < n; ++j)
				{
					a[i][j] = rand.Next(-10, 10);
				}
			}
			return a;
		}
		private void Print_sum(int[] array)
		{
			string str = "";
			for (int i = 0; i < array.Length; ++i)
				str += $"sum [{i}] = {array[i]} \n";
			sum_box.Text = str;
		}
		private void Print_array(int[][] a)
		{
			string str = "";
			for (int i = 0; i < a.Length; ++i, str+="\n")
				for (int j = 0; j < a[i].Length; ++j)
					str += $"{a[i][j]} ";
			array4_box.Text = str;
		}
		private int[] sum_array(int[][] array)
		{
			int[] sum = new int[array.Length];
			for (int i = 0; i < sum.Length; i++)
				sum[i] = 0;
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array[i].Length; j++)
				{
					sum[i] += array[i][j];
				}
			}
			return sum;
		}
		private void quantity4_box_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int[][] array = Filling();
				Print_array(array);
				Print_sum(sum_array(array));
				max_sum_box.Text = $"{sum_array(array).Max()}";
			}
			catch
			{
				MessageBox.Show("Некорректное значение");
			}
		}
	}
}
