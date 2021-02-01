using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using UserMgtAndCURDOpr.Interfaces;
using UserMgtAndCURDOpr.Models;

namespace UserMgtAndCURDOpr.DAL
{
    public class DALClasses
    {

        private SqlConnection con;//= new SqlConnection();
        /// <summary>
        /// Below method is connection to establish with Database
        /// </summary>
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddProject(Projects obj)
        {
            try
            {

                connection();
                SqlCommand com = new SqlCommand("SP_InsertProjects", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProjectName", obj.ProjectName);
                com.Parameters.AddWithValue("@ClientName", obj.ClientName);
                com.Parameters.AddWithValue("@ProjDescription", obj.ProjDescription);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int i = com.ExecuteNonQuery();

                con.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }
            catch(Exception exe)
            {
                // collect error Log that action based on error
                return false;
            }
            finally
            {
                con.Dispose();
            }
        }

        /// <summary>
        /// Below method demostrates the use of ADO object like SQLAdaptor, DataTable etc
        /// </summary>
        /// <returns></returns>
        public List<Projects> GetAllProjects()
        {
            try
            {
                connection();
                List<Projects> ProjectList = new List<Projects>();


                SqlCommand com = new SqlCommand("SP_SelectAllProjects", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {

                    ProjectList.Add(

                        new Projects
                        {

                            ProjectId = dr["ProjectId"].ToString(),
                            ProjectName = Convert.ToString(dr["ProjectName"]),
                            ClientName = Convert.ToString(dr["ClientName"]),
                            ProjDescription = Convert.ToString(dr["ProjDescription"])

                        }
                        );
                }

                com.Dispose();
                da.Dispose();
                return ProjectList;
            }
            catch(Exception exe)
            {
                // handle exception and manage error logs
                return null;
            }
        }

        /// <summary>
        /// Select Single Project
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Projects SelectSingleProjects(int Id)
        {

            Projects objProjects = new Projects();
            try
            {
                
                connection();
                SqlCommand com = new SqlCommand("SP_SelectSingleProjects", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProjectId", Id);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader ReadSingleRecord = com.ExecuteReader();
                if(ReadSingleRecord.HasRows)
                {
                    while (ReadSingleRecord.Read())
                    {
                        objProjects.ProjectId = ReadSingleRecord["ProjectId"].ToString();
                        objProjects.ProjectName = ReadSingleRecord["ProjectName"].ToString();
                        objProjects.ClientName = ReadSingleRecord["ClientName"].ToString();
                        objProjects.ProjDescription = ReadSingleRecord["ProjDescription"].ToString();
                    }
                }

                ReadSingleRecord.Close();
                com.Dispose();
                return objProjects;

            }
            catch (Exception exe)
            {
                // collect error Log that action based on error
                return null;
            }
            finally
            {
                con.Dispose();
            }
        }


        /// <summary>
        /// Method will update the projects 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateProjects(Projects obj)
        {

            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_UpdateProjects", con);
                //            @ProjectId int,
                //@ProjectName Nvarchar(100),
                //@ClientName nvarchar(100),
                //@ProjDescription nvarchar(500)
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProjectId", obj.ProjectId);
                com.Parameters.AddWithValue("@ProjectName", obj.ProjectName);
                com.Parameters.AddWithValue("@ClientName", obj.ClientName);
                com.Parameters.AddWithValue("@ProjDescription", obj.ProjDescription);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception exe)
            {
                // collect error Log that action based on error
                return false;
            }
            finally
            {
                con.Dispose();
            }
        }

        public bool DeleteProjects(int Id)
        {

            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_DeleteProjects", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProjectId", Id);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception exe)
            {
                // collect error Log that action based on error
                return false;
            }
            finally
            {
                con.Dispose();
            }
        }




    }

}