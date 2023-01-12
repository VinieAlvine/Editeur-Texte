using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.IO;
using System.Text.RegularExpressions;

namespace ProjetCshap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStrip1.Renderer = new ToolStripRemoval() { };

        }

        public int ligne = 0;
        public int colonne = 0 ;

        // TOOLSTRIP SRIPE REMOVAL
        public class ToolStripRemoval : ToolStripSystemRenderer
        {

            public ToolStripRemoval() { }
            protected override void
            OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                // ToolStripStripeRemoval


            }

        }

        private void nouveauToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void ouvrirToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            openfile.Title = " ouvrir un fichier dans une nouvelle fenetre ";
            if (openfile.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {

                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void enregistrerToolStripButton_Click(object sender, EventArgs e)
        {
            string save, text;

            text = richTextBox1.Text;

            saveFileDialog1.Filter = "Nom du fichier(*.txt) | *.txt | fichiers texte(*.*) | *.* ";
            saveFileDialog1.FileName = "Nouveau document";

            if (saveFileDialog1.ShowDialog(Owner) == DialogResult.OK)
            {

                save = openFileDialog1.FileName;
                File.WriteAllText(save, text);


            }
            else { }
        }

        private void couperToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copierToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void collerToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nouveauToolStripButton.PerformClick();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ouvrirToolStripButton.PerformClick();
            string open;

            openFileDialog1.Filter = " Nom du fichier(*.txt) | *.txt | fichiers texte(*.*) | *.* ";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog(Owner) == DialogResult.OK)
            {
                open = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(open);

            }
            else
            { }
            }


        private void enregistrersousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enregistrerToolStripButton.PerformClick();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void annulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           AnnulerButton.PerformClick();
        }

        private void rétablirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redoButton.PerformClick();
        }

        private void couperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            couperToolStripButton.PerformClick();
        }

        private void copierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copierToolStripButton.PerformClick();
        }

        private void collerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collerToolStripButton.PerformClick();
        }

        private void sélectionnertoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sélectionnertoutToolStripMenuItem.PerformClick();
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //enregistrerToolStripButton.PerformClick();
            string save, text;

            text = richTextBox1.Text;

            saveFileDialog1.Filter = "Nom du fichier(*.txt) | *.txt | fichiers texte(*.*) | *.* ";
            saveFileDialog1.FileName = "Nouveau document";

            if (saveFileDialog1.ShowDialog(Owner) == DialogResult.OK)
            {

                save = openFileDialog1.FileName;
                File.WriteAllText(save, text);


   }
            else { }

        }

        private void trouverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            ligne = 1 + richTextBox1.GetLineFromCharIndex(richTextBox1.GetFirstCharIndexOfCurrentLine());

            colonne = 1 + richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine();
            toolStripStatusLabel1.Text = " ligne : " + ligne.ToString() + "| colonne : " + colonne.ToString();

        }

        private void revenirEnHautToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();


        }

        private void sauterAuBoutonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keywords = textBox1.Text;
            MatchCollection keywordMatches =
            Regex.Matches(richTextBox1.Text, keywords);
            int originalIndex = richTextBox1.SelectionStart;
int originalLength = richTextBox1.SelectionLength;

            // Stops blinking 
            textBox1.Focus();
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionBackColor =
           Color.FromArgb(((int)((byte)(30))) , ((int) ((byte)(30))),
            ((int)((byte)(30))));

            foreach (Match m in keywordMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.White;
                richTextBox1.SelectionBackColor = Color.DodgerBlue;
            }

            richTextBox1.SelectionStart = originalIndex;
            richTextBox1.SelectionLength = originalLength;
            richTextBox1.SelectionBackColor =
          Color.FromArgb(((int)((byte)(30))), ((int)((byte)(30))),
            ((int)((byte)(30))));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && !string.IsNullOrWhiteSpace(textBox2.Text) && textBox3.Text != null &&
                !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                richTextBox1.Text = richTextBox1.Text.Replace (textBox2.Text, textBox3.Text);
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }

        private void chercherEtRemplacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog(Owner) == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;

            }
            else { }
        }
    }
    }

