
using Business_Logic_Layer;
using LoginAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private Business_Logic_Layer.UserBLL business_logic_layer;

        public UserController() => business_logic_layer = new Business_Logic_Layer.UserBLL();


        [HttpGet]
        [Route("getUsers")]
        public List<UserModel> GetAllUsers()
        {
            return business_logic_layer.GetAllUsers();
        }

        [HttpGet]
        [Route("getUser")]
        public ActionResult<UserModel> GetUser(int id)
        {
            var data = business_logic_layer.GetUser(id);
            if (data == null) { return NotFound("Invalid User Id"); }
            return Ok(data);
        }


        [HttpPost]
        [Route("postUser")]
        public void PostUser([FromBody] UserModel user)
        {
            business_logic_layer.PostUser(user);
        }

        [HttpPut]
        [Route("updateUser")]
        public ActionResult<UserModel> UpdateUser([FromBody] UserModel user)
        {
            var data = business_logic_layer.UpdateUser(user);
            return Ok(data);
        }

        [HttpDelete]
        [Route("deleteUser")]
        public void deleteUser(int id)
        {
            business_logic_layer.deleteUser(id);
        }
    }
}
