using AmigosAuction.Entities;
using AmigosAuction.Services;
using AmigosAuction.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmigosAuction.Web.Controllers
{
    public class SharedController : Controller
    {
        SharedService service = new SharedService(); 

        [HttpPost]
        public JsonResult UploadPicture()
        {
            JsonResult result = new JsonResult();

            List<object> pictureJSON = new List<object>();

            var images = Request.Files;

            for (int i = 0; i < images.Count; i++)
            {
                var picture = images[i];
                //to create random unique Id so that user can save one picture twice without replacing original one.
                //Create Guid to create unique id strings0

                var fileName = Guid.NewGuid() + picture.FileName;
                var path = Server.MapPath("~/Content/images") + fileName;

                picture.SaveAs(path);

                var dbPicture = new Picture();
                dbPicture.URL = fileName;

                int pictureID =  service.SavePicture(dbPicture);

                pictureJSON.Add(new { ID = pictureID, pictureURL = fileName});
            }

            result.Data = pictureJSON;

            return result;
        }

        [HttpPost]
        public JsonResult LeaveComment(CommentViewModel model)
        {
            JsonResult result = new JsonResult();
            try
            {
                var comment = new Comment();
                comment.Text = model.Text;
                comment.EntityID = model.EntityID;
                comment.Rating = model.Rating;
                comment.RecordID = model.RecordID;
                comment.UserID = User.Identity.GetUserId();
                comment.TimeStamp = DateTime.Now;

                result.Data = new { Success = service.LeaveComment(comment) };
            }
            catch (Exception ex)
            {
                result.Data = new { Success = false,Message = ex.Message };
            }

            return result;
        }
    }
}