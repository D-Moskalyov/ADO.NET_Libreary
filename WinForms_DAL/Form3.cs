using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NortwindDAL;

namespace WinForms_DAL
{
    public partial class Form3 : Form
    {
        private int type = 0;
        Books bks;
        Writers wrtrs;
        Publichers pblcrs;
        public Form3(Books bk)
        {
            bks = bk;
            type = 1;
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                Label lb = new Label();
                lb.Location = new System.Drawing.Point(5, i * 20 + i * 2 + 5);
                lb.AutoSize = true;
                switch (i)
                {
                    case 0: lb.Text = "BookID :"; break;
                    case 1: lb.Text = "Title :"; break;
                    case 2: lb.Text = "WriterID :"; break;
                    case 3: lb.Text = "PublicherID :"; break;
                    default: break;
                }


                TextBox tB = new TextBox();
                tB.Location = new System.Drawing.Point(90, i * 20 + i * 2 + 5);
                tB.Size = new System.Drawing.Size(222, 20);
                //tB.ReadOnly = true;
                switch (i)
                {
                    case 0: tB.Text = bk.BookID.ToString(); tB.ReadOnly = true; break;
                    //tB.Text = BooksManager.Books[nums].BookID.ToString(); break;
                    case 1: tB.Text = bk.Title; break;
                    //tB.Text = BooksManager.Books[nums].Title.ToString(); break;
                    case 2: tB.Text = bk.WriterID.ToString(); tB.ReadOnly = true; break;
                    //tB.Text = BooksManager.Books[nums].WriterID.ToString(); break;
                    case 3: tB.Text = bk.PublicherID.ToString(); tB.ReadOnly = true; break;
                    //tB.Text = BooksManager.Books[nums].PublicherID.ToString(); break;
                    default: break;
                }

                this.Controls.Add(lb);
                this.Controls.Add(tB);
                //Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);
            }
        }
        public Form3(Writers wrt)
        {
            wrtrs = wrt;
            type = 2;
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                Label lb = new Label();
                lb.Location = new System.Drawing.Point(5, i * 20 + i * 2 + 5);
                lb.AutoSize = true;
                switch (i)
                {
                    case 0: lb.Text = "WriterID :"; break;
                    case 1: lb.Text = "First Name :"; break;
                    case 2: lb.Text = "Last Name :"; break;
                    default: break;
                }


                TextBox tB = new TextBox();
                tB.Location = new System.Drawing.Point(90, i * 20 + i * 2 + 5);
                tB.Size = new System.Drawing.Size(222, 20);
                //tB.ReadOnly = true;
                switch (i)
                {
                    case 0: tB.Text = wrt.WriterID.ToString(); tB.ReadOnly = true; break;
                    case 1: tB.Text = wrt.FirstName.ToString(); break;
                    case 2: tB.Text = wrt.LastName.ToString(); break;
                    default: break;
                }

                this.Controls.Add(lb);
                this.Controls.Add(tB);
                //Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);
            }
        }
        public Form3(Publichers pbl)
        {
            pblcrs = pbl;
            type = 3;
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                Label lb = new Label();
                lb.Location = new System.Drawing.Point(5, i * 20 + i * 2 + 5);
                lb.AutoSize = true;
                switch (i)
                {
                    case 0: lb.Text = "PublicherID :"; break;
                    case 1: lb.Text = "Title :"; break;
                    default: break;
                }


                TextBox tB = new TextBox();
                tB.Location = new System.Drawing.Point(90, i * 20 + i * 2 + 5);
                tB.Size = new System.Drawing.Size(222, 20);
                
                switch (i)
                {
                    case 0: tB.Text = pbl.PublicherID.ToString(); tB.ReadOnly = true; break;
                    case 1: tB.Text = pbl.Title.ToString(); break;
                    default: break;
                }

                this.Controls.Add(lb);
                this.Controls.Add(tB);
                //Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TextBox> tBs = new List<TextBox>();
            switch(type)
            {
                case 1: 
                    foreach(Control cntrl in this.Controls)
                    {
                        if(cntrl is TextBox)
                            tBs.Add((TextBox)cntrl);
                    }
                    bks.Title = tBs[1].Text;
                    break;
                case 2: 
                    foreach(Control cntrl in this.Controls)
                    {
                        if(cntrl is TextBox)
                            tBs.Add((TextBox)cntrl);
                    }
                    wrtrs.FirstName = tBs[1].Text;
                    wrtrs.LastName = tBs[2].Text;
                    break;
                case 3: 
                    foreach(Control cntrl in this.Controls)
                    {
                        if(cntrl is TextBox)
                            tBs.Add((TextBox)cntrl);
                    }
                    pblcrs.Title = tBs[1].Text;
                    break;
                default: break;   
            }
            tBs.Clear();
        }
    }
}
