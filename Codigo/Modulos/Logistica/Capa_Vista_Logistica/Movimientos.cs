﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
namespace Capa_Vista_Logistica
{
    public partial class Movimientos : Form
    {
        public Movimientos()
        {
            InitializeComponent();
            string idUsuario = "9005";
            string[] alias = { "id_movimiento", "estado", "id_producto", "id_stock", "bodega Destino", "sucursal Destino"};
            navegador1.AsignarAlias(alias);
            navegador1.AsignarSalida(this);
            navegador1.AsignarColorFondo(Color.CadetBlue);
            navegador1.AsignarColorFuente(Color.Black);
            navegador1.AsignarTabla("Tbl_movimiento_de_inventario");
            navegador1.ObtenerIdAplicacion("1000");
            navegador1.ObtenerIdUsuario(idUsuario);
            navegador1.AsignarAyuda("1");
            navegador1.AsignarNombreForm("Movimientos de Inventario");


            navegador1.Dgv_Informacion.CellClick += DgvMovimiento_CellClick;
        }

        private void DgvMovimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la fila seleccionada es válida
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = navegador1.Dgv_Informacion.Rows[e.RowIndex];
                string Pk_id_movimiento = row.Cells["Pk_id_movimiento"].Value.ToString();  // Asegúrate de que el nombre del campo sea correcto

                Movimiento_de_Inventario movInventario = new Movimiento_de_Inventario(Pk_id_movimiento);
                movInventario.Show();
            }
        }
    }
}
