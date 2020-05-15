using MC.PDFReader;
using PDFReader.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDFReader.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult FileUploader()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult FileUploader(PDFFile membervalues)
        {
            //string FileName = Path.GetFileNameWithoutExtension(membervalues.PDFFileName.FileName);

            ////To Get File Extension  
            //string FileExtension = Path.GetExtension(membervalues.PDFFileName.FileName);

            ////Add Current Date To Attached File Name  
            //FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
            string errorLogPathStr = ConfigurationManager.AppSettings["ErrorLogPath"];
            string errorLogPath = Server.MapPath(errorLogPathStr);
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    string UploadPathConfig = ConfigurationManager.AppSettings["UploadPath"].ToString();
                    string UploadPath = Server.MapPath(UploadPathConfig);
                    var path = Path.Combine(UploadPath, fileName);//+"_"+Guid.NewGuid().ToString()
                    if (!System.IO.File.Exists(path))
                        file.SaveAs(path);
                    TextExtraction textExtraction = new TextExtraction();
                    Dictionary<string, Int64> keyValuePairs = textExtraction.CalculatePages(path, errorLogPath);
                    ViewBag.PDFInfo = keyValuePairs;
                    ViewBag.FilePath = path;

                }
            }

            //Get Upload path from Web.Config file AppSettings.  


            //Its Create complete path to store in server.  
            //membervalues.ImagePath = UploadPath + FileName;

            //To copy and save file into server.  
            //membervalues.PDFFileName.SaveAs(membervalues.ImagePath);

            return View();
        }
        //[EnableCors(origins: "http://systematixindia.com", headers: "*", methods: "*")]
        [HttpPost]
        public ActionResult FileUploaderAjax(PDFFile membervalues)
        {
            //string FileName = Path.GetFileNameWithoutExtension(membervalues.PDFFileName.FileName);

            ////To Get File Extension  
            //string FileExtension = Path.GetExtension(membervalues.PDFFileName.FileName);

            ////Add Current Date To Attached File Name  
            //FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
            string errorLogPathStr = ConfigurationManager.AppSettings["ErrorLogPath"];
            string errorLogPath = Server.MapPath(errorLogPathStr);
            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        string UploadPathConfig = ConfigurationManager.AppSettings["UploadPath"].ToString();
                        string UploadPath = Server.MapPath(UploadPathConfig);
                        var path = Path.Combine(UploadPath, fileName);//+"_"+Guid.NewGuid().ToString()

                        if (!System.IO.File.Exists(path))
                            file.SaveAs(path);
                        TextExtraction textExtraction = new TextExtraction();
                        Dictionary<string, Int64> keyValuePairs = textExtraction.CalculatePages(path, errorLogPath);
                        ViewBag.PDFInfo = keyValuePairs;
                        ViewBag.FilePath = path;
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                        return Json(new { Total = keyValuePairs["TotalPages"], Colored = keyValuePairs["ColorPages"], BlackAndWhite = keyValuePairs["BWPages"] }, JsonRequestBehavior.AllowGet);

                    }
                }
            }
            catch (Exception ex)
            {
                CreateLog(ex, errorLogPath);
            }

            //Get Upload path from Web.Config file AppSettings.  


            //Its Create complete path to store in server.  
            //membervalues.ImagePath = UploadPath + FileName;

            //To copy and save file into server.  
            //membervalues.PDFFileName.SaveAs(membervalues.ImagePath);

            return View();
        }
        public static void CreateLog(Exception ex, string errorLogPath)
        {
            
            using (StreamWriter file =
            System.IO.File.AppendText(errorLogPath + "ErrorLog.txt"))
            {
                file.WriteLine();
                file.WriteLine("----------------------------------------------------");
                file.WriteLine("\n\n\n****** Exception starts here  *************");
                file.WriteLine("****** Time: " + Convert.ToString(DateTime.Now) + "  *************");
                file.WriteLine("Exception Message: " + ex.Message);
                file.WriteLine("Inner Exception : " + Convert.ToString(ex.InnerException));
                file.WriteLine("Stack Trace: " + ex.StackTrace);
                file.WriteLine("****** ///Exception Ends here  *************\n\n\n\n\n");
                file.WriteLine("----------------------------------------------------");
                file.WriteLine();
            }
        }

    }
}