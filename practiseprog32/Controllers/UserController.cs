using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace practiseprog32.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllData()
        {
            try
            {
                CrudApiMasterContext crudApiMasterContext = new CrudApiMasterContext();
                var users = crudApiMasterContext.UserMasters.ToList();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("UpdateUser/{UserId}")]
        public IActionResult UpdateUser(int id, UserMaster userUpdate)
        {
            try
            {
                CrudApiMasterContext crudApiMasterContext = new CrudApiMasterContext();
                var user = crudApiMasterContext.UserMasters.FirstOrDefault(y => y.UserId == id);
                user.FirstName = userUpdate.FirstName;
                user.MiddleName = userUpdate.MiddleName;
                user.LastName = userUpdate.LastName;
                user.UserName = userUpdate.UserName;
                user.Password = userUpdate.Password;
                crudApiMasterContext.SaveChanges();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{UserId}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                CrudApiMasterContext crudApiMasterContext = new CrudApiMasterContext();
                var user = crudApiMasterContext.UserMasters.FirstOrDefault(y=>y.UserId == id);
                crudApiMasterContext.UserMasters.Remove(user);
                crudApiMasterContext.SaveChanges();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("SaveUser")]
        public IActionResult SaveUser(UserMaster userMaster)
        {
            try
            {
                CrudApiMasterContext crudApiMasterContext = new CrudApiMasterContext();
                crudApiMasterContext.UserMasters.Add(userMaster);
                crudApiMasterContext.SaveChanges();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllUsersById/{id}")]
        public IActionResult GetAllData(int id)
        {
            try
            {
                CrudApiMasterContext crudApiMasterContext = new CrudApiMasterContext();
                var users = crudApiMasterContext.UserMasters.FirstOrDefault(y => y.UserId == id);

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
