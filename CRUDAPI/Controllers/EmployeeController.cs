using System;
using System.Linq;
using System.Web.Http;
using CRUDAPI.Models;

namespace CRUDAPI.Controllers
{
    [RoutePrefix("Api/Employee")]
    public class EmployeeAPIController : ApiController
    {
        Entities objEntity = new Entities();

        [HttpGet]
        [Route("AllEmployeeDetails")]
        public IQueryable<EMPLOYEEDETAIL> GetEmaployee()
        {
            try
            {
                return objEntity.EMPLOYEEDETAILS;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetEmployeeDetailsById/{employeeId}")]
        public IHttpActionResult GetEmaployeeById(string employeeId)
        {
            EMPLOYEEDETAIL objEmp = new EMPLOYEEDETAIL();
            int ID = Convert.ToInt32(employeeId);
            try
            {
                objEmp = objEntity.EMPLOYEEDETAILS.Find(ID);
                if (objEmp == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(objEmp);
        }

        [HttpPost]
        [Route("InsertEmployeeDetails")]
        public IHttpActionResult PostEmaployee(EMPLOYEEDETAIL data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objEntity.EMPLOYEEDETAILS.Add(data);
                objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }



            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public IHttpActionResult PutEmaployeeMaster(EMPLOYEEDETAIL employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                EMPLOYEEDETAIL objEmp = new EMPLOYEEDETAIL();
                objEmp = objEntity.EMPLOYEEDETAILS.Find(employee.EMPID);
                if (objEmp != null)
                {
                    objEmp.EMPNAME = employee.EMPNAME;
                    objEmp.ADDRESS = employee.ADDRESS;
                    objEmp.EMAILID = employee.EMAILID;
                    objEmp.DATEOFBIRTH = employee.DATEOFBIRTH;
                    objEmp.GENDER = employee.GENDER;
                    objEmp.PINCODE = employee.PINCODE;

                }
                int i = this.objEntity.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }
        [HttpDelete]
        [Route("DeleteEmployeeDetails")]
        public IHttpActionResult DeleteEmaployeeDelete(int id)
        {
            //int empId = Convert.ToInt32(id);  
            EMPLOYEEDETAIL emaployee = objEntity.EMPLOYEEDETAILS.Find(id);
            if (emaployee == null)
            {
                return NotFound();
            }

            objEntity.EMPLOYEEDETAILS.Remove(emaployee);
            objEntity.SaveChanges();

            return Ok(emaployee);
        }
    }
}