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
using CurpValidator;
using Critza.Bibliotecas;

namespace DRSecurity.Presentacion
{
    public partial class Create : Form
    {
        public int? i;
        public Create(int? i=null)
        {
            InitializeComponent();
            this.i = i;
        }
        public void Cargar(string CurpAux)
        {
            using (testEntities5 db=new testEntities5())
            {
                var lstedit = new List<Get_Usr_Result>();
                lstedit = db.Get_Usr(cURP:CurpAux).ToList();
                var aux = lstedit.ElementAt(0);
                txtCalleN.Text = aux.Calle_y_Numero;
                txtColonia.Text = aux.Colonia;
                txtDelegaionM.Text = aux.Delegacion_Municipio; 
                txtENacimiento.Text = aux.Estado_de_Nacimiento;
                txtEstadoC.Text = aux.Estado_Ciudad;
                txtPApellido.Text = aux.Primer_Apellido;
                txtPNombre.Text = aux.Nombre;
                txtSApellido.Text = aux.Segundo_Apellido;
                txtSNombre.Text = aux.Nombre;
                comboBox1.Text = aux.Sexo;
                maskedTextBox1.Text = aux.Telefono;
                var auxdate = aux.Fecha_de_Nacimiento;
                dateTimePicker1.Value = Convert.ToDateTime(aux.Fecha_de_Nacimiento);

            }
        }

        private void Create_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (testEntities5 db=new testEntities5())
            {

                Curp crp2 = new Curp();
                string sexAux2 = comboBox1.Text;
                char sexAux = sexAux2[0];
                string CurpAux = crp2.ObtenCurp(txtPNombre.Text, txtPApellido.Text, txtSApellido.Text, sexAux, dateTimePicker1.Value.ToString(), txtENacimiento.Text);

                if (i == null) { 
                db.IUsuario(pNombre:txtPNombre.Text, sNombre:txtSNombre.Text, pApellido:txtPApellido.Text,sApellido:txtSApellido.Text,sexo:comboBox1.Text, telefono:maskedTextBox1.Text, fNacimiento:dateTimePicker1.Value,estadoC:txtEstadoC.Text, delegacionM:txtDelegaionM.Text,colonia:txtColonia.Text,calleN:txtCalleN.Text,eNacimiento:txtENacimiento.Text, cURP:CurpAux);
                }
                else
                {
                    db.Edit_Usr(pNombre: txtPNombre.Text, sNombre: txtSNombre.Text, pApellido: txtPApellido.Text, sApellido: txtSApellido.Text, sexo: comboBox1.Text, telefono: maskedTextBox1.Text, fNacimiento: dateTimePicker1.Value, estadoC: txtEstadoC.Text, delegacionM: txtDelegaionM.Text, colonia: txtColonia.Text, calleN: txtCalleN.Text, cURP: CurpAux);
                }
                this.Close(); 
            }
        }
    }
}
