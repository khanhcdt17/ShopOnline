using Model1.Dao;
using Model1.EF;
using ShopOnline.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            ViewBag.searchString = searchString;
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var passWordMd5 = Encryptor.MD5(user.Password);
                user.Password = passWordMd5;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm người đùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }

            }

            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().GetByID(id);

            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(bool RsPW, User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (RsPW)
                {
                    var passWordMd5 = Encryptor.MD5("123456");
                    user.Password = passWordMd5;
                }
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Sửa người đùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }


                ModelState.AddModelError("", "Cập nhập thất bại");

            }

            return View("Edit");
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var user = new UserDao().Delete(id);
            if (!user)
            {
                ModelState.AddModelError("", "Cập nhập thất bại");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });

        }
    }
}