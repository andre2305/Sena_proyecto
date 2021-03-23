using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Sistema_Informacion.Models
{
    public class MantenimientoUsuario
    {
        private SqlConnection con;
        
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into usuarios(usu_Documento,usu_TipoDocumento, usu_Nombre, usu_Celular, usu_Email, usu_Genero, usu_Aprendiz, usu_Egresado, usu_AreaFormacion, usu_FechaEgresado, usu_Direccion, usu_Barrio, usu_Ciudad, usu_Departamento, usu_FechaRegistro) values (@documento, @tipodoc, @nombre, @celular, @email, @genero, @aprendiz, @egresado, @areaformacion, @fechaegresado, @direccion, @barrio, @ciudad, @departamento, @fecharegistro)",con);

            comando.Parameters.Add("@usu_Documento", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_TipoDocumento", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_Nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_Celular", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_Email", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_Genero", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_Aprendiz", SqlDbType.Bit);
            comando.Parameters.Add("@usu_Egresado", SqlDbType.Bit);
            comando.Parameters.Add("@usu_AreaFormacion", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_FechaEgresado", SqlDbType.Date);
            comando.Parameters.Add("@usu_Direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_Barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_Ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_Departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_FechaRegistro", SqlDbType.Date);

            comando.Parameters["@usu_Documento"].Value = usu.usu_Documento;
            comando.Parameters["@usu_TipoDocumento"].Value = usu.usu_TipoDocumento;
            comando.Parameters["@usu_Nombre"].Value = usu.usu_Nombre;
            comando.Parameters["@usu_Celular"].Value = usu.usu_Celular;
            comando.Parameters["@usu_Email"].Value = usu.usu_Email;      
            comando.Parameters["@usu_Genero"].Value = usu.usu_Genero;    
            comando.Parameters["@usu_Aprendiz"].Value = usu.usu_Aprendiz;
            comando.Parameters["@usu_Egresado"].Value = usu.usu_Egresado;
            comando.Parameters["@usu_AreaFormacion"].Value = usu.usu_AreaFormacion;
            comando.Parameters["@usu_FechaEgresado"].Value = usu.usu_FechaEgresado;
            comando.Parameters["@usu_Direccion"].Value = usu.usu_Direccion;
            comando.Parameters["@usu_Barrio"].Value = usu.usu_Barrio;
            comando.Parameters["@usu_Ciudad"].Value = usu.usu_Ciudad;
            comando.Parameters["@usu_Departamento"].Value = usu.usu_Departamento;
            comando.Parameters["@usu_FechaRegistro"].Value = usu.usu_FechaEgresado;       
            
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Usuario> RecuperarTodos()
        {
            Conectar();
            List<Usuario> usuarios = new List<Usuario>();

            SqlCommand com = new SqlCommand("select id, documento, tipodoc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {
                Usuario usu = new Usuario
                {
                    usu_ID=Convert.ToInt32(registros["id"]),
                    usu_Documento = registros["documento"].ToString(),
                    usu_TipoDocumento = registros["tipodoc"].ToString(),
                    usu_Nombre = registros["nombre"].ToString(),
                    usu_Celular = registros["celular"].ToString(),
                    usu_Email = registros["email"].ToString(),
                    usu_Genero = registros["genero"].ToString(),
                    usu_Aprendiz = Convert.ToInt32(registros["aprendiz"]),
                    usu_Egresado = Convert.ToInt32(registros["egresado"]),
                    usu_AreaFormacion = registros["areaformacion"].ToString(),
                    usu_FechaEgresado = DateTime.Parse(registros["fechaegresado"].ToString()),
                    usu_Direccion = registros["direccion"].ToString(),
                    usu_Barrio = registros["barrio"].ToString(),
                    usu_Ciudad = registros["ciudad"].ToString(),
                    usu_Departamento = registros["departamento"].ToString(),
                    usu_FechaRegistro = DateTime.Parse(registros["fecharegistro"].ToString())
                };
                usuarios.Add(usu);
            }
            con.Close();
            return usuarios;
        }

        public Usuario Recuperar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select usu_Id, usu_Documento, usu_TipoDocumento, usu_Nombre, usu_Celular, usu_Email, usu_Genero, usu_Aprendiz, usu_Egresado, usu_AreaFormacion, usu_FechaEgresado, usu_Direccion, usu_Barrio, usu_Ciudad, usu_Departamento, usu_FechaRegistro from usuarios where id=@usu_Id", con);
            comando.Parameters.Add("@usu_Id", SqlDbType.Int);
            comando.Parameters["@usu_Id"].Value = id;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            Usuario usuarios = new Usuario();

            if (registros.Read())
            {
                usuarios.usu_ID = Convert.ToInt32(registros["usu_Id"]);
                usuarios.usu_Documento =registros["usu_Documento"].ToString();
                usuarios.usu_TipoDocumento = registros["usu_TipoDocumento"].ToString();
                usuarios.usu_Nombre = registros["usu_Nombre"].ToString();
                usuarios.usu_Celular = registros["usu_Celular"].ToString();
                usuarios.usu_Email = registros["usu_Email"].ToString();
                usuarios.usu_Genero = registros["usu_Genero"].ToString();
                usuarios.usu_Aprendiz = Convert.ToInt32(registros["usu_Aprendiz"]);
                usuarios.usu_Egresado = Convert.ToInt32(registros["usu_Egresado"]);
                usuarios.usu_AreaFormacion = registros["usu_AreaFormacion"].ToString();
                usuarios.usu_FechaEgresado = DateTime.Parse(registros["usu_FechaEgresado"].ToString());
                usuarios.usu_Direccion = registros["usu_Direccion"].ToString();
                usuarios.usu_Barrio = registros["usu_Barrio"].ToString();
                usuarios.usu_Ciudad = registros["usu_Ciudad"].ToString();
                usuarios.usu_Departamento = registros["usu_Departamento"].ToString();
                usuarios.usu_FechaRegistro = DateTime.Parse(registros["usu_FechaEgresado"].ToString());
            }
            con.Close();
            return usuarios;           
        }

        public int Modificar(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update usuarios set tipodoc=@tipodoc, nombre=@nombre, celular=@celular, email=@email, genero=@genero, aprendiz=@aprendiz, egresado=@egresado, areaformacion=@areaformacion, fechaegresado=@fechaegresado, direccion=@direccion, barrio=@barrio, ciudad=@ciudad, departamento=@departamento, fecharegistro=@fecharegistro from usuarios where id=@id",con);

            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = usu.usu_ID;

            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters["@tipodoc"].Value = usu.usu_TipoDocumento;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = usu.usu_Nombre;

            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters["@celular"].Value = usu.usu_Celular;

            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = usu.usu_Email;

            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = usu.usu_Genero;

            comando.Parameters.Add("@aprendiz", SqlDbType.Bit);
            comando.Parameters["@aprendiz"].Value = usu.usu_Aprendiz;

            comando.Parameters.Add("@egresado", SqlDbType.Bit);
            comando.Parameters["@egresado"].Value = usu.usu_Egresado;

            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = usu.usu_AreaFormacion;

            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters["@fechaegresado"].Value = usu.usu_FechaEgresado;

            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = usu.usu_Direccion;

            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters["@barrio"].Value = usu.usu_Barrio;

            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters["@ciudad"].Value = usu.usu_Ciudad;

            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters["@departamento"].Value = usu.usu_Departamento;

            comando.Parameters.Add("@fecharegistro", SqlDbType.Date);
            comando.Parameters["@fecharegistro"].Value = usu.usu_FechaRegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from usuarios where id=@id",con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value =id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}