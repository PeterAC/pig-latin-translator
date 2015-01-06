using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PigLatinTranslator
{
    public partial class frmPigLatinTranslator : Form
    {
        public frmPigLatinTranslator()
        {
            InitializeComponent();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            StringBuilder sbWord = new StringBuilder();
            StringBuilder sbAll= new StringBuilder();
            StringBuilder temp = new StringBuilder();
            List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            List<char> punctuation = new List<char>() { '.', '!', '?' };
            bool finalWord = false;
            char finalChar = ' ';

            foreach (string word in txtEnglish.Text.Split(' '))
            {
                sbWord.Append(word);

                if (punctuation.Contains(sbWord[sbWord.Length - 1]))
                {
                    finalChar = sbWord[sbWord.Length - 1];
                    sbWord.Remove(sbWord.Length - 1, 1);
                    finalWord = true;
                }

                switch (word[0])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                        sbWord.Append("way");
                        break;
                    default:
                        foreach (char c in word)
                        {
                            int i = 0;
                            if (!vowels.Contains(c))
                            {
                                if (Char.IsUpper(c))
                                {
                                    sbWord.Remove(i, 1);
                                    temp.Append(Char.ToLower(c));
                                    sbWord[0] = Char.ToUpper(sbWord[0]);
                                }
                                else
                                {
                                    sbWord.Remove(i, 1);
                                    temp.Append(c);
                                }  
                            }
                            else break;
                            i++;
                        }
                        sbWord.Append(temp);
                        sbWord.Append("ay");
                        temp.Clear();
                        break;
                }

                sbAll.Append(sbWord);
                if (finalWord) sbAll.Append(finalChar);
                sbWord.Clear();
                finalWord = false;
                sbAll.Append(" ");
            }

            txtPigLatin.Text = sbAll.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEnglish.Text = "";
            txtPigLatin.Text = "";
            txtEnglish.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPigLatinTranslator_Activated(object sender, EventArgs e)
        {
            txtEnglish.Focus();
        }
    }
}
