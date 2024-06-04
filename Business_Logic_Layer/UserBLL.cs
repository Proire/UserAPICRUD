using Data_Access_Layer;
using LoginAPI.Entities;
using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc;

namespace Business_Logic_Layer
{
    public class UserBLL
    {
        private Data_Access_Layer.UserDAL data_access_layer;
        private Mapper UserMapper;
        public UserBLL() 
        { 
            data_access_layer = new Data_Access_Layer.UserDAL();
            var configUser = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>().ReverseMap());
            UserMapper = new Mapper(configUser);
        }
        public List<UserModel> GetAllUsers()
        {
            List<User> usersfromdb = data_access_layer.GetAllUsers();
            List<UserModel> userModels  = UserMapper.Map<List<User>, List<UserModel>>(usersfromdb);
            return userModels;
        }

        public UserModel GetUser(int id)
        {
            var data = data_access_layer.GetUser(id);
            UserModel model = UserMapper.Map<User, UserModel>(data);
            return model;
        }

        public void PostUser([FromBody] UserModel user)
        {
            User model = UserMapper.Map<UserModel, User>(user);
            data_access_layer.PostUser(model);
        }
        public UserModel UpdateUser(UserModel user)
        {
            User model = UserMapper.Map<UserModel, User>(user);
            User newuser = data_access_layer.UpdateUser(model);
            UserModel newmodel = UserMapper.Map<User, UserModel>(newuser);
            return newmodel;
        }

        public void deleteUser(int id)
        {
            data_access_layer.deleteUser(id);
        }
    }
}
