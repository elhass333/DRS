using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DRSecurity.Model;

namespace DRSecurity
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            using (testEntities5 db = new testEntities5())
            {
                var lst = db.Get_Usrs();
                dataGridView1.DataSource = lst.ToList();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            Presentacion.Create Create = new Presentacion.Create();
            Create.ShowDialog();
            Refresh();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CurpAux = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            if (CurpAux != null)
            {
                int i = 1;
                Presentacion.Create Create = new Presentacion.Create(i);
                Create.Cargar(CurpAux);
                Create.ShowDialog();
                Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string CurpAux = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            //if (CurpAux != null)
            //{
            //    int i = 1;
            //    Presentacion.Create Create= new Presentacion.Create(i);
            //    using( testEntities5 db = new testEntities5() )
            //    {
            //        db.Delete_Usr(CurpAux);

            //    }
            //        Refresh();
            }
        }
    }
}
