using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Android_resurce_renamer
{
    public partial class Form1 : Form
    {
        String folderWejsciowy;
        String folderZapisu;
        string[] listaplikow;



        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            folderWejsciowy = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialogfolderwejsciowy = new FolderBrowserDialog();
            if (dialogfolderwejsciowy.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderWejsciowy = dialogfolderwejsciowy.SelectedPath;
                textBox1.Text = folderWejsciowy;
                Odczytplików();
              //  MessageBox.Show(folderWejsciowy+"\n"+"Liczba plików: " +listaplikow.Length);
                textBox3.Text = listaplikow.Length.ToString();
               

            }


          //  OpenFileDialog openFileDialog1 = new OpenFileDialog();
          //  if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
          //  {
          //      folderWejsciowy = openFileDialog1.FileName;
          //      MessageBox.Show(folderWejsciowy);
          //
          //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialogfolderwejsciowy = new FolderBrowserDialog();
            if (dialogfolderwejsciowy.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderZapisu = dialogfolderwejsciowy.SelectedPath;
                textBox2.Text = folderZapisu;
             //   MessageBox.Show(folderZapisu);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderWejsciowy == null)
            {
                MessageBox.Show("Brak lokalizacji odczytu");
            }
            if (folderZapisu == null)
            {
                MessageBox.Show("Brak lokalizacji zapisu");
            }
            if (folderZapisu != null && folderWejsciowy != null)
            {
              //  MessageBox.Show("Procedura w toku");
                Odczytplików();
                Zapisplików();
            }
            

            
        }

        void Odczytplików()
        {
            listaplikow = Directory.GetFiles(folderWejsciowy);
           
        }
        void Zapisplików()
        {
            foreach (string f in listaplikow)
            {
                // Remove path from the file name.
                string fName = f.Substring(folderWejsciowy.Length + 1);
                string Operator = fName;

                Operator = Operator.Replace(".mp3", "");
                Operator = Operator.ToLower();
                Operator = Operator.Replace("ć", "c");
                Operator = Operator.Replace(" ", "_");
                Operator = Operator.Replace("1", "_");
                Operator = Operator.Replace("0", "_");
                Operator = Operator.Replace("2", "_");
                Operator = Operator.Replace("3", "_");
                Operator = Operator.Replace("4", "_");
                Operator = Operator.Replace("5", "_");
                Operator = Operator.Replace("6", "_");
                Operator = Operator.Replace("7", "_");
                Operator = Operator.Replace("8", "_");
                Operator = Operator.Replace("9", "_");
                Operator = Operator.Replace("-", "_");
                Operator = Operator.Replace("(", "_");
                Operator = Operator.Replace(")", "_");
                Operator = Operator.Replace(">", "_");
                Operator = Operator.Replace("<", "_");
                Operator = Operator.Replace("+", "_");
                Operator = Operator.Replace("ą", "aa");
                Operator = Operator.Replace("ć", "cc");
                Operator = Operator.Replace("ę", "ee");
                Operator = Operator.Replace("ó", "uu");
                Operator = Operator.Replace("ś", "ss");
                Operator = Operator.Replace("ż", "zzz");
                Operator = Operator.Replace("ł", "ll");
                Operator = Operator.Replace("ń", "nn");

                string fNwename = Operator+".mp3";

                // Use the Path.Combine method to safely append the file name to the path.
                // Will overwrite if the destination file already exists.
                File.Copy(Path.Combine(folderWejsciowy, fName), Path.Combine(folderZapisu, fNwename), true);
                
            }
            Spisplikuw();
        }
        void Spisplikuw()
        {
           // File.Create(folderZapisu + "\\update.txt");
            String content="Android ranamer v1    " + System.DateTime.Now + "\n";
            foreach (string f in listaplikow)
            {
                content = content + f.Substring(folderWejsciowy.Length + 1) + "\n";
            }
            content = content + "end////////////////////////////end";
            File.WriteAllText(folderZapisu+ "\\update.txt", content,Encoding.UTF8);
            MessageBox.Show("plik update dopisany");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (string f in listaplikow)
            {
                // Remove path from the file name.
                string fName = f.Substring(folderWejsciowy.Length + 1);
                string Operator = fName;

                Operator = Operator.Replace(".mp3", "");
                Operator = Operator.ToLower();
                Operator = Operator.Replace("_", " ");
                Operator = Operator.Replace("aa","ą");
                Operator = Operator.Replace("cc","ć");
                Operator = Operator.Replace("ee","ę");
                Operator = Operator.Replace("uu","ó");
                Operator = Operator.Replace("ss","ś");
                Operator = Operator.Replace("zzz","ż");
                Operator = Operator.Replace("ll","ł");
                Operator = Operator.Replace("nn", "ń");

                string fNwename = Operator + ".mp3";

                // Use the Path.Combine method to safely append the file name to the path.
                // Will overwrite if the destination file already exists.
                File.Copy(Path.Combine(folderWejsciowy, fName), Path.Combine(folderZapisu, fNwename), true);

            }
            Spisplikuw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
