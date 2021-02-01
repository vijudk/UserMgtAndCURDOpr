using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserMgtAndCURDOpr.DAL;
using UserMgtAndCURDOpr.Models;

namespace UserMgtAndCURDOpr.Controllers
{
    public class ProjectsController : Controller
    {

        public ActionResult GetAllProjects()
        {

            DALClasses ObjDALClasses = new DALClasses();
            ModelState.Clear();
            return View(ObjDALClasses.GetAllProjects());
        }


        public ActionResult ProjectSingleDetails(int id)
        {
            DALClasses ObjDALClasses = new DALClasses();



            return View(ObjDALClasses.SelectSingleProjects(id));

        }

        // GET: Projects/Create
        public ActionResult AddProjects()
        {
            return View("AddProjects");
        }

       
        [HttpPost]
        public ActionResult AddProjects(Projects ObjProjects)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DALClasses ObjDALClasses = new DALClasses();

                    if (ObjDALClasses.AddProject(ObjProjects))
                    {
                        ViewBag.Message = "Project details added successfully";
                    }
                }

                //return View();
                return RedirectToAction("GetAllProjects");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UpdateProjectDetail(int ProjectId)
        {
            DALClasses ObjDALClasses = new DALClasses();
            Projects ObjProjects = new Projects();
            ObjProjects = ObjDALClasses.SelectSingleProjects(ProjectId);
            //return View("UpdateProjectDetail");
            return View(ObjProjects);
        }


        // POST: Projects/Edit/5
        [HttpPost]
        public ActionResult UpdateProjectDetail(Projects ObjProjects)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DALClasses ObjDALClasses = new DALClasses();

                    if (ObjDALClasses.UpdateProjects(ObjProjects))
                    {
                        ViewBag.Message = "Project Details Updated Successfully";
                    }
                }

                return RedirectToAction("GetAllProjects");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DeleteProjects(int ProjectId)
        {
            try
            {
                DALClasses ObjDALClasses = new DALClasses();
                if (ObjDALClasses.DeleteProjects(ProjectId))
                {
                    ViewBag.AlertMsg = "Project deleted successfully";

                }
                return RedirectToAction("GetAllProjects");

            }
            catch
            {
                return View();
            }
        }
    }
}
