using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form_Invitacion : Form
    {

        public bool Aceptado { get; private set; } = false; //booleano para saber si se acepta o no invitación
        public Form_Invitacion(string mensaje)
        {
            InitializeComponent();
            Mensaje_lbl.Text = mensaje;
        }


        private void Form_Invitacion_Load(object sender, EventArgs e)
        {

        }

        private void Aceptar_btn_Click(object sender, EventArgs e) //Se acepta la invitación
        {
            Aceptado = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Rechazar_btn_Click(object sender, EventArgs e) //Se rechaza la invitación
        {
            Aceptado = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
