using DVDWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DVDWebApi
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void Add(Dvd dvd)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("CreateNewDvd", cn);
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.Parameters.AddWithValue("@DvdId", dvd.dvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.title);
                cmd.Parameters.AddWithValue("@Director", dvd.director);
                cmd.Parameters.AddWithValue("@Rating", dvd.rating);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.releaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.notes);

                cmd.ExecuteNonQuery();

            }
        }

        public void Delete(int DvdId)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("DeleteDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DvdId", DvdId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("EditDvd", conn);
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@Title", dvd.title);
                cmd.Parameters.AddWithValue("@Director", dvd.director);
                cmd.Parameters.AddWithValue("@Rating", dvd.rating);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.releaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.notes);
                cmd.Parameters.AddWithValue("@DvdID", dvd.dvdId);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {

                        dvd.dvdId = (int)dr["dvdId"];
                        dvd.title = dr["title"].ToString();
                        dvd.releaseYear = (int)dr["releaseYear"];
                        dvd.director = dr["Name"].ToString();
                        dvd.rating = dr["Rating"].ToString();
                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.notes = dr["Notes"].ToString();
                        }

                    }
                }
            }
        }

        public Dvd Get(int DvdId)
        {
            Dvd Dvds = new Dvd();


            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("RetreiveDvdByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DvdId", DvdId);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["title"].ToString();
                        row.releaseYear = (int)dr["releaseYear"];
                        row.director = dr["director"].ToString();
                        row.rating = dr["rating"].ToString();
                        row.notes = dr["notes"].ToString();
                        Dvds =  row;
                    }
                }
            }
            return Dvds;
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> listDvds = new List<Dvd>();
                        

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                //string query = "SELECT [DvdID],[Title],[ReleaseYear],[DirectorID],[RatingID],[Notes] FROM[DvdLibrary].[dbo].[DVD] Where 1=1";

                SqlCommand cmd = new SqlCommand("RetreivingAllDvds", cn);
                cmd.Connection = cn;
                //cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())

                {

                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["title"].ToString();
                        row.releaseYear = (int)dr["releaseYear"];
                        row.director = dr["director"].ToString();
                        row.rating = dr["rating"].ToString();
                        row.notes = dr["notes"].ToString();

                        listDvds.Add(row);
                    }
                }
            }
            return listDvds;
        }

        public List<Dvd> GetByDirector(string director)
        {

            List<Dvd> listDvds = new List<Dvd>();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("RetrievingByDirector", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Director", director);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["title"].ToString();
                        row.releaseYear = (int)dr["releaseYear"];
                        row.director = dr["director"].ToString();
                        row.rating = dr["rating"].ToString();
                        row.notes = dr["notes"].ToString();

                        listDvds.Add(row);
                    }
                }
            }
            return listDvds;

        }

        public List<Dvd> GetByRating(string rating)
        {
            List<Dvd> listDvds = new List<Dvd>();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("RetrievingByRating", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rating", rating);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["title"].ToString();
                        row.releaseYear = (int)dr["releaseYear"];
                        row.director = dr["director"].ToString();
                        row.rating = dr["rating"].ToString();
                        row.notes = dr["notes"].ToString();

                        listDvds.Add(row);
                    }
                }
            }
            return listDvds;
        }

        public List<Dvd> GetByTitle(string title)
        {

            List<Dvd> listDvds = new List<Dvd>();


            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("RetrievingByTitle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["title"].ToString();
                        row.releaseYear = (int)dr["releaseYear"];
                        row.director = dr["director"].ToString();
                        row.rating = dr["rating"].ToString();
                        row.notes = dr["notes"].ToString();

                        listDvds.Add(row);
                    }
                }
            }
            return listDvds;

        }

        public List<Dvd> GetByYear(int releaseYear)
        {

            List<Dvd> listDvds = new List<Dvd>();


            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("RetrievingByYear", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["title"].ToString();
                        row.releaseYear = (int)dr["releaseYear"];
                        row.director = dr["director"].ToString();
                        row.rating = dr["rating"].ToString();
                        row.notes = dr["notes"].ToString();

                        listDvds.Add(row);
                    }
                }
            }
            return listDvds;
        }
    }
}