using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace StudentWebApi.Models
{
    public class StudentDBContext
    {
        SqlConnection con = null;
        string cs = "Data Source=BLR1-LHP-N80937;Initial Catalog=StudentManagement;Integrated Security=True";

        public List<Student> GetStudent()
        {
            List<Student> Studentlist = new List<Student>();
            using (con = new SqlConnection(cs))
                {
               
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SPSelect";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        Student s = new Student();
                        s.StudentId=Convert.ToInt32(dr.GetValue(0).ToString());
                        s.Name = dr.GetValue(1).ToString();
                        s.Address = dr.GetValue(2).ToString();
                        s.Class = Convert.ToInt32(dr.GetValue(3).ToString());
                        s.Sub1 = dr.GetValue(4).ToString();
                        s.Sub2 = dr.GetValue(5).ToString();
                        s.Sub3 = dr.GetValue(6).ToString();
                        s.Sub4 = dr.GetValue(7).ToString();
                        s.Sub5 = dr.GetValue(8).ToString();

                        Studentlist.Add(s);


                    }
                   
                        Console.WriteLine("getting Student data Successfully!!!!!");
                    
                   
                }

                return Studentlist;
          
        }

        public Student GetStudent(int id)
        {
            List<Student> Studentlist = new List<Student>();
            using (con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SPSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Student s = new Student();
                    s.StudentId = Convert.ToInt32(dr.GetValue(0).ToString());
                    s.Name = dr.GetValue(1).ToString();
                    s.Address = dr.GetValue(2).ToString();
                    s.Class = Convert.ToInt32(dr.GetValue(3).ToString());
                    s.Sub1 = dr.GetValue(4).ToString();
                    s.Sub2 = dr.GetValue(5).ToString();
                    s.Sub3 = dr.GetValue(6).ToString();
                    s.Sub4 = dr.GetValue(7).ToString();
                    s.Sub5 = dr.GetValue(8).ToString();

                    Studentlist.Add(s);


                }

                Console.WriteLine("getting Student data Successfully!!!!!");


            }
            var stu= Studentlist.Where(model=>model.StudentId==id).FirstOrDefault();
            return stu;

        }

        public void PostStudent(Student s)
        {
            con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;
            cmd.CommandText = "SPInsert";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", s.StudentId);
            cmd.Parameters.AddWithValue("@name", s.Name);
            cmd.Parameters.AddWithValue("@address", s.Address);
            cmd.Parameters.AddWithValue("@class", s.Class);
            cmd.Parameters.AddWithValue("@sub1", s.Sub1);
            cmd.Parameters.AddWithValue("@sub2", s.Sub2);
            cmd.Parameters.AddWithValue("@sub3", s.Sub3);
            cmd.Parameters.AddWithValue("@sub4", s.Sub4);
            cmd.Parameters.AddWithValue("@sub5", s.Sub5);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }


        public void PutStudent(Student s)
        {
            con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SPUpdate";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", s.StudentId);
            cmd.Parameters.AddWithValue("@name", s.Name);
            cmd.Parameters.AddWithValue("@address", s.Address);
            

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public void DeleteStudent(int id)
        {
            con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SPDelete";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
  


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

    }
}
