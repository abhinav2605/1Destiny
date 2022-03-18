using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using _1Destiny.Models;
using System.Data;

namespace _1Destiny
{
    public class DB_Connect
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ConnectionString;
            con = new SqlConnection(constr);
        }
        public List<DB_Teams> GetTeams()
        {
            connection();
            List<DB_Teams> TeamList = new List<DB_Teams>();
            using (con)
            {
                SqlCommand cmd = new SqlCommand("GetTeams", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                var ds = new DataSet();
                con.Open();
                da.Fill(ds);
                con.Close();
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DB_Teams cobj = new DB_Teams();
                    cobj.ID = Convert.ToSByte(ds.Tables[0].Rows[i]["ID"].ToString());
                    cobj.TeamName = ds.Tables[0].Rows[i]["TeamName"].ToString();

                    TeamList.Add(cobj);
                }
            }
            return TeamList;
        }
        public List<DB_Resource> GetTools(int id,int resourceID)
        {
            connection();
            DB_Resource objRes = new DB_Resource();
            DataSet ds = new DataSet();
            List<DB_Resource> resourceList = new List<DB_Resource>();
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("GetResource", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@resourceid", resourceID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DB_Resource uobj = new DB_Resource();
                        uobj.Sl_No = Convert.ToSByte(ds.Tables[0].Rows[i]["Sl No."].ToString());
                        uobj.ResourceName = ds.Tables[0].Rows[i]["ResourceName"].ToString();
                        uobj.ResourceLink = ds.Tables[0].Rows[i]["ResourceLink"].ToString();
                        uobj.ResourceID = Convert.ToSByte(ds.Tables[0].Rows[i]["ResourceID"].ToString());
                        uobj.ResourceImage = ds.Tables[0].Rows[i]["ResourceImage"].ToString();
                        uobj.TeamID = uobj.ResourceID = Convert.ToSByte(ds.Tables[0].Rows[i]["TeamID"].ToString());
                        resourceList.Add(uobj);
                    }
                }
                con.Close();
            }
            return resourceList;
        }
    }
}