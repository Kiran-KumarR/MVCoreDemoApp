using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MVCore.Views.HelloWorld
{
    public class IndexModel : PageModel
    {
        //IndexModel Model = new IndexModel();
        // Model.listofstudents=new List<StudentInfo>();
        //Model.listofstudents = new List<StudentInfo>();
        public List<StudentInfo> listofstudents = new List<StudentInfo>();
        //listofstudents=
      /*  public IndexModel()
        {
            listofstudents = new List<StudentInfo>();
        }*/
        public void OnGet()// http get method 
        {
            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Student;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();//to open connection
                    string sql = "select * from Students";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                          

                            while (reader.Read())
                            {
                                StudentInfo studentinfo = new StudentInfo();

                                studentinfo.Id = "" + reader.GetInt32(0);
                                studentinfo.FirstName = reader.GetString(1);
                                studentinfo.LastName = reader.GetString(2);
                                studentinfo.Gender = reader.GetString(3);
                                studentinfo.Address = reader.GetString(4);
                                studentinfo.created_at = reader.GetDateTime(5).ToString();

                                listofstudents.Add(studentinfo);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught is" + ex.ToString());
            }
        }
    }
    public class StudentInfo
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string created_at { get; set; }
    }
}
