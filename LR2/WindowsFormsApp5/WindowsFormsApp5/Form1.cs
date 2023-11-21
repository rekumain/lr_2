using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.InitialDirectory =
               Environment.CurrentDirectory;
                string path = saveFileDialog1.FileName;
                try
                {
                    StreamWriter potok_zap = new StreamWriter(path,
                    false, Encoding.Default);
                    potok_zap.WriteLine(textBox1.Text);

                    potok_zap.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка доступа к файлу" +
                    exc.ToString(), "Текстовый редактор", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                this.Text = "Сохранение" + Path.GetFileName(path);
                textBox1.Modified = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Количество набранных символов = " + textBox1.TextLength.ToString();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory =
               Environment.CurrentDirectory;
                string path = openFileDialog1.FileName;
                try
                {

                    StreamReader p = new StreamReader(path,
                    Encoding.Default);

                    textBox1.Text = p.ReadToEnd();
                    p.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка чтения" +
                    exc.ToString(), "Текстоввый редактор", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                this.Text = "Открытие файла... " + Path.GetFileName(path);
                openFileDialog1.FileName = string.Empty;

                textBox1.SelectionStart = textBox1.TextLength;
            }
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            this.Text = "Новый документ";
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                if (!textBox1.Font.Equals(fontDialog1.Font))
                {
                    Font f = textBox1.Font;
                    textBox1.Font = fontDialog1.Font;
                    f.Dispose();
                }
        }

        private void выравниваниеТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поЛевомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Left;
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void поПравомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Right;
        }

        private void жирныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem курсивItem = sender as ToolStripMenuItem;

            if (курсивItem != null)
            {
                курсивItem.Checked = !курсивItem.Checked;
                toolStripButton8.Checked = курсивItem.Checked;

                ОбновитьСтильШрифта();
            }
            ToolStripMenuItem подчеркнутыйItem = sender as ToolStripMenuItem;

            if (подчеркнутыйItem != null)
            {
                подчеркнутыйItem.Checked = !подчеркнутыйItem.Checked;
                toolStripButton9.Checked = подчеркнутыйItem.Checked;

                ОбновитьСтильШрифта();
            }
        }

        private void цветШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textBox1.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                textBox1.ForeColor = colorDialog1.Color;
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textBox1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                textBox1.BackColor = colorDialog1.Color;
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText=" ";
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void курсивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem подчеркнутыйItem = sender as ToolStripMenuItem;

            if (подчеркнутыйItem != null)
            {
                подчеркнутыйItem.Checked = !подчеркнутыйItem.Checked;
                toolStripButton9.Checked = подчеркнутыйItem.Checked;

                ОбновитьСтильШрифта();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text =
            IsKeyLocked(Keys.CapsLock) ? "Caps Lock включён" : "";
            toolStripStatusLabel2.Text =
            DateTime.Now.ToLongTimeString();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }
        private void ОбновитьСтильШрифта()
        {
            FontStyle новыйСтиль = FontStyle.Regular;

            if (жирныйToolStripMenuItem.Checked)
            {
                новыйСтиль |= FontStyle.Bold;
            }

            if (курсивToolStripMenuItem.Checked)
            {
                новыйСтиль |= FontStyle.Italic;
            }

            if (подчеркнутыйToolStripMenuItem.Checked)
            {
                новыйСтиль |= FontStyle.Underline;
            }

            Font текущийШрифт = textBox1.Font;
            textBox1.Font = new Font(текущийШрифт.FontFamily, текущийШрифт.Size, новыйСтиль);
            текущийШрифт.Dispose();
        }

    }
}
