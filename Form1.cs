#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Documents;
using System.Speech;
using System.Speech.Synthesis;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;
#endregion
namespace Textlow
{
    public partial class MainWindow : Form
    {
        #region Basics
        public MainWindow()
        {
            InitializeComponent();
            timer1.Start();
        }
        public int line = 0;
        public int column = 0;

        private void MainWindow_Load(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.Font;
            bgColor = richTextBox1.BackColor;
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
        #endregion

        #region Tool Strip
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

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveAs(richTextBox1.Text);
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
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
            else if (!true)
            {
                richTextBox1.Text = "Prosze nie patrzeć do sekretów!";
            }
            else if (richTextBox1.Text == "give me some fanfics")
            {
                richTextBox1.Text = "no";
            }
            else if (richTextBox1.Text == "allstar" || richTextBox1.Text == "all star")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=L_jWHffIx5E");
            }
            else if (richTextBox1.Text == "taskmgr" || richTextBox1.Text == "taskmanager" || richTextBox1.Text == "task manager")
            {
                System.Diagnostics.Process.Start("taskmgr");
            }
            else if (richTextBox1.Text == "calc")
            {
                System.Diagnostics.Process.Start("calc");
            }
            else if (richTextBox1.Text == "⠀")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=UxM5UgpXYM4");
            }
            else if (richTextBox1.Text == "cmd")
            {
                System.Diagnostics.Process.Start("cmd");
            }
            else if (richTextBox1.Text == "Sans Granie")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=R8uK9bjME6Y");
            }
            else if (richTextBox1.Text == "bad apple" || richTextBox1.Text == "badapple" || richTextBox1.Text == "Bad Apple")
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=FtutLA63Cp8");
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
            richTextBox1.Font = fontDialog1.Font;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            voice.SpeakAsync(richTextBox1.Text);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor += 0.3F;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (richTextBox1.ZoomFactor - 0.3F > 0F)
            {
                richTextBox1.ZoomFactor -= 0.3F;
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            int start = 0;
            int end = richTextBox1.Text.LastIndexOf(toolStripTextBox1.Text);

            while (start <= end)
            {
                richTextBox1.Find(toolStripTextBox1.Text, start, richTextBox1.TextLength, RichTextBoxFinds.MatchCase);
                richTextBox1.SelectionBackColor = Color.Blue;
                richTextBox1.SelectionColor = Color.Black;
                start = richTextBox1.Text.IndexOf(toolStripTextBox1.Text, start) + 1;
            }
            richTextBox1.DeselectAll();
        }

        private void toolStripButton11_Click_1(object sender, EventArgs e)
        {
            resetColors();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            info form2 = new info();
            form2.Show();
        }

        private void questionMarkCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 50000)
            {
                if (MessageBox.Show("Tekst który próbujesz zaszyfrować może okazać się zbyt długi. Kontynuowanie może spowodować zatrzymanie pracy programu. Czy chcesz kontynuować?", "Duża ilość znaków", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                        string bin = StringToBinary(richTextBox1.Text);
                        string final = BinToQMc(bin);
                        richTextBox1.Text = final;


                    }
                    else
                    {

                        MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                    }
                }
            }
            else
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
                    string bin = StringToBinary(richTextBox1.Text);
                    string final = BinToQMc(bin);
                    richTextBox1.Text = final;
                }
                else
                {

                    MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                }
            }
        }
        private void questionMarkCodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string bin = QMcToBin(richTextBox1.Text);

            string binToS;

            binToS = bin;
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
        #endregion

        #region Menu Strip
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

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs(richTextBox1.Text);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void questionMarkCodeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 50000)
            {
                if (MessageBox.Show("Tekst który próbujesz zaszyfrować może okazać się zbyt długi. Kontynuowanie może spowodować zatrzymanie pracy programu. Czy chcesz kontynuować?", "Duża ilość znaków", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                        string bin = StringToBinary(richTextBox1.Text);
                        string final = BinToQMc(bin);
                        saveAs(final);


                    }
                    else
                    {

                        MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                    }
                }
            }
            else
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
                    string bin = StringToBinary(richTextBox1.Text);
                    string final = BinToQMc(bin);
                    saveAs(final);
                }
                else
                {

                    MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                }
            }
        }

        private void questionMarkCodeToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Wybierz plik do otwarcia:";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string text;
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    text = sr.ReadToEnd();


                    sr.Close();
                }
                string bin = QMcToBin(text);

                string binToS;

                binToS = bin;
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
        private void adixTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 50000)
            {
                if (MessageBox.Show("Tekst który próbujesz zaszyfrować może okazać się zbyt długi. Kontynuowanie może spowodować zatrzymanie pracy programu. Czy chcesz kontynuować?", "Duża ilość znaków", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                        string bin = StringToBinary(richTextBox1.Text);
                        string final = binToAT(bin);
                        richTextBox1.Text = final;


                    }
                    else
                    {

                        MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                    }
                }
            }
            else
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
                    string bin = StringToBinary(richTextBox1.Text);
                    string final = binToAT(bin);
                    richTextBox1.Text = final;
                }
                else
                {

                    MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                }
            }
        }
        private void adixTablesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string bin = ATToBin(richTextBox1.Text);

            string binToS;

            binToS = bin;
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

        private void adixTablesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 50000)
            {
                if (MessageBox.Show("Tekst który próbujesz zaszyfrować może okazać się zbyt długi. Kontynuowanie może spowodować zatrzymanie pracy programu. Czy chcesz kontynuować?", "Duża ilość znaków", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                        string bin = StringToBinary(richTextBox1.Text);
                        string final = binToAT(bin);
                        saveAs(final);


                    }
                    else
                    {

                        MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                    }
                }
            }
            else
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
                    string bin = StringToBinary(richTextBox1.Text);
                    string final = binToAT(bin);
                    saveAs(final);
                }
                else
                {

                    MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na binaria.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                }
            }
        }

        private void adixTablesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Wybierz plik do otwarcia:";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string text;
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    text = sr.ReadToEnd();


                    sr.Close();
                }
                string bin = ATToBin(text);

                string binToS;

                binToS = bin;
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
        #endregion

        #region Themes
        private void textlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Black;
            bgColor = Color.Black;
            richTextBox1.ForeColor = Color.Yellow;
            textlowToolStripMenuItem.Checked = true;
            klasycznyToolStripMenuItem.Checked = false;
            klasycznyCiemnyToolStripMenuItem.Checked = false;
            draculaToolStripMenuItem.Checked = false;
            resetColors();
        }

        private void klasycznyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            bgColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
            textlowToolStripMenuItem.Checked = false;
            klasycznyToolStripMenuItem.Checked = true;
            klasycznyCiemnyToolStripMenuItem.Checked = false;
            draculaToolStripMenuItem.Checked = false;
            resetColors();
        }

        private void klasycznyCiemnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Black;
            bgColor = Color.Black;
            richTextBox1.ForeColor = Color.White;
            textlowToolStripMenuItem.Checked = false;
            klasycznyToolStripMenuItem.Checked = false;
            klasycznyCiemnyToolStripMenuItem.Checked = true;
            draculaToolStripMenuItem.Checked = false;
            resetColors();
        }

        private void draculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.FromArgb(40, 42, 54);
            bgColor = Color.FromArgb(40, 42, 54);
            richTextBox1.ForeColor = Color.FromArgb(188, 194, 205);
            textlowToolStripMenuItem.Checked = false;
            klasycznyToolStripMenuItem.Checked = false;
            klasycznyCiemnyToolStripMenuItem.Checked = false;
            draculaToolStripMenuItem.Checked = true;
            resetColors();
        }
        #endregion     

        #region Filters
        string txt = "Dokumenty tekstowe (*.txt)|*.txt";
        string tl = "|Textlow (*.tl)|*.tl";
        string html = "|html (*.html)|*.html";
        string css = "|css (*.css)|*.css";
        string rtf = "|RTF (*.rtf)|*.rtf";
        string bat = "|Batch file (*.bat)|*.bat";
        string sh = "|Unix script file (*.sh)|*.sh";
        string fas = "|Flash ActionScript file (*.as)|*.as";
        string ada = "|Ada file (*.ada)|*.ada";
        string asm = "|Assembly language source file (*.asm)|*.asm";
        string mib = "|Abstract Syntax Notation One file (*.mib)|*.mib";
        string asp = "|Active Server Pages script file (*.asp)|*.asp";
        string au3 = "|AutoIt (*.au3)|*.au3";
        string avs = "|AviSynth scripts files (*.avs)|*.avs";
        string bc = "|BaanC file (*.bc)|*.bc";
        string bb = "|BlitzBasic file (*.bb)|*.bb";
        string bf = "|BrainFuck (*.bf)|*.bf";
        string c = "|C source file (*.c)|*.c";
        string ml = "|Categorical Abstract Machine Language (*.ml)|*.ml";
        string cmake = "|CMake file (*.cmake)|*.cmake";
        string cbl = "|Common Business Oriented Language (*.cbl)|*.cbl";
        string orc = "|Csound file (*.orc)|*.orc";
        string coffee = "|CoffeeScript file (*.coffee)|*.coffee";
        string cpp = "|C++ source file (*.cpp)|*.cpp";
        string cs = "|C# cource code (*.cs)|*.cs";
        string d = "|D programming language (*.d)|*.d";
        string diff = "|Diff file (*.patch)|*.patch";
        string erl = "|Erlang file (*.erl)|*.erl";
        string src = "|ESCRIPT file (*.src)|*.src";
        string forth = "|Forth file (*.forth)|*.forth";
        string f = "|Fortran free form source file (*.f)|*.f";
        string f77 = "|Fortran fixed form source file (*.f77)|*.f77";
        string bi = "|FreeBasic file (*.bi)|*.bi";
        string hs = "|Haskell (*.hs)|*.hs";
        string ini = "|MS ini file (*.ini)|*.ini";
        string iss = "|Inno Setup script (*.iss)|*.iss";
        string hex = "|Intel HEX binary data (*.hex)|*.hex";
        string java = "|Java source file (*.java)|*.java";
        string js = "|JavaScript (*.js)|*.js";
        string json = "|JSON file (*.json)|*.json";
        string jsp = "|JavaServer Pages script file (*.jsp)|*.jsp";
        string kix = "|KiXtart file (*.kix)|*.kix";
        string lsp = "|List Processing language file (*.lsp)|*.lsp";
        string tex = "|LaTeX file (*.tex)|*.tex";
        string lua = "|Lua source File (*.lua)|*.lua";
        string mak = "|Makefile (*.mak)|*.mak";
        string m = "|MATrix LABoratory (*.m)|*.m";
        string mms = "|MMIXAL file (*.mms)|*.mms";
        string nim = "|Nimrod file (*.nim)|*.nim";
        string tab = "|extended crontab file (*.tab)|*.tab";
        string nfo = "|MSDOS Style/ASCII Art (*.nfo)|*.nfo";
        string nsh = "|Nullsoft Scriptable install System script file (*.nsh)|*.nsh";
        string osx = "|OScript source file (*.osx)|*.osx";
        string mm = "|Objective-C source file (*.mm)|*.mm";
        string pp = "|Pascal source file (*.pp)|*.pp";
        string pl = "|Perl source file (*.pl)|*.pl";
        string php = "|PHP Hypertext Preprocessor file (*.php)|*.php";
        string ps = "|PostScript file (*.ps)|*.ps";
        string ps1 = "|Windows PowerShell (*.ps1)|*.ps1";
        string properties = "|Properties file (*.properties)|*.properties";
        string pb = "|PureBasic file (*.pb)|*.pb";
        string py = "|Python file (*.py)|*.py";
        string r = "|R programming language (*.r)|*.r";
        string reb = "|REBOL file (*.reb)|*.reb";
        string reg = "|registry file (*.reg)|*.reg";
        string rc = "|Windows Resource file (*.rc)|*.rc";
        string rb = "|Ruby file (*.rb)|*.rb";
        string rs = "|Rust file (*.rs)|*.rs";
        string scm = "|Scheme file (*.scm)|*.scm";
        string st = "|SmalTalk file (*.st)|*.st";
        string scp = "|spice file (*.scp)|*.scp";
        string sql = "|Structured Query Language file (*.sql)|*.sql";
        string mot = "|Motorola S-Record binary data (*.mot)|*.mot";
        string swift = "|Swift file (*.swift)|*.swift";
        string tcl = "|Tool Command Language file (*.tcl)|*.tcl";
        string tek = "|Tektronix extended HEX binary data (*.tek)|*.tek";
        string vb = "|Visual Basic file (*.vb)|*.vb";
        string t2t = "|txt2tags file (*.t2t)|*.t2t";
        string v = "|Verilog file (*.v)|*.v";
        string vhd = "|VHSIC Hardware Description Language file (*.vhd)|*.vhd";
        string pro = "|Visual Prolog file (*.pro)|*.pro";
        string xml = "|eXtensible Markup Language file (*.xml)|*.xml";
        string yaml = "|YAML Ain't Markup Language (*.yaml)|*.yaml";
        string all = "|All files (*.*)|*.*";
        #endregion

        #region Encoding
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
                if (InputBox("Podaj klucz", "OK", "Podaj własny klucz (cyfra od 1 do 25):", ref value) == DialogResult.OK)
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

        private void brainFuckToolStripMenuItem3_Click(object sender, EventArgs e)
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
                saveAs(strToBf(richTextBox1.Text));
            }
            else
            {

                MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na BrainFuck.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
            }
        }

        private void tripleDESToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string value = "";
            if (InputBox("Podaj klucz", "OK", "Podaj własny klucz:", ref value) == DialogResult.OK)
            {
                saveAs(tDESEncrypt(richTextBox1.Text, value));
            }
        }

        private void szyfrCezaraToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 50000)
            {
                if (MessageBox.Show("Tekst który próbujesz zaszyfrować może okazać się zbyt długi. Kontynuowanie może spowodować zatrzymanie pracy programu. Czy chcesz kontynuować?", "Duża ilość znaków", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            }
            else
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
        }

        private void szyfrCezaraZWlasnymKluczemToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 50000)
            {
                if (MessageBox.Show("Tekst który próbujesz zaszyfrować może okazać się zbyt długi. Kontynuowanie może spowodować zatrzymanie pracy programu. Czy chcesz kontynuować?", "Duża ilość znaków", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                        if (InputBox("Podaj klucz", "OK", "Podaj własny klucz (cyfra od 1 do 25):", ref value) == DialogResult.OK)
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
            }
            else
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
                    if (InputBox("Podaj klucz", "OK", "Podaj własny klucz (cyfra od 1 do 25):", ref value) == DialogResult.OK)
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

        }

        private void binariaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 50000)
            {
                if (MessageBox.Show("Tekst który próbujesz zaszyfrować może okazać się zbyt długi. Kontynuowanie może spowodować zatrzymanie pracy programu. Czy chcesz kontynuować?", "Duża ilość znaków", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            }
            else
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

        }

        private void brainFuckToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 50000)
            {
                if (MessageBox.Show("Tekst który próbujesz zaszyfrować może okazać się zbyt długi. Kontynuowanie może spowodować zatrzymanie pracy programu. Czy chcesz kontynuować?", "Duża ilość znaków", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                        richTextBox1.Text = strToBf(richTextBox1.Text);
                    }
                    else
                    {

                        MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na BrainFuck.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                    }
                }
            }
            else
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
                    richTextBox1.Text = strToBf(richTextBox1.Text);
                }
                else
                {

                    MessageBox.Show("Wykryto nieprawidłowy znak w dokumencie. Nie można zamienić na BrainFuck.\nUsuń znaki nie należące do systemu ASCII i spróbuj ponownie.");
                }
            }
        }

        private void tripleDESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 50000)
            {
                if (MessageBox.Show("Tekst który próbujesz zaszyfrować może okazać się zbyt długi. Kontynuowanie może spowodować zatrzymanie pracy programu. Czy chcesz kontynuować?", "Duża ilość znaków", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string value = "";
                    if (InputBox("Podaj klucz", "OK", "Podaj własny klucz:", ref value) == DialogResult.OK)
                    {
                        richTextBox1.Text = tDESEncrypt(richTextBox1.Text, value);
                    }
                }
            }
            else
            {
                string value = "";
                if (InputBox("Podaj klucz", "OK", "Podaj własny klucz:", ref value) == DialogResult.OK)
                {
                    richTextBox1.Text = tDESEncrypt(richTextBox1.Text, value);
                }
            }


        }

        public static string BinToQMc(string bin)
        {
            string mfinal = String.Empty;
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                int ia = rand.Next(1, 10);
                switch (ia < 5)
                {
                    case true:
                        mfinal += " ";
                        break;
                    case false:
                        mfinal += "?";
                        break;
                }
            }
            int j = 0;
            string tmp = "";
            foreach (char ch in bin)
            {
                j++;
                tmp += ch;
                switch (j == 2)
                {
                    case true:
                        j = 0;
                        int ja = rand.Next(1, 10);
                        switch (ja < 5)
                        {
                            case true:
                                mfinal += " ";
                                break;
                            case false:
                                mfinal += "?";
                                break;
                        }
                        switch (tmp)
                        {
                            case "00":
                                mfinal += "??";
                                break;
                            case "01":
                                mfinal += " ?";
                                break;
                            case "10":
                                mfinal += "  ";
                                break;
                            case "11":
                                mfinal += "? ";
                                break;
                        }
                        int jb = rand.Next(1, 10);
                        switch (jb < 5)
                        {
                            case true:
                                mfinal += " ";
                                break;
                            case false:
                                mfinal += "?";
                                break;
                        }
                        tmp = "";
                        break;
                    case false:
                        break;
                }
            }
            string g1final = mfinal.Replace(" ", " | ");
            string g2final = g1final.Replace(" |  | ", "-");
            string g3final = g2final.Replace("--", "+");
            return g3final;
        }
        #endregion

        #region Decoding
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

        private void szyfrCezaraZWlasnymKluczemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int customCeasarKey;
            string value = "0";
            if (InputBox("Podaj klucz", "OK", "Podaj własny klucz (cyfra od 1 do 25):", ref value) == DialogResult.OK)
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

        private void brainFuckToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string brfToS;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Wybierz plik do otwarcia:";
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    brfToS = sr.ReadToEnd();

                    richTextBox1.Clear();
                    richTextBox1.Text = BFinterpreter(brfToS);


                    sr.Close();
                }
            }
        }

        private void tripleDESToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string value = "";
            if (InputBox("Podaj klucz", "OK", "Podaj własny klucz:", ref value) == DialogResult.OK)
            {
                string tDesString;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Wybierz plik do otwarcia:";
                if (openFile.ShowDialog() == DialogResult.OK)
                {

                    using (StreamReader sr = new StreamReader(openFile.FileName))
                    {
                        tDesString = sr.ReadToEnd();

                        richTextBox1.Text = tDESDecrypt(tDesString, value);
                        sr.Close();
                    }
                }
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
            if (InputBox("Podaj klucz", "OK", "Podaj własny klucz (cyfra od 1 do 25):", ref value) == DialogResult.OK)
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

        private void brainFuckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = BFinterpreter(richTextBox1.Text);

        }

        private void tripleDESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string value = "";
            if (InputBox("Podaj klucz", "OK", "Podaj własny klucz:", ref value) == DialogResult.OK)
            {

                richTextBox1.Text = tDESDecrypt(richTextBox1.Text, value);

            }
        }
        public static string QMcToBin(string qmc)
        {
            string g3qmc = "";
            foreach (char g3ch in qmc)
            {
                switch (g3ch)
                {
                    case '+':
                        g3qmc += "--";
                        break;
                    default:
                        g3qmc += g3ch;
                        break;
                }

            }
            string g2qmc = "";
            foreach (char g2ch in g3qmc)
            {
                switch (g2ch)
                {
                    case '-':
                        g2qmc += " |  | ";
                        break;
                    default:
                        g2qmc += g2ch;
                        break;
                }
            }
            string tqmc = "";
            foreach (char gch in g2qmc)
            {
                switch (gch)
                {
                    case '?':
                        tqmc += "?";
                        break;
                    case ' ':
                        break;
                    case '|':
                        tqmc += " ";
                        break;

                }
            }
            int nloop = 0;
            int mloop = 0;
            string tmp = "";
            string bin = "";
            foreach (char ch in tqmc)
            {
                nloop++;
                mloop++;
                switch (nloop)
                {
                    case 1:
                        break;
                    case 2:
                        tmp += ch;
                        break;
                    case 3:
                        tmp += ch;
                        break;
                    case 4:
                        nloop = 0;
                        switch (mloop == 4)
                        {
                            case true:
                                tmp = "";
                                break;
                            case false:
                                switch (tmp)
                                {
                                    case "??":
                                        bin += "00";
                                        tmp = "";
                                        break;
                                    case " ?":
                                        bin += "01";
                                        tmp = "";
                                        break;
                                    case "  ":
                                        bin += "10";
                                        tmp = "";
                                        break;
                                    case "? ":
                                        bin += "11";
                                        tmp = "";
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
            return bin;
        }
        #endregion

        #region Encoding/Decoding Functions

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

        public static string ceasarDecipher(string ceasarDecipherInput, int ceasarDecipherKey)
        {
            return ceasarCipher(ceasarDecipherInput, 26 - ceasarDecipherKey);
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


        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public string BFinterpreter(string input)
        {
            string output = "";
            byte[] tape;
            int pointer = 0;
            char[] chinput;
            chinput = input.ToCharArray();
            tape = new byte[300000];
            var unmatchedBracketCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '>':
                        pointer++;
                        break;
                    case '<':
                        pointer--;
                        break;
                    case '+':
                        tape[pointer]++;
                        break;
                    case '-':
                        tape[pointer]--;
                        break;
                    case '.':
                        output += Convert.ToChar(tape[pointer]);
                        break;
                    case ',':
                        output += " ";
                        break;
                    case '[':
                        if (tape[pointer] == 0)
                        {
                            unmatchedBracketCounter++;
                            while (input[i] != ']' || unmatchedBracketCounter != 0)
                            {
                                i++;

                                if (input[i] == '[')
                                {
                                    unmatchedBracketCounter++;
                                }
                                else if (input[i] == ']')
                                {
                                    unmatchedBracketCounter--;
                                }
                            }
                        }
                        break;
                    case ']':
                        if (tape[pointer] != 0)
                        {
                            unmatchedBracketCounter++;
                            while (input[i] != '[' || unmatchedBracketCounter != 0)
                            {
                                i--;

                                if (input[i] == ']')
                                {
                                    unmatchedBracketCounter++;
                                }
                                else if (input[i] == '[')
                                {
                                    unmatchedBracketCounter--;
                                }
                            }
                        }
                        break;
                }
            }
            return output;

        }

        public static string strToBf(string input)
        {
            string s = "++++++++++" + "[";
            string t = "";
            string s2 = "";
            string s3 = "";
            foreach (char ch in input)
            {
                int i_ord = (int)ch;
                int i_cdc = cdc((int)ch);
                int i_max = 256 - i_ord;
                string s1 = "";
                string t1 = "";

                if (i_max < 128)
                {
                    for (int i = 0; i < i_max; i++)
                    {
                        s1 += '-';
                    }
                }
                else
                {
                    for (int i = 0; i < i_cdc / 10; i++)
                    {
                        s1 += '+';
                    }
                }
                s += '>' + s1;
                if (i_ord - i_cdc > 0)
                {
                    for (int i = 0; i < Math.Abs(i_ord - i_cdc); i++)
                    {
                        t1 += '+';
                    }

                }
                else
                {
                    for (int i = 0; i < Math.Abs(i_ord - i_cdc); i++)
                    {
                        t1 += '-';
                    }
                }
                t += '>' + t1;
            }
            for (int i = 0; i < input.Length; i++)
            {
                s2 += '<';
            }
            for (int i = 0; i < input.Length - 1; i++)
            {
                s3 += '<';
            }
            s += s2 + "-]" + t + s3 + "[.>]";
            return s;
        }
        public static int cdc(int i)
        {
            int t = i % 10;
            if (t > 5)
            {
                i += 10;
            }
            return i - t;
        }

        public static string tDESEncrypt(string toEncrypt, string enkey)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            string key = enkey;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string tDESDecrypt(string cipherString, string dekey)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);
            string key = dekey;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        private static string binToAT(string bin)
        {
            string binAT = "";
            int loop = 0;
            int loop2 = 0;
            foreach (char ch in bin)
            {
                loop++;
                switch (loop)
                {
                    case 1:
                        switch (ch == '0')
                        {
                            case true:
                                binAT += "a";
                                break;
                            case false:
                                binAT += "A";
                                break;
                        }
                        break;
                    case 2:
                        switch (ch == '0')
                        {
                            case true:
                                binAT += "d";
                                break;
                            case false:
                                binAT += "D";
                                break;
                        }
                        break;
                    case 3:
                        switch (ch == '0')
                        {
                            case true:
                                binAT += "i";
                                break;
                            case false:
                                binAT += "I";
                                break;
                        }
                        break;
                    case 4:
                        switch (ch == '0')
                        {
                            case true:
                                binAT += "x";
                                break;
                            case false:
                                binAT += "X";
                                break;
                        }
                        loop2++;
                        switch (loop2 == 10)
                        {
                            case true:
                                binAT += "\n";
                                loop = 0;
                                loop2 = 0;
                                break;
                            case false:
                                binAT += " | ";
                                loop = 0;
                                break;
                        }

                        break;
                }
            }
            return binAT;
        }
        public static string ATToBin(string at)
        {
            string bin = "";
            foreach (char ch in at)
            {
                switch (ch)
                {
                    case 'A':
                        bin += "1";
                        break;
                    case 'D':
                        bin += "1";
                        break;
                    case 'I':
                        bin += "1";
                        break;
                    case 'X':
                        bin += "1";
                        break;
                    case 'a':
                        bin += "0";
                        break;
                    case 'd':
                        bin += "0";
                        break;
                    case 'i':
                        bin += "0";
                        break;
                    case 'x':
                        bin += "0";
                        break;
                    default:
                        break;
                }
            }
            return bin;
        }
        #endregion

        #region Actions
        private void saveAs(string textToSave)
        {

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Zapisz plik jako:";
            saveFile.Filter = txt + tl + all + html + css + js + json + rtf + bat + sh + fas + ada + asm + mib + asp + au3 + avs + bc + bb + bf + c + ml + cmake + cbl + orc + coffee + cpp + cs + d + diff + erl + src + forth + f + f77 + bi + hs + ini + iss + hex + java + jsp + kix + lsp + tex + lua + mak + m + mms + nim + tab + nfo + nsh + osx + mm + pp + pl + php + ps + ps1 + properties + pb + py + r + reb + reg + rc + rb + rs + scm + st + scp + sql + mot + swift + tcl + tek + vb + t2t + v + vhd + pro + xml + yaml;
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

        private void resetColors()
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = bgColor;
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
            richTextBox1.DeselectAll();
        }
        #endregion

        #region Controls
        private void timer1_Tick(object sender, EventArgs e)
        {
            line = 1 + richTextBox1.GetLineFromCharIndex(richTextBox1.GetFirstCharIndexOfCurrentLine());
            column = 1 + richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine();
            toolStripStatusLabel1.Text = "Wiersz: " + line.ToString() + " | Kolumna: " + column.ToString();
            toolStripStatusLabel1.Margin = new Padding(0, 3, statusStrip1.Width - toolStripStatusLabel2.Width - 270, 2);
            int words;
            switch (richTextBox1.Text)
            {
                case "":
                    words = 0;
                    break;
                default:
                    MatchCollection wordColl = Regex.Matches(richTextBox1.Text, @"[\W]+");
                    words = wordColl.Count + 1;
                    break;
            }

            toolStripStatusLabel2.Text = "Znaków: " + richTextBox1.Text.Length.ToString() + " | Słów: " + words;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, new PointF(100, 100));

        }
        #endregion

        #region Declarations
        Color bgColor = new Color();
        SpeechSynthesizer voice = new SpeechSynthesizer();
        #endregion

        #region Extra
        public static DialogResult InputBox(string title, string okButtonText, string promptText, ref string value)
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


        public static DialogResult InputBoxDouble(string title, string promptText, string promptText2, ref string value, ref string value2, ref bool regex)
        {
            Form form = new Form();
            Label label = new Label();
            Label label2 = new Label();
            TextBox textBox = new TextBox();
            TextBox textBox2 = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            CheckBox checkBox = new CheckBox();

            form.Text = title;
            label.Text = promptText;
            label2.Text = promptText2;
            textBox.Text = value;
            textBox2.Text = value2;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Anuluj";
            checkBox.Text = "Zaawansowane wybieranie tekstu (Regex)";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 15, 372, 13);
            textBox.SetBounds(12, 31, 372, 20);
            label2.SetBounds(9, 55, 372, 13);
            textBox2.SetBounds(12, 71, 372, 20);
            checkBox.SetBounds(12, 95, 372, 20);
            buttonOk.SetBounds(228, 127, 75, 23);
            buttonCancel.SetBounds(309, 127, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            label2.AutoSize = true;
            textBox2.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 160);
            form.Controls.AddRange(new Control[] { label, textBox, label2, textBox2, checkBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            value2 = textBox2.Text;
            regex = checkBox.Checked;
            return dialogResult;
        }





        #endregion


        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            string val1 = "";
            string val2 = "";
            bool regex = false;
            if (InputBoxDouble("Zamień", "Tekst który będzie zamieniony", "Tekst na który będzie zamieniony", ref val1, ref val2, ref regex) == DialogResult.OK)
            {
                if (regex)
                {
                    if (val1 == "")
                    {
                        MessageBox.Show("Pierwsze pole nie może pozostać puste");
                    }
                    else
                    {
                        try
                        {
                            //Regex jregex = new Regex(val1);
                            //Match match = jregex.Match(richTextBox1.Text);
                            //if (match.Success)
                            //{
                            //    richTextBox1.Text = richTextBox1.Text.Replace(match.Value, val2);
                            //}



                            Regex jregex = new Regex(val1);
                            Match match = jregex.Match(richTextBox1.Text);
                            int start = 0;
                            int end = richTextBox1.Text.LastIndexOf(match.Value);

                            while (start <= end)
                            {
                                try
                                {
                                    jregex = new Regex(val1);
                                    match = jregex.Match(richTextBox1.Text.Substring(start));
                                    if (match.Success)
                                    {
                                        richTextBox1.Text = richTextBox1.Text.Replace(match.Value, val2);
                                    }

                                    start = richTextBox1.Text.IndexOf(match.Value, start) + 1;
                                }
                                catch
                                {
                                }

                            }

                        }
                        catch
                        {                           
                        }
                        

                    }
                }
                else
                {
                    if (val1 == "")
                    {
                        MessageBox.Show("Pierwsze pole nie może pozostać puste");
                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text.Replace(val1, val2);
                    }
                }
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            string text = "";
            if (InputBox("Zaawansowane wyszukiwanie (Regex)", "Szukaj", "Szablon", ref text) == DialogResult.OK)
            {

                int start = 0;
                int end = richTextBox1.Text.LastIndexOf(toolStripTextBox1.Text);

                while (start <= end)
                {
                    try
                    {
                        Regex jregex = new Regex(text);
                        Match match = jregex.Match(richTextBox1.Text.Substring(start));
                        if (match.Success)
                        {
                            richTextBox1.Find(match.Value, start, richTextBox1.TextLength, RichTextBoxFinds.MatchCase);
                            richTextBox1.SelectionBackColor = Color.Blue;
                            richTextBox1.SelectionColor = Color.Black;
                        }

                        start = richTextBox1.Text.IndexOf(toolStripTextBox1.Text, start) + 1;
                    }
                    catch
                    {
                        
                    }
                    
                }
                richTextBox1.DeselectAll();

            }
        }
    }
}
