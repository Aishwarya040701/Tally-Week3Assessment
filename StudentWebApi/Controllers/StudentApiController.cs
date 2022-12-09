using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentWebApi.Models;


namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase


    {
        StudentDBContext db = new StudentDBContext();

        [HttpGet]
        public ActionResult GetStudent()
        {
            
               
                List<Student> stu = db.GetStudent();
                return Ok(stu);

        }

        [HttpGet("{id:int}")]
        public ActionResult GetStudent(int id)
        {
            
            if (IsValid(id) == true)
            {
                Student stu = db.GetStudent(id);
                return Ok(stu);
            }
            else
            {
                 BadRequest();
            } 
            return NoContent();
        }


        
        [HttpPost] 
        public ActionResult PostStudent(Student s)
        {
            
            if (IsValid(s.StudentId)!=true)
            {
                db.PostStudent(s); ;
                Ok();

            }
            else
            {
                BadRequest();
            }
            return NoContent();

        }
 

        [HttpPut]
        public ActionResult PutStudent(Student s)
        {

           
            if (IsValid(s.StudentId)==true)
            {
                db.PutStudent(s); ;
                Ok();

            }
            else
            {
                BadRequest();
            }
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteStudent(int id)
        {

   
            if (IsValid(id)==true)
            {
                db.DeleteStudent(id);
                Ok();

            }
            else
            {
             BadRequest();
            }
            return NoContent();

        }
        private bool IsValid(int id)
        {
            
            return db.GetStudent().Where(model =>model.StudentId == id).Any();
           
        }
    }
}
