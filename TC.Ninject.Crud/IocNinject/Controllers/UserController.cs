using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TC.Ioc.Service;
using TC.Ioc.Web.Models;
using TC.Ioc.Core.Data;

namespace TC.Ioc.Web.Controllers
{
    public class UserController : Controller
    {

        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<UserModel> users = userService.GetUsers().Select(u => new UserModel
            {
                firstName = u.UserProfile.firstName,
                lastName = u.UserProfile.lastName,
                email = u.email,
                address = u.UserProfile.address,
                ID = u.ID
            });
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateEditUser(int? id)
        {
            UserModel model = new UserModel();
            if (id.HasValue && id != 0)
            {
                User userEntity = userService.GetUser(id.Value);
                model.firstName = userEntity.UserProfile.firstName;
                model.lastName = userEntity.UserProfile.lastName;
                model.address = userEntity.UserProfile.address;
                model.email = userEntity.email;
                model.name = userEntity.name;
                model.password = userEntity.password;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditUser(UserModel model)
        {
            if (model.ID == 0)
            {
                User userEntity = new User
                {
                    name = model.name,
                    email = model.email,
                    password = model.password,
                    createDate = DateTime.UtcNow,
                    modifiedDate = DateTime.UtcNow,
                    IP = Request.UserHostAddress,
                    UserProfile = new UserProfile
                    { 
                        firstName = model.firstName,
                        lastName = model.lastName,
                        address = model.address,
                        createDate = DateTime.UtcNow,
                        modifiedDate = DateTime.UtcNow,
                        IP = Request.UserHostAddress
                    }
                };
                userService.InsertUser(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                User userEntity = userService.GetUser(model.ID);
                userEntity.name = model.name;
                userEntity.email = model.email;
                userEntity.password = model.password;
                userEntity.modifiedDate = DateTime.UtcNow;
                userEntity.IP = Request.UserHostAddress;
                userEntity.UserProfile.firstName = model.firstName;
                userEntity.UserProfile.lastName = model.lastName;
                userEntity.UserProfile.address = model.address;
                userEntity.UserProfile.modifiedDate = DateTime.UtcNow;
                userEntity.UserProfile.IP = Request.UserHostAddress;
                userService.UpdateUser(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }
               
            }
            return View(model);
        }

        public ActionResult DetailUser(int? id)
        {
            UserModel model = new UserModel();
            if (id.HasValue && id != 0)
            {
                User userEntity = userService.GetUser(id.Value);
               // model.ID = userEntity.ID;
                model.firstName = userEntity.UserProfile.firstName;
                model.lastName = userEntity.UserProfile.lastName;
                model.address = userEntity.UserProfile.address;
                model.email = userEntity.email;
                model.createDate = userEntity.createDate;
                model.name = userEntity.name;
            }
            return View(model);
        }

        public ActionResult DeleteUser(int id)
        {
            UserModel model = new UserModel();
            if (id != 0)
            {
                User userEntity = userService.GetUser(id);                
                model.firstName = userEntity.UserProfile.firstName;
                model.lastName = userEntity.UserProfile.lastName;
                model.address = userEntity.UserProfile.address;
                model.email = userEntity.email;
                model.createDate = userEntity.createDate;
                model.name = userEntity.name;
            }
            return View(model);
        }

       
        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            try
            {
                if ( id != 0)
                {
                    User userEntity = userService.GetUser(id);    
                    userService.DeleteUser(userEntity);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
