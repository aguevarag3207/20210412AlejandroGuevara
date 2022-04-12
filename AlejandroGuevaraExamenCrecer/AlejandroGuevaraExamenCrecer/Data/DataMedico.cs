using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AlejandroGuevaraExamenCrecer.Models;

namespace AlejandroGuevaraExamenCrecer.Data
{
    public class DataMedico
    {
        public List<ModelMedico> Consultamedico()
        {
            List<ModelMedico> lstMedico = new List<ModelMedico>();
           
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("sp_lista_medico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ModelMedico obj = new ModelMedico();
                    obj.idmedico = Convert.ToInt32(dr["idmedico"].ToString());
                    obj.nombre = dr["nombre"].ToString();
                    obj.nombreespecialidad = dr["nombreespecialidad"].ToString();

                    lstMedico.Add(obj);
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

            return lstMedico;
        }
    }
}
