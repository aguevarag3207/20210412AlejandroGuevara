using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AlejandroGuevaraExamenCrecer.Models;

namespace AlejandroGuevaraExamenCrecer.Data
{
    public class DataCita
    {
        public bool NuevaCita(ModelCIta obj )
        {
            bool resp = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
           
            conexion = Conexion.getInstance().ConexionBD();
            cmd = new SqlCommand("sp_nuevaCita", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idPaciente", obj.paciente);
            cmd.Parameters.AddWithValue("@idmedico", obj.medico);
            cmd.Parameters.AddWithValue("@fecha", obj.fecha);
            cmd.Parameters.AddWithValue("@hora", obj.hora);

            try
            {
                cmd.ExecuteNonQuery();
                resp = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            conexion.Close();
            return resp;   
        }

    }
}
