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
using System.Windows.Documents;
using System.Speech;
using System.Speech.Synthesis;

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
        string tl = "|Textlow (*.tl)|*.tl";
        string html = "|html (*.html)|*.html";
        string css = "|css (*.css)|*.css";
        string rtf = "|RTF (*.rtf)|*.rtf";
        string all = "|All files (*.*)|*.*";
        private void saveAs(string textToSave)
        {

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Zapisz plik jako:";
            saveFile.Filter = txt + tl + html + css + rtf + all;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {           
                    StreamWriter textoutput = new StreamWriter(saveFile.FileName);
                    textoutput.Write(textToSave);
                    textoutput.Close();
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
            draculaToolStripMenuItem.Checked = false;
        }

        private void klasycznyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
            textlowToolStripMenuItem.Checked = false;
            klasycznyToolStripMenuItem.Checked = true;
            klasycznyCiemnyToolStripMenuItem.Checked = false;
            draculaToolStripMenuItem.Checked = false;
        }

        private void klasycznyCiemnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.White;
            textlowToolStripMenuItem.Checked = false;
            klasycznyToolStripMenuItem.Checked = false;
            klasycznyCiemnyToolStripMenuItem.Checked = true;
            draculaToolStripMenuItem.Checked = false;
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
            #region Secrets
            if (richTextBox1.Text == "crazyfrog" || richTextBox1.Text == "crazy frog")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=kGGoeDrjL5g");
            }
            else if (richTextBox1.Text == "rick" || richTextBox1.Text == "rickroll" || richTextBox1.Text == "rick roll")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            }
            else if (richTextBox1.Text == "allstar" || richTextBox1.Text == "all star")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=L_jWHffIx5E");
            }
            else if (richTextBox1.Text == "Adrian Hajdun")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=BKpGCsToSe8");
            }
            else if (richTextBox1.Text == "⠀")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=UxM5UgpXYM4");
            }
            else if (richTextBox1.Text == "sans granie")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=R8uK9bjME6Y");
            }
            else if (richTextBox1.Text == "Säkkijärven Polkka")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=KCm2PtSgzkA");
            }
            else if (richTextBox1.Text == "Tunak Tunak Tun")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=vTIIMJ9tUc8");
            }
            else if (richTextBox1.Text == "leekspin" || richTextBox1.Text == "leek spin")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=1wnE4vF9CQ4");
            }
            else if (richTextBox1.Text == "bitch lasagna" || richTextBox1.Text == "tseries")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=6Dh-RL__uN4");
            }
            else if (richTextBox1.Text == "2020")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=XaO_3GcQyiE");
            }
            else if (richTextBox1.Text == "github")
            {
                System.Diagnostics.Process.Start("https://github.com/TenDodo/Textlow");
            }
            else if (richTextBox1.Text == "bruh")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=TKvjEQXKeec");
                richTextBox1.Text = "what";
                richTextBox1.Font = new Font(richTextBox1.Font.Name, 200, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            }
            else if (richTextBox1.Text == "btw i use arch" || richTextBox1.Text == "i use arch btw")
            {
                richTextBox1.Text = "me too";
            }
            else if (richTextBox1.Text == "doge" || richTextBox1.Text == "wow" || richTextBox1.Text == "omg")
            {
                richTextBox1.Text = "░░░░░░░░░▄░░░░░░░░░░░░░░▄░░░░\n░░░░░░░░▌▒█░░░░░░░░░░░▄▀▒▌░░░\n░░░░░░░░▌▒▒█░░░░░░░░▄▀▒▒▒▐░░░\n░░░░░░░▐▄▀▒▒▀▀▀▀▄▄▄▀▒▒▒▒▒▐░░░\n░░░░░▄▄▀▒░▒▒▒▒▒▒▒▒▒█▒▒▄█▒▐░░░\n░░░▄▀▒▒▒░░░▒▒▒░░░▒▒▒▀██▀▒▌░░░\n░░▐▒▒▒▄▄▒▒▒▒░░░▒▒▒▒▒▒▒▀▄▒▒▌░░\n░░▌░░▌█▀▒▒▒▒▒▄▀█▄▒▒▒▒▒▒▒█▒▐░░\n░▐░░░▒▒▒▒▒▒▒▒▌██▀▒▒░░░▒▒▒▀▄▌░\n░▌░▒▄██▄▒▒▒▒▒▒▒▒▒░░░░░░▒▒▒▒▌░\n▀▒▀▐▄█▄█▌▄░▀▒▒░░░░░░░░░░▒▒▒▐░\n▐▒▒▐▀▐▀▒░▄▄▒▄▒▒▒▒▒▒░▒░▒░▒▒▒▒▌\n▐▒▒▒▀▀▄▄▒▒▒▄▒▒▒▒▒▒▒▒░▒░▒░▒▒▐░\n░▌▒▒▒▒▒▒▀▀▀▒▒▒▒▒▒░▒░▒░▒░▒▒▒▌░\n░▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒░▒░▒░▒▒▄▒▒▐░░\n░░▀▄▒▒▒▒▒▒▒▒▒▒▒░▒░▒░▒▄▒▒▒▒▌░░\n░░░░▀▄▒▒▒▒▒▒▒▒▒▒▄▄▄▀▒▒▒▒▄▀░░░\n░░░░░░▀▄▄▄▄▄▄▀▀▀▒▒▒▒▒▄▄▀░░░░░\n░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▀▀░░░░░░░░\nWow! Such Doge!";
                richTextBox1.Font = new Font("Consolas", richTextBox1.Font.Size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            }
            else if (richTextBox1.Text == "nyan cat" || richTextBox1.Text == "nyan" || richTextBox1.Text == "nyancat")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=QH2-TGUlwu4");
            }
            else if (richTextBox1.Text == "despacito")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=kJQP7kiw5Fk");
            }
            else if (richTextBox1.Text == "we are number one")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=PfYnvDL0Qcw");
            }
            else if (richTextBox1.Text == "kazoo kid" || richTextBox1.Text == "kazookid")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=g-sgw9bPV4A");
            }
            else if (richTextBox1.Text == "date" || richTextBox1.Text == "time" || richTextBox1.Text == "what time is it")
            {
                richTextBox1.Text = DateTime.Now.ToString();
            }
            else
            {
                richTextBox1.ScrollToCaret();
            }
            #endregion
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



        private void szyfrCezaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isAscii = true;
            foreach (char c in richTextBox1.Text)
            {
                if (c > 127)
                {
                    isAscii = false;
                }
            }
            if (isAscii)
            {
                saveAs(ceasarCipher(richTextBox1.Text, 3));
            }
            else
            {
                MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na szyfr cezara.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
            }

        }

        public static string ceasarCipher(string ceasarCipherInput, int ceasarCipherKey)
        {
            string ceasarCipherOutput = string.Empty;
            foreach (char ch in ceasarCipherInput)
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
            bool isAscii = true;
            foreach (char c in richTextBox1.Text)
            {
                if (c > 127)
                {
                    isAscii = false;
                }
            }
            if (isAscii)
            {
                int customCeasarKey;
                string value = "0";
                if (InputBox("Podaj klucz", "Podaj własny klucz (cyfra od 1 do 25):", ref value) == DialogResult.OK)
                {
                    try
                    {

                        customCeasarKey = int.Parse(value);
                        if (customCeasarKey > 25 || customCeasarKey < 1)
                        {
                            MessageBox.Show("Wartość z poza dozwolonego przedziału, szyfrowanie może nie działać poprawnie.");

                        }
                        saveAs(ceasarCipher(richTextBox1.Text, customCeasarKey));
                    }
                    catch
                    {
                        MessageBox.Show("Nieprawidłowa wartość");
                    }
                }
            }
            else
            {
                MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na szyfr cezara.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
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
            if (InputBox("Podaj klucz", "Podaj własny klucz (cyfra od 1 do 25):", ref value) == DialogResult.OK)
            {
                try
                {
                    customCeasarKey = int.Parse(value);
                    if (customCeasarKey > 25 || customCeasarKey < 1)
                    {
                        MessageBox.Show("Wartość z poza dozwolonego przedziału, szyfrowanie może nie działać poprawnie.");
                        
                    }
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

        private void MainWindow_Load(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.Font;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("Czy chcesz zapisać bieżący dokument?", "Niezapisany dokument", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    saveAs(richTextBox1.Text);

                }
                else if (result == DialogResult.No)
                {

                }
            }

        }
        SpeechSynthesizer voice = new SpeechSynthesizer();
        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            voice.SpeakAsync(richTextBox1.Text);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void binariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isAscii = true;
            foreach (char c in richTextBox1.Text)
            {
                if (c > 127)
                {
                    isAscii = false;
                }
            }
            if (isAscii)
            {
                saveAs(StringToBinary(richTextBox1.Text));
            }
            else
            {

                MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
            }

        }

        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        private void binariaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string binToS;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Wybierz plik do otwarcia:";
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    binToS = sr.ReadToEnd();
                    bool isBinary = true;
                    foreach (char ch in binToS)
                    {
                        if (ch != '0' && ch != '1')
                        {
                            isBinary = false;
                        }
                    }
                    if (isBinary)
                    {
                        richTextBox1.Clear();
                        richTextBox1.Text = BinaryToString(binToS);
                    }
                    else
                    {
                        MessageBox.Show("Plik zawiera znaki inne niż binaria.\nPlik nie może zostać otwarty.");
                    }

                    sr.Close();
                }
            }
        }
        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        private void draculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.FromArgb(40, 42, 54);
            richTextBox1.ForeColor = Color.FromArgb(188, 194, 205);
            textlowToolStripMenuItem.Checked = false;
            klasycznyToolStripMenuItem.Checked = false;
            klasycznyCiemnyToolStripMenuItem.Checked = false;
            draculaToolStripMenuItem.Checked = true;
        }

        private void szyfrCezaraToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool isAscii = true;
            foreach (char c in richTextBox1.Text)
            {
                if (c > 127)
                {
                    isAscii = false;
                }
            }
            if (isAscii)
            {
                richTextBox1.Text = ceasarCipher(richTextBox1.Text, 3);
            }
            else
            {
                MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na szyfr cezara.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
            }
        }

        private void szyfrCezaraZWlasnymKluczemToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool isAscii = true;
            foreach (char c in richTextBox1.Text)
            {
                if (c > 127)
                {
                    isAscii = false;
                }
            }
            if (isAscii)
            {
                int customCeasarKey;
                string value = "0";
                if (InputBox("Podaj klucz", "Podaj własny klucz (cyfra od 1 do 25):", ref value) == DialogResult.OK)
                {
                    try
                    {
                        customCeasarKey = int.Parse(value);
                        if (customCeasarKey > 25 || customCeasarKey < 1)
                        {
                            MessageBox.Show("Wartość z poza dozwolonego przedziału, szyfrowanie może nie działać poprawnie.");

                        }
                        richTextBox1.Text = ceasarCipher(richTextBox1.Text, customCeasarKey);
                    }
                    catch
                    {
                        MessageBox.Show("Nieprawidłowa wartość");
                    }
                }
            }
            else
            {
                MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na szyfr cezara.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
            }
        }

        private void binariaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool isAscii = true;
            foreach (char c in richTextBox1.Text)
            {
                if (c > 127)
                {
                    isAscii = false;
                }
            }
            if (isAscii)
            {
                richTextBox1.Text = StringToBinary(richTextBox1.Text);
            }
            else
            {

                MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
            }
        }

        private void szyfrCezaraToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = ceasarDecipher(richTextBox1.Text, 3);
            }
            catch
            {
                MessageBox.Show("Plik nie może zostać odszyfrowany, ponieważ pojawiaja się w nim nieznane znaki.");
            }
        }

        private void szyfrCezaraZWlasnymKluczemToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int customCeasarKey;
            string value = "0";
            if (InputBox("Podaj klucz", "Podaj własny klucz (cyfra od 1 do 25):", ref value) == DialogResult.OK)
            {
                try
                {
                    customCeasarKey = int.Parse(value);
                    if (customCeasarKey > 25 || customCeasarKey < 1)
                    {
                        MessageBox.Show("Wartość z poza dozwolonego przedziału, szyfrowanie może nie działać poprawnie.");

                    }
                    try
                    {
                        richTextBox1.Text = ceasarDecipher(richTextBox1.Text, customCeasarKey);
                    }
                    catch
                    {
                        MessageBox.Show("Plik nie może zostać odszyfrowany, ponieważ pojawiaja się w nim nieznane znaki.");
                    }

                }
                catch
                {
                    MessageBox.Show("Nieprawidłowa wartość");
                }
            }
        }

        private void binariaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string binToS;

            binToS = richTextBox1.Text;
            bool isBinary = true;
            foreach (char ch in binToS)
            {
                if (ch != '0' && ch != '1')
                {
                    isBinary = false;
                }
            }
            if (isBinary)
            {
                richTextBox1.Text = BinaryToString(binToS);
            }
            else
            {
                MessageBox.Show("Plik zawiera znaki inne niż binaria.\nPlik nie może zostać otwarty.");
            }


        }
    }
}
