using ML;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "INSERT INTO[Alumno]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Genero])VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Genero)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[3].Value = alumno.FechaNacimiento;

                        collection[4] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[4].Value = alumno.Genero;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el alumno correctamente";
                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "AlumnoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = alumno.FechaNacimiento;

                        collection[4] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[4].Value = alumno.Genero;

                        collection[5] = new SqlParameter("IdSemestre", SqlDbType.TinyInt);
                        collection[5].Value = alumno.Semestre.IdSemestre;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el alumno correctamente";
                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "AlumnoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        DataTable alumnoTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(alumnoTable);

                        if (alumnoTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in alumnoTable.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();

                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                alumno.FechaNacimiento = row[4].ToString();
                                alumno.Genero = row[5].ToString();

                                alumno.Semestre = new ML.Semestre();
                                alumno.Semestre.IdSemestre = byte.Parse(row[6].ToString());

                                result.Objects.Add(alumno); //boxing y unboxing

                            }

                        }

                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        public static ML.Result GetById(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "AlumnoGetById";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //conexion
                        cmd.CommandText = querySP; //query
                        cmd.CommandType = CommandType.StoredProcedure;//SP

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = idAlumno;

                        cmd.Parameters.AddRange(collection);

                        DataTable alumnoTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(alumnoTable);

                        if (alumnoTable.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();
                            DataRow row = alumnoTable.Rows[0];

                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();
                            alumno.FechaNacimiento = row[4].ToString();
                            alumno.Genero = row[5].ToString();

                            alumno.Semestre = new ML.Semestre();
                            alumno.Semestre.IdSemestre = byte.Parse(row[6].ToString());

                            //result.Objects.Add(alumno); //boxing y unboxing

                            result.Object = alumno;//boxing y unboxing



                        }

                    }

                }
                result.Correct = true;


            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        // EF
        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities context = new DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities())
                {
                    int query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.FechaNacimiento, alumno.Genero, alumno.Semestre.IdSemestre);

                    if (query > 0)
                    {
                        result.Message = "Alumno agregado con exito";
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities context = new DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities())
                {
                    //var query = context.AlumnoGetAll();
                    var query = context.AlumnoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = row.IdAlumno;
                            alumno.Nombre = row.Nombre;
                            alumno.ApellidoPaterno = row.ApellidoPaterno;
                            alumno.ApellidoMaterno = row.ApellidoMaterno;
                            alumno.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            alumno.Genero = row.Genero;

                            alumno.Semestre = new ML.Semestre();
                            alumno.Semestre.IdSemestre = row.IdSemestre.Value;
                            alumno.Semestre.Nombre = row.SemestreNombre;

                            result.Objects.Add(alumno); //boxing y unboxing

                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        public static ML.Result GetByIdEF(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities context = new DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities())
                {

                    //var query = context.AlumnoGetById(idAlumno).First();
                    var query = context.AlumnoGetById(idAlumno).FirstOrDefault();

                    //var query = context.AlumnoGetById(idAlumno).Single();
                    //var query = context.AlumnoGetById(idAlumno).SingleOrDefault();

                    if (query != null)
                    {

                        ML.Alumno alumno = new ML.Alumno();

                        alumno.IdAlumno = query.IdAlumno;
                        alumno.Nombre = query.Nombre;
                        alumno.ApellidoPaterno = query.ApellidoPaterno;
                        alumno.ApellidoMaterno = query.ApellidoMaterno;
                        alumno.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                        alumno.Genero = query.Genero;

                        alumno.Semestre = new ML.Semestre();
                        alumno.Semestre.IdSemestre = query.IdSemestre.Value;

                        result.Object = alumno; //boxing 


                    }

                }
                result.Correct = true;



                result.Correct = true;


            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }

        //LINQ

        public static ML.Result AddLINQ(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities context = new DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities())
                {
                    //DL.Grupo grupoDL = new DL.Grupo();
                    DL_EF.Alumno alumnoDL = new DL_EF.Alumno();

                    alumnoDL.Nombre = alumno.Nombre;
                    alumnoDL.ApellidoPaterno = alumno.ApellidoPaterno;
                    alumnoDL.ApellidoMaterno = alumno.ApellidoMaterno;
                    alumnoDL.FechaNacimiento = DateTime.Parse(alumno.FechaNacimiento);
                    alumnoDL.Genero = alumno.Genero;
                    alumnoDL.IdSemestre = alumno.Semestre.IdSemestre;
                    

                    context.Alumnoes.Add(alumnoDL);
                    context.SaveChanges();


                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;

                throw;
            }//manejo de excepciones 
            return result;

        }

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities context = new DL_EF.IEspinozaProgramacionNCapasGenOctubreEntities())
                {
                    //var query = context.AlumnoGetAll();
                    //var query = context.AlumnoGetAll().ToList();
                    //var query = (from alumnoLINQ in context.Alumnoes select alumnoLINQ);
                    var query = (from alumnoLINQ in context.Alumnoes

                                 select new {

                                     IdAlumno = alumnoLINQ.IdAlumno,
                              
                                     Nombre = alumnoLINQ.Nombre, 
                                     ApellidoPaterno = alumnoLINQ.ApellidoPaterno, 
                                     ApellidoMaterno = alumnoLINQ.ApellidoMaterno,
                                     FechaNacimiento = alumnoLINQ.FechaNacimiento,
                                     Genero = alumnoLINQ.Genero,
                                     IdSemestre = alumnoLINQ.IdSemestre
                                 });
                    //var query = (from alumnoLINQ in context.Alumnoes
                    //             where alumnoLINQ.IdAlumno == idAlumno
                    //             select new
                    //             {

                    //                 IdAlumno = alumnoLINQ.IdAlumno,

                    //                 Nombre = alumnoLINQ.Nombre,
                    //                 ApellidoPaterno = alumnoLINQ.ApellidoPaterno,
                    //                 ApellidoMaterno = alumnoLINQ.ApellidoMaterno,
                    //                 FechaNacimiento = alumnoLINQ.FechaNacimiento,
                    //                 Genero = alumnoLINQ.Genero,
                    //                 IdSemestre = alumnoLINQ.IdSemestre
                    //             }); //GETBYID 

                    if (query != null && query.ToList().Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = row.IdAlumno;
                            alumno.Nombre = row.Nombre;
                            alumno.ApellidoPaterno = row.ApellidoPaterno;
                            alumno.ApellidoMaterno = row.ApellidoMaterno;
                            alumno.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            alumno.Genero = row.Genero;

                            alumno.Semestre = new ML.Semestre();
                            alumno.Semestre.IdSemestre = row.IdSemestre.Value;

                            result.Objects.Add(alumno); //boxing y unboxing

                        }
                    }

                }
                result.Correct = true;
            }//codigo que puede causar una excepcion 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el alumno" + result.Ex;

                throw;
            }//manejo de excepciones 

            return result;
        }




    }
}
