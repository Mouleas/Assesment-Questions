using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace TextEditor.Controllers
{
    public class TextEditorController : Controller
    {
        IConfiguration configuration;
        SqlConnection connection;
        public TextEditorController(IConfiguration configuration) 
        {
            this.configuration = configuration;
            connection = new SqlConnection(this.configuration.GetConnectionString("EditorDB"));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            string filename = collection["filename"];
            if (CheckIfExist(filename))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("FetchFile", connection);
                    cmd.Parameters.AddWithValue("@name", filename);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    string content = cmd.ExecuteScalar().ToString();
                    ViewData["content"] = content;
                    ViewData["filename"] = filename;
                    connection.Close();
                    return RedirectToAction("EditFile", "TextEditor", new { filename = filename });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ViewData["err"] = ex.Message;
                    return View();
                }
            }
            else
            {
                ViewData["err"] = "*File not found";
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection) 
        {
            string filename = collection["filename"];
            string textarea = collection["text-area"];
            try
            { 
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddFile", connection);
                cmd.Parameters.AddWithValue("@name", filename);
                cmd.Parameters.AddWithValue("@content", textarea);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                ViewData["err"] = "*File already present with this name";
                ViewData["content"] = textarea;
                return View();
            }
            return RedirectToAction("Index", "TextEditor");
            

        }

        public bool CheckIfExist(string filename)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(name) from files WHERE name='{filename}'",connection);
                int count = (int)cmd.ExecuteScalar();
                connection.Close();
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        
        public ActionResult EditFile(string filename)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("FetchFile", connection);
                cmd.Parameters.AddWithValue("@name", filename);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                string content = cmd.ExecuteScalar().ToString();
                ViewData["content"] = content;
                ViewData["filename"] = filename;
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }


        [HttpPost]
        public ActionResult EditFile(IFormCollection collection) 
        {
            string filename = collection["filename"];
            string content = collection["text-area"];
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateFile", connection);
                cmd.Parameters.AddWithValue("@name", filename);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                connection.Close();
                ViewData["filename"] = filename;
                ViewData["content"] = content;
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

    }
}
