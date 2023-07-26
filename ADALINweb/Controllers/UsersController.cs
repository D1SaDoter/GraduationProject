using ADALINweb.Dal.Interfaces;
using ADALINweb.Domain.Entity;
using ADALINweb.Domain.ViewModels;
using ADALINweb.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ADALINweb.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> UsersGet()
        {
            var response = await _usersService.GetUsers();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> UserGet(int id)
        {
            var response = await _usersService.GetUser(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _usersService.DeleteUser(id);
            if (response.StatusCode== Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("UsersGet");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var response = await _usersService.GetUser(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (userViewModel.Id == 0)
                {
                    await _usersService.CreateUser(userViewModel);
                }
                else
                {
                    await _usersService.Edit(userViewModel.Id, userViewModel);
                }
            }
            var response = await _usersService.CreateUser(userViewModel);
            return RedirectToAction("UsersGet");
        }
    }
}
