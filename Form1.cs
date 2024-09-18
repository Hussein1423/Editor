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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace EditorText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string saveFileName = "";
            saveFileDialog1.Filter = "Text Files|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileName = saveFileDialog1.FileName;
                string[] allProperties = { rchText.Text, colorDialog1.Color.Name, fontDialog1.Font.Name, fontDialog1.Font.Size.ToString() };
                File.WriteAllLines(saveFileName, allProperties);
            }
            
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] openFileName = new string[4];
            openFileDialog1.Filter = "Text Files|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileName = File.ReadAllLines(openFileDialog1.FileName);
                rchText.Clear();
                rchText.ForeColor = Color.FromName(openFileName[1]);
                rchText.Text = openFileName[0];
                rchText.Font = new Font(openFileName[2],float.Parse(openFileName[3]));
            }
             
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rchText.SelectionColor = colorDialog1.Color;
                if(rchText.Text=="")
                rchText.ForeColor = colorDialog1.Color;
            }
            
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rchText.SelectionFont = fontDialog1.Font;
                rchText.SelectionColor = fontDialog1.Color;
                colorDialog1.Color = fontDialog1.Color;
                if (rchText.Text == "")
                {
                    rchText.Font = fontDialog1.Font;
                    rchText.ForeColor = fontDialog1.Color;
                }

            }
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchText.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchText.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchText.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchText.SelectionColor = Color.Black;
            rchText.SelectionFont = new Font("Tahoma",8);
            rchText.SelectionBackColor = Color.White;
            rchText.SelectionAlignment= HorizontalAlignment.Left;
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog2.ShowDialog() == DialogResult.OK)
            {
                rchText.SelectionBackColor = colorDialog2.Color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            rchText.SelectionFont = new Font(rchText.SelectionFont.FontFamily,(float) numericUpDown1.Value);
        }

        private void rchText_SelectionChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = (int)rchText.SelectionFont.Size;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rchText.SelectionColor = colorDialog1.Color;
                if (rchText.Text == "")
                    rchText.ForeColor = colorDialog1.Color;
            }
        }
    }
}
