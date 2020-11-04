using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Models;

namespace lab4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        

        private IStudentRepo _studentRepo;
        
        public StudentController(IStudentRepo studentRepo )
        {
            _studentRepo=studentRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentEntity>> Get()
        {
            return await _studentRepo.GetAllStudents();
        }
        [HttpPost]
        public async Task<string> Post([FromBody]StudentEntity student )
        {
            
            try{
                await _studentRepo.CreateNewStudent(student);
                return "S-a adaugat cu succes";
            }
            catch(System.Exception e)
            {
                return "Eroare " + e.Message;
                throw;
            }
        }
        [HttpPut]
        public async Task<string> Put( [FromBody] StudentEntity student)
        {
            string a= await _studentRepo.UpdateStudent(student);
            return a;
        }
        [HttpDelete]
        public async Task<string> Delete( [FromHeader] string PartitionKey)
        {
             string a= await _studentRepo.DeleteStudent(PartitionKey);
            return a;
        }


    }
}
