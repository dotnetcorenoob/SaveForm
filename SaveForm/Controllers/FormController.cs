using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace SaveForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        [HttpPost("FormSave")]
        public ActionResult Post([FromBody] FormData _formData)
        {
            using IDbConnection dbConnection = new SqlConnection("Data Source=PC\\SQLEXPRESS;Initial Catalog=LMS_Updated;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True");
            string query = "insert into PersonalInfo (name,emailaddress,gender,currentlyworking,companyname,descirption,isacknowledge) values (@name, @emailaddress,@gender,@currentlyworking,@companyname,@descirption,@isacknowledge) ";
            dbConnection.Execute(query, _formData);
            return Ok();

        }
    }
}
