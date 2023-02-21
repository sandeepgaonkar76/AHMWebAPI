using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

       
        [HttpGet]
        public List<Member> GetPeople(string query)
        {
            var people = new List<Member>();
            SqlCommand command = new SqlCommand(query);

            using (SqlConnection connection = new SqlConnection(""))
            {
                command.Connection = connection;
                command.CommandText = "select top 5 firstname,lastname from member ";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var member = new Member();
                        member.FirstName = reader.GetString(0);
                        member.LastName = reader.GetString(1);
                        people.Add(member);
                    }
                };
            }
            return people;
        }
    }
    public class Member
    {
      
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

       
    }
}
