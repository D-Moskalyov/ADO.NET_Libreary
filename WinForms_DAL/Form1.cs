using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using NortwindDAL;

namespace WinForms_DAL
{
    public partial class Form1 : Form
    {
        int listDataType = 0;

        ArrayList booksList = new ArrayList();
        ArrayList writersList = new ArrayList();
        ArrayList publichersList = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

          if(  DataBase.GetSqlConnection().State == ConnectionState.Open)
          {
              label1.BackColor = Color.Green;
          }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listDataType = 1;
            
            if (BooksManager.Books.Count() != 0)
            {
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                booksList.Clear();

                for (int i = 0; i < BooksManager.Books.Count(); i++)
                {
                    booksList.Add(new Book(BooksManager.Books[i], BooksManager.Books[i].Title));
                    //listBox1.Items.Add(BooksManager.Books[i].Title);
                }

                listBox1.DataSource = booksList;
                listBox1.DisplayMember = "Title";
                listBox1.ValueMember = "BookFromList";
            }
            else
            {
                if (DataBase.GetStateConnection())
                {
                    listBox1.DataSource = null;
                    listBox1.Items.Clear();
                    booksList.Clear();

                    string query = "select * from Books";
                    //SqlConnection connection = DataBase.GetSqlConnection();
                    SqlCommand command = new SqlCommand(query, DataBase.Sql);
                    SqlDataReader reader = command.ExecuteReader();
                    //BooksManager booksMng = new BooksManager();
                    BooksManager.LoadBook(reader);

                    //List<Books> bks = booksMng.Books;
                    for (int i = 0; i < BooksManager.Books.Count(); i++)
                    {
                        booksList.Add(new Book(BooksManager.Books[i], BooksManager.Books[i].Title));
                        //listBox1.Items.Add(BooksManager.Books[i].Title);
                    }

                    listBox1.DataSource = booksList;
                    listBox1.DisplayMember = "Title";
                    listBox1.ValueMember = "BookFromList";

                    reader.Close();
                }
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listDataType = 2;

            if (WritersManager.Writers.Count() != 0)
            {
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                writersList.Clear();

                for (int i = 0; i < WritersManager.Writers.Count(); i++)
                {
                    writersList.Add(new Writer(WritersManager.Writers[i], WritersManager.Writers[i].FirstName, WritersManager.Writers[i].LastName));
                    //listBox1.Items.Add(string.Format("{0} {1}", WritersManager.Writers[i].FirstName, WritersManager.Writers[i].LastName));
                }

                listBox1.DataSource = writersList;
                listBox1.DisplayMember = "FirstLastName";
                listBox1.ValueMember = "WriterFromList";
            }
            else
            {
                if (DataBase.GetStateConnection())
                {
                    listBox1.DataSource = null;
                    listBox1.Items.Clear();
                    writersList.Clear();

                    string query = "select * from Writers";
                    //SqlConnection connection = DataBase.GetSqlConnection();
                    SqlCommand command = new SqlCommand(query, DataBase.Sql);
                    SqlDataReader reader = command.ExecuteReader();
                    //WritersManager writersMng = new WritersManager();
                    WritersManager.LoadWriter(reader);

                    for (int i = 0; i < WritersManager.Writers.Count(); i++)
                    {
                        writersList.Add(new Writer(WritersManager.Writers[i], WritersManager.Writers[i].FirstName, WritersManager.Writers[i].LastName));
                        //listBox1.Items.Add(string.Format("{0} {1}", WritersManager.Writers[i].FirstName, WritersManager.Writers[i].LastName));
                    }

                    listBox1.DataSource = writersList;
                    listBox1.DisplayMember = "FirstLastName";
                    listBox1.ValueMember = "WriterFromList";

                    reader.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listDataType = 3;
            if (PublichersManager.Publichers.Count() != 0)
            {
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                publichersList.Clear();

                for (int i = 0; i < PublichersManager.Publichers.Count(); i++)
                {
                    publichersList.Add(new Publicher(PublichersManager.Publichers[i], PublichersManager.Publichers[i].Title));
                    //listBox1.Items.Add(PublichersManager.Publichers[i].Title);
                }

                listBox1.DataSource = publichersList;
                listBox1.DisplayMember = "Title";
                listBox1.ValueMember = "PublicherFromList";
            }
            else
            {
                if (DataBase.GetStateConnection())
                {
                    listBox1.DataSource = null;
                    listBox1.Items.Clear();
                    publichersList.Clear();

                    string query = "select * from Publichers";
                    //SqlConnection connection = DataBase.GetSqlConnection();
                    SqlCommand command = new SqlCommand(query, DataBase.Sql);
                    SqlDataReader reader = command.ExecuteReader();
                    //PublichersManager publichersMng = new PublichersManager();
                    PublichersManager.LoadPublicher(reader);

                    for (int i = 0; i < PublichersManager.Publichers.Count(); i++)
                    {
                        publichersList.Add(new Publicher(PublichersManager.Publichers[i], PublichersManager.Publichers[i].Title));
                        //listBox1.Items.Add(PublichersManager.Publichers[i].Title);
                    }

                    listBox1.DataSource = publichersList;
                    listBox1.DisplayMember = "Title";
                    listBox1.ValueMember = "PublicherFromList";

                    reader.Close();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBase.BeforeClosing();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataBase.BeforeClosing();
            //listBox1.Items.Clear();
            label1.BackColor = Color.Red;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex != -1)
            //{
            //    MessageBox.Show(((Book)listBox1.SelectedItem).Title.ToString());
            //    // If we also wanted to get the displayed text we could use
            //    // the SelectedItem item property:
            //    // string s = ((USState)ListBox1.SelectedItem).LongName;
            //}

            //string date = listBox1.SelectedItem.ToString();
            //int nums = 0;
            Form3 form3;
            //Label lb;
            //TextBox tB;

            switch (listDataType)
            {
                case 1:
                    //for (int i = 0; i < BooksManager.Books.Count; i++)
                    //{
                    //    if (BooksManager.Books[i].Title == date)
                    //        nums = i;
                    //}
                    form3 = new Form3((Books)listBox1.SelectedValue);
                    form3.Show();

                    //for (int i = 0; i < 4; i++)
                    //{
                    //    lb = new Label();
                    //    lb.Location = new System.Drawing.Point(5, i * 20 + i * 2 + 5);
                    //    lb.AutoSize = true;
                    //    switch (i)
                    //    {
                    //        case 0: lb.Text = "BookID :"; break;
                    //        case 1: lb.Text = "Title :"; break;
                    //        case 2: lb.Text = "WriterID :"; break;
                    //        case 3: lb.Text = "PublicherID :"; break;
                    //        default: break;
                    //    }


                    //    tB = new TextBox();
                    //    tB.Location = new System.Drawing.Point(90, i * 20 + i * 2 + 5);
                    //    tB.Size = new System.Drawing.Size(222, 20);
                    //    tB.ReadOnly = true;
                    //    switch (i)
                    //    {
                    //        case 0: tB.Text = BooksManager.Books[nums].BookID.ToString(); break;
                    //        case 1: tB.Text = BooksManager.Books[nums].Title.ToString(); break;
                    //        case 2: tB.Text = BooksManager.Books[nums].WriterID.ToString(); break;
                    //        case 3: tB.Text = BooksManager.Books[nums].PublicherID.ToString(); break;
                    //        default: break;
                    //    }

                    //    form3.Controls.Add(lb);
                    //    form3.Controls.Add(tB);
                    //    //Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);
                    //}
                    break;
                case 2:
                    form3 = new Form3((Writers)listBox1.SelectedValue);
                    form3.Show();
                    //int num = date.IndexOf(" ");
                    //char[] lastName = date.ToCharArray(num + 1, date.Length - num - 1);
                    //string last = new string(lastName);
                    //for (int i = 0; i < WritersManager.Writers.Count; i++)
                    //{
                    //    if (WritersManager.Writers[i].LastName == last)
                    //        nums = i;
                    //}
                    //form3.Show();

                    //for (int i = 0; i < 3; i++)
                    //{
                    //    lb = new Label();
                    //    lb.Location = new System.Drawing.Point(5, i * 20 + i * 2 + 5);
                    //    lb.AutoSize = true;
                    //    switch (i)
                    //    {
                    //        case 0: lb.Text = "WriterID :"; break;
                    //        case 1: lb.Text = "First Name :"; break;
                    //        case 2: lb.Text = "Last Name :"; break;
                    //        default: break;
                    //    }


                    //    tB = new TextBox();
                    //    tB.Location = new System.Drawing.Point(90, i * 20 + i * 2 + 5);
                    //    tB.Size = new System.Drawing.Size(222, 20);
                    //    tB.ReadOnly = true;
                    //    switch (i)
                    //    {
                    //        case 0: tB.Text = WritersManager.Writers[nums].WriterID.ToString(); break;
                    //        case 1: tB.Text = WritersManager.Writers[nums].FirstName.ToString(); break;
                    //        case 2: tB.Text = WritersManager.Writers[nums].LastName.ToString(); break;
                    //        default: break;
                    //    }

                    //    form3.Controls.Add(lb);
                    //    form3.Controls.Add(tB);
                    //    //Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);
                    //}

                    break;
                case 3:
                    //for (int i = 0; i < PublichersManager.Publichers.Count; i++)
                    //{
                    //    if (PublichersManager.Publichers[i].Title == date)
                    //        nums = i;
                    //}
                    form3 = new Form3((Publichers)listBox1.SelectedValue);
                    form3.Show();
                    //for (int i = 0; i < 2; i++)
                    //{
                    //    lb = new Label();
                    //    lb.Location = new System.Drawing.Point(5, i * 20 + i * 2 + 5);
                    //    lb.AutoSize = true;
                    //    switch (i)
                    //    {
                    //        case 0: lb.Text = "PublicherID :"; break;
                    //        case 1: lb.Text = "Title :"; break;
                    //        default: break;
                    //    }


                    //    tB = new TextBox();
                    //    tB.Location = new System.Drawing.Point(90, i * 20 + i * 2 + 5);
                    //    tB.Size = new System.Drawing.Size(222, 20);
                    //    tB.ReadOnly = true;
                    //    switch (i)
                    //    {
                    //        case 0: tB.Text = PublichersManager.Publichers[nums].PublicherID.ToString(); break;
                    //        case 1: tB.Text = PublichersManager.Publichers[nums].Title.ToString(); break;
                    //        default: break;
                    //    }

                    //    form3.Controls.Add(lb);
                    //    form3.Controls.Add(tB);
                    //    //Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);
                    //}
                    break;
                default: break;
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (BooksManager.Books.Count != 0 || WritersManager.Writers.Count != 0 || PublichersManager.Publichers.Count != 0)
            {
                if (!DataBase.GetStateConnection())
                {
                    if (DataBase.GetSqlConnection().State == ConnectionState.Open)
                    {
                        if (BooksManager.Books.Count != 0)
                        {
                            foreach (Books bks in BooksManager.Books)
                            {
                                string query = string.Format("update Books set Title = '{0}' where BookID = {1}", bks.Title, bks.BookID);
                                SqlConnection connection = DataBase.GetSqlConnection();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }
                        }

                        if (WritersManager.Writers.Count != 0)
                        {
                            foreach (Writers wrt in WritersManager.Writers)
                            {
                                string query = string.Format("update Writers set FirstName = '{0}', LastName = '{1}' where WriterID = {2}", wrt.FirstName, wrt.LastName, wrt.WriterID);
                                SqlConnection connection = DataBase.GetSqlConnection();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }
                        }

                        if (PublichersManager.Publichers.Count != 0)
                        {
                            foreach (Publichers plch in PublichersManager.Publichers)
                            {
                                string query = string.Format("update Publichers set Title = '{0}' where PublicherID = {1}", plch.Title, plch.PublicherID);
                                SqlConnection connection = DataBase.GetSqlConnection();
                                SqlCommand command = new SqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    if (BooksManager.Books.Count != 0)
                    {
                        foreach (Books bks in BooksManager.Books)
                        {
                            string query = string.Format("update Books set Title = '{0}' where BookID = {1}", bks.Title, bks.BookID);
                            SqlConnection connection = DataBase.GetSqlConnection();
                            SqlCommand command = new SqlCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                    }

                    if (WritersManager.Writers.Count != 0)
                    {
                        foreach (Writers wrt in WritersManager.Writers)
                        {
                            string query = string.Format("update Writers set FirstName = '{0}', LastName = '{1}' where WriterID = {2}", wrt.FirstName, wrt.LastName, wrt.WriterID);
                            SqlConnection connection = DataBase.GetSqlConnection();
                            SqlCommand command = new SqlCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                    }

                    if (PublichersManager.Publichers.Count != 0)
                    {
                        foreach (Publichers plch in PublichersManager.Publichers)
                        {
                            string query = string.Format("update Publichers set Title = '{0}' where PublicherID = {1}", plch.Title, plch.PublicherID);
                            SqlConnection connection = DataBase.GetSqlConnection();
                            SqlCommand command = new SqlCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

    }
}

//Класс Empl. Все поля из БД. Возможость загрузки из БД
//Класс EmplManager. Через него добавлять, удалять, отображать
//Получение данных о всех Empl и отключение от базы
//Редактирование в главном окне
//Возможность сохранить изменения в объектах Empl
//Возможность сохранить изменения в БД