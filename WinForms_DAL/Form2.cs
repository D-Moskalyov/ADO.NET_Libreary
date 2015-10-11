using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NortwindDAL;

namespace WinForms_DAL
{
    public partial class Form2 : Form
    {
        int choice = 0;

        public Form2()
        {
            InitializeComponent();
            this.ActiveControl = this.checkBox1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<int> checkListWriters = new List<int>();
            List<int> checkListpublishers = new List<int>();
            switch (choice)
            {
                case 1:
                    if (BooksManager.SearchConnect())
                    {

                        ((Form1)(this.Owner)).Label1.BackColor = Color.Green;
                        foreach (Books book in BooksManager.Books)
                        {
                            if (book.Title == textBox1.Text)
                            {
                                listBox1.Items.Add(string.Format("{0} {1} {2} {3} {4}", book.BookID.ToString(), book.Title, WritersManager.GetWriter(book.WriterID).FirstName.ToString(), WritersManager.GetWriter(book.WriterID).LastName.ToString(), PublichersManager.GetPublicher(book.PublicherID).Title.ToString()));
                            }
                        }
                    }
                    break;
                case 2:
                    if (BooksManager.SearchConnect())
                    {
                        ((Form1)(this.Owner)).Label1.BackColor = Color.Green;
                        foreach (Writers writer in WritersManager.Writers)
                        {
                            if (writer.FirstName == textBox2.Text || writer.LastName == textBox2.Text)
                            {
                                checkListWriters.Add(writer.WriterID);
                            }
                        }
                        foreach (Books book in BooksManager.Books)
                        {
                            if (checkListWriters.Contains(book.WriterID))
                            {
                                listBox1.Items.Add(string.Format("{0} {1} {2} {3} {4}", book.BookID.ToString(), book.Title, WritersManager.GetWriter(book.WriterID).FirstName.ToString(), WritersManager.GetWriter(book.WriterID).LastName.ToString(), PublichersManager.GetPublicher(book.PublicherID).Title.ToString()));
                            }
                        }
                    }
                    break;
                case 3:
                    if (BooksManager.SearchConnect())
                    {
                        foreach (Writers writer in WritersManager.Writers)
                        {
                            if (writer.FirstName == textBox2.Text || writer.LastName == textBox2.Text)
                            {
                                checkListWriters.Add(writer.WriterID);
                            }
                        }
                        foreach (Books book in BooksManager.Books)
                        {
                            if (book.Title == textBox1.Text && checkListWriters.Contains(book.WriterID))
                            {
                                listBox1.Items.Add(string.Format("{0} {1} {2} {3} {4}", book.BookID.ToString(), book.Title, WritersManager.GetWriter(book.WriterID).FirstName.ToString(), WritersManager.GetWriter(book.WriterID).LastName.ToString(), PublichersManager.GetPublicher(book.PublicherID).Title.ToString()));
                            }
                        }
                    }
                    break;
                case 4:
                    if (BooksManager.SearchConnect())
                    {
                        foreach (Publichers publicher in PublichersManager.Publichers)
                        {
                            if (publicher.Title == textBox3.Text)
                            {
                                checkListpublishers.Add(publicher.PublicherID);
                            }
                        }
                        foreach (Books book in BooksManager.Books)
                        {
                            if (checkListpublishers.Contains(book.PublicherID))
                            {
                                listBox1.Items.Add(string.Format("{0} {1} {2} {3} {4}", book.BookID.ToString(), book.Title, WritersManager.GetWriter(book.WriterID).FirstName.ToString(), WritersManager.GetWriter(book.WriterID).LastName.ToString(), PublichersManager.GetPublicher(book.PublicherID).Title.ToString()));
                            }
                        }
                    }
                    break;
                case 5:
                    if (BooksManager.SearchConnect())
                    {
                        //MessageBox.Show("5");
                        foreach (Publichers publicher in PublichersManager.Publichers)
                        {
                            if (publicher.Title == textBox3.Text)
                            {
                                checkListpublishers.Add(publicher.PublicherID);
                            }
                        }
                        foreach (Books book in BooksManager.Books)
                        {
                            if (book.Title == textBox1.Text && checkListpublishers.Contains(book.PublicherID))
                            {
                                listBox1.Items.Add(string.Format("{0} {1} {2} {3} {4}", book.BookID.ToString(), book.Title, WritersManager.GetWriter(book.WriterID).FirstName.ToString(), WritersManager.GetWriter(book.WriterID).LastName.ToString(), PublichersManager.GetPublicher(book.PublicherID).Title.ToString()));
                            }
                        }
                    }
                    break;
                case 6:
                    if (BooksManager.SearchConnect())
                    {
                        foreach (Writers writer in WritersManager.Writers)
                        {
                            if (writer.FirstName == textBox2.Text || writer.LastName == textBox2.Text)
                            {
                                checkListWriters.Add(writer.WriterID);
                            }
                        }
                        foreach (Publichers publicher in PublichersManager.Publichers)
                        {
                            if (publicher.Title == textBox3.Text)
                            {
                                checkListpublishers.Add(publicher.PublicherID);
                            }
                        }
                        foreach (Books book in BooksManager.Books)
                        {
                            if (checkListpublishers.Contains(book.PublicherID) && checkListWriters.Contains(book.WriterID))
                            {
                                listBox1.Items.Add(string.Format("{0} {1} {2} {3} {4}", book.BookID.ToString(), book.Title, WritersManager.GetWriter(book.WriterID).FirstName.ToString(), WritersManager.GetWriter(book.WriterID).LastName.ToString(), PublichersManager.GetPublicher(book.PublicherID).Title.ToString()));
                            }
                        }
                    }
                    break;
                case 7:
                    if (BooksManager.SearchConnect())
                    {
                        foreach (Writers writer in WritersManager.Writers)
                        {
                            if (writer.FirstName == textBox2.Text || writer.LastName == textBox2.Text)
                            {
                                checkListWriters.Add(writer.WriterID);
                            }
                        }
                        foreach (Publichers publicher in PublichersManager.Publichers)
                        {
                            if (publicher.Title == textBox3.Text)
                            {
                                checkListpublishers.Add(publicher.PublicherID);
                            }
                        }
                        foreach (Books book in BooksManager.Books)
                        {
                            if (book.Title == textBox1.Text && checkListpublishers.Contains(book.PublicherID) && checkListWriters.Contains(book.WriterID))
                            {
                                listBox1.Items.Add(string.Format("{0} {1} {2} {3} {4}", book.BookID.ToString(), book.Title, WritersManager.GetWriter(book.WriterID).FirstName.ToString(), WritersManager.GetWriter(book.WriterID).LastName.ToString(), PublichersManager.GetPublicher(book.PublicherID).Title.ToString()));
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                choice += 1;
            else
                choice -= 1;
            //MessageBox.Show(choice.ToString());
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                choice += 2;
            else
                choice -= 2;
            //MessageBox.Show(choice.ToString());
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                choice += 4;
            else
                choice -= 4;
            //MessageBox.Show(choice.ToString());
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void textBox1_ForeColorChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_ForeColorChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_ForeColorChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

    }
}
