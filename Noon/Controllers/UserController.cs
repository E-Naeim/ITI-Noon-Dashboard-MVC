using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Noon.ViewModels;
using Repository;

namespace Noon.Controllers
{

    public class UserController : Controller
    {
        // Unit Of Work which is responsible on operations on Context
        IUnitOfWork unitOfWork;

        // User Repo which is responsible on operations on user
        IMainRepository<User> UserRepository;
        IMainRepository<Phone> PhoneRepository;
        IMainRepository<Address> AddressRepository;

        // Constructor
        public UserController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserRepository = unitOfWork.Users;
            PhoneRepository = unitOfWork.Phones;
            AddressRepository = unitOfWork.Addresses;
        }

        // GET: Customers
        public ActionResult Index(string Role)
        {
            // Get all users including his phone and address
            var users = UserRepository.FindAll(u => u.Role == Role, u => u.Phones, u => u.Addresses);

            if (users.Any())
            {
                return View(users);
            }

            return NotFound();
        }

        // GET: User/Create
        public ActionResult Create(string _Role = "Customer")
        {
            var UserViewModel = new UserViewModel { IsActive = true, Role =  _Role};
            return View("UserForm", UserViewModel);
        }

        // POST: Customers/Save (Responsible on creating and Post updates
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // means you create new user not updating
                if (model.Id == 0)
                {
                    var user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password,
                        Balance = model.Balance,
                        Role = model.Role,
                        IsActive = model.IsActive,
                    };

                    UserRepository.Add(user);
                    unitOfWork.Save();


                    var phone = new Phone
                    {
                        PhoneNumber = model.PhoneNumber,
                        UserID = user.Id
                    };

                    var address = new Address
                    {
                        Street = model.Street,
                        City = model.City,
                        PostalCode = model.PostalCode,
                        UserID = user.Id
                    };

                    PhoneRepository.Add(phone);
                    AddressRepository.Add(address);

                    unitOfWork.Save();
                    return RedirectToAction("Index", model.Role);
                }
                else // updating
                {
                    var user = UserRepository.Find(u => u.Id == model.Id, u => u.Phones, u => u.Addresses);

                    if (user == null)
                    {
                        return NotFound();
                    }

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.Password = model.Password;
                    user.Balance = model.Balance;
                    user.Role = model.Role;
                    user.IsActive = model.IsActive;
                    user.Phones.FirstOrDefault().PhoneNumber = model.PhoneNumber;
                    user.Addresses.FirstOrDefault().City = model.City;
                    user.Addresses.FirstOrDefault().Street = model.Street;
                    unitOfWork.Save();
                }

            }

            return RedirectToAction("Index", model.Role);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = UserRepository.Find(u => u.Id == id, u => u.Phones, u => u.Addresses);

            if (user == null)
            {
                return NotFound();
            }

            var UserViewModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Balance = user.Balance,
                Role = user.Role,
                IsActive = user.IsActive,
                PhoneNumber = user.Phones.FirstOrDefault().PhoneNumber,
                Street = user.Addresses.FirstOrDefault().Street,
                City = user.Addresses.FirstOrDefault().City,
            };

            return View("UserForm", UserViewModel);
        }

        public ActionResult Suspend(int id)
        {
            // get the user
            var user = UserRepository.GetById(id);

            // suspend the user
            user.IsActive = false;

            // update database
            UserRepository.Update(user);

            // save updates
            unitOfWork.Save();

            // get all users
            var users = UserRepository.FindAll(u => u.Id == id, u => u.Phones, u => u.Addresses);

            return PartialView("_UserPartial", users);
        }

        public ActionResult Activate(int id)
        {
            // get the user
            var user = UserRepository.GetById(id);

            // suspend the user
            user.IsActive = true;

            // update database
            UserRepository.Update(user);

            // save updates
            unitOfWork.Save();

            // get all users
            var users = UserRepository.FindAll(u => u.Id == id, u => u.Phones, u => u.Addresses);

            return PartialView("_UserPartial", users);
        }
    }
}
