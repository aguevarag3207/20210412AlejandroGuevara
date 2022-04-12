using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AlejandroGuevaraExamenCrecer.Models;

namespace AlejandroGuevaraExamenCrecer.Data
{
    public class DataPaciente
    {
        public List<ModelPaciente> Consultamedico()
        {
            List<ModelPaciente> lst = new List<ModelPaciente>();

            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("sp_lista_paciente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ModelPaciente obj = new ModelPaciente();
                    obj.idpaciente = Convert.ToInt32(dr["idpaciente"].ToString());
                    obj.paciente = dr["paciente"].ToString();
                    obj.direccion = dr["direccion"].ToString();
                    obj.telefono = dr["telefono"].ToString();
                    obj.estado = Convert.ToInt32(dr["estado"].ToString());

                    lst.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return lst;
        }
    }
}
