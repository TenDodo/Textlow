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


namespace Textlow
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            timer1.Start();
        }
        public int line = 0;
        public int column = 0;


        

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("Czy chcesz zapisać bieżący dokument?", "Niezapisany dokument", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saveAs(richTextBox1.Text);
                    richTextBox1.Clear();
                }
                else if (result == DialogResult.No)
                {
                    richTextBox1.Clear();
                }
            }
            else
            {
                richTextBox1.Clear();
            }


        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("Czy chcesz zapisać bieżący dokument?", "Niezapisany dokument", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saveAs(richTextBox1.Text);
                    openFile();
                }
                else if (result == DialogResult.No)
                {
                    openFile();
                }
            }
            else
            {
                openFile();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveAs(richTextBox1.Text);
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void selectallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("Czy chcesz zapisać bieżący dokument?", "Niezapisany dokument", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saveAs(richTextBox1.Text);
                    richTextBox1.Clear();
                }
                else if (result == DialogResult.No)
                {
                    richTextBox1.Clear();
                }
            }
            else
            {
                richTextBox1.Clear();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("Czy chcesz zapisać bieżący dokument?", "Niezapisany dokument", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saveAs(richTextBox1.Text);
                    openFile();
                }
                else if (result == DialogResult.No)
                {
                    openFile();
                }
            }
            else
            {
                openFile();
            }
            
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs(richTextBox1.Text);
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        string txt = "Dokumenty tekstowe (*.txt)|*.txt";
        string html = "|html (*.html)|*.html";
        string css = "|css (*.css)|*.css";     
        string rtf = "|RTF (*.rtf)|*.rtf";
        string pdf = "|PDF (*.pdf)|*.pdf";
        string docx = "|docx (*.docx)|*.docx";
        string all = "|All files (*.*)|*.*";
        private void saveAs(string textToSave)
        {
            
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Zapisz plik jako:";
            saveFile.Filter = txt + html + css + rtf + pdf + docx + all;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (saveFile.FilterIndex == 5)
                {
                    MessageBox.Show("Wsparcie dla formatu .pdf wkrótce!");
                }
                if (saveFile.FilterIndex == 6)
                {
                    MessageBox.Show("Wsparcie dla formatu .docx wkrótce!");
                }
                else
                {
                    StreamWriter textoutput = new StreamWriter(saveFile.FileName);
                    textoutput.Write(textToSave);
                    textoutput.Close();
                }
                

            }
        }
        private void openFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Wybierz plik do otwarcia:";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void textlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.Yellow;
            textlowToolStripMenuItem.Checked = true;
            klasycznyToolStripMenuItem.Checked = false;
            klasycznyCiemnyToolStripMenuItem.Checked = false;
        }

        private void klasycznyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
            textlowToolStripMenuItem.Checked = false;
            klasycznyToolStripMenuItem.Checked = true;
            klasycznyCiemnyToolStripMenuItem.Checked = false;
        }

        private void klasycznyCiemnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.White;
            textlowToolStripMenuItem.Checked = false;
            klasycznyToolStripMenuItem.Checked = false;
            klasycznyCiemnyToolStripMenuItem.Checked = true;
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            info form2 = new info();
            form2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            line = 1 + richTextBox1.GetLineFromCharIndex(richTextBox1.GetFirstCharIndexOfCurrentLine());
            column = 1 + richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine();
            toolStripStatusLabel1.Text = "Wiersz: " + line.ToString() + " | Kolumna: " + column.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.ScrollToCaret();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    richTextBox1.Font = new Font("Consolas", int.Parse(toolStripTextBox1.Text), FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            //}
            //catch
            //{

            //}
            //toolStripSplitButton1.Text = toolStripTextBox1.Text;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font("Consolas", 9, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            toolStripSplitButton1.Text = "9";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font("Consolas", 12, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            toolStripSplitButton1.Text = "12";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font("Consolas", 16, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            toolStripSplitButton1.Text = "16";
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Font = new Font("Consolas", int.Parse(toolStripTextBox1.Text), FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
                toolStripSplitButton1.Text = toolStripTextBox1.Text;
            }
            catch (FormatException)
            {

            }
                
            
            
        }

        private void szyfrCezaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs(ceasarCipher(richTextBox1.Text, 3));
        }

        public static string ceasarCipher(string ceasarCipherInput, int ceasarCipherKey)
        {
            string ceasarCipherOutput = string.Empty;
            foreach(char ch in ceasarCipherInput)
            {
                ceasarCipherOutput += cipher(ch, ceasarCipherKey);
                
            }
            return ceasarCipherOutput;
        }
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }

        private void szyfrCezaraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string textToDecipher;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Wybierz plik do otwarcia:";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    textToDecipher = sr.ReadToEnd();
                    richTextBox1.Text = ceasarDecipher(textToDecipher, 3);
                    sr.Close();
                }
            }
        }

        public static string ceasarDecipher(string ceasarDecipherInput, int ceasarDecipherKey)
        {
            return ceasarCipher(ceasarDecipherInput, 26 - ceasarDecipherKey);
        }

        private void szyfrCezaraZWlasnymKluczemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int customCeasarKey;
            string value = "0";
            if (InputBox("Podaj klucz", "Podaj własny klucz (cyfra):", ref value) == DialogResult.OK)
            {
                try
                {
                    customCeasarKey = int.Parse(value);
                    saveAs(ceasarCipher(richTextBox1.Text, customCeasarKey));
                }
                catch
                {
                    MessageBox.Show("Nieprawidłowa wartość");
                }
            }
            
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Anuluj";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void szyfrCezaraZWlasnymKluczemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int customCeasarKey;
            string value = "0";
            if (InputBox("Podaj klucz", "Podaj własny klucz (cyfra):", ref value) == DialogResult.OK)
            {
                try
                {
                    customCeasarKey = int.Parse(value);
                    string textToDecipher;
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Title = "Wybierz plik do otwarcia:";
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.Clear();
                        using (StreamReader sr = new StreamReader(openFile.FileName))
                        {
                            textToDecipher = sr.ReadToEnd();
                            richTextBox1.Text = ceasarDecipher(textToDecipher, customCeasarKey);
                            sr.Close();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Nieprawidłowa wartość");
                }
            }
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Wybierz plik do otwarcia:";
            if (openFile.ShowDialog() == DialogResult.OK)
            {               
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    richTextBox1.Text += sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void dopiszTekstZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Wybierz plik do otwarcia:";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    richTextBox1.Text += sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, new PointF(100, 100));
            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
