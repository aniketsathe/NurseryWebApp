using System.Linq;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using NurseryWebApp.DataAccessLayer.ApplicationDB;
using NurseryWebApp.Models;

public class AccountController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Account/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            // Hash the entered password using the same hashing algorithm as stored in the database
            string enteredPasswordHash = GetHashString(model.Password);

            // Query the database to find the user with the matching username and password
            var user = db.Users.SingleOrDefault(u => u.Username == model.Username && u.PasswordHash == enteredPasswordHash);

            if (user != null)
            {
                // User found, create a session or authentication cookie
                Session["Username"] = user.Username;  // Store user info in session
                return RedirectToAction("Dashboard", "Home");  // Redirect to home page
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }
        }

        // If we got this far, something failed, redisplay the form
        return View(model);
    }

    // Helper method to hash passwords
    private string GetHashString(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    // Logout
    [HttpPost]
    public ActionResult Logout()
    {
        // Clear the session
        Session.Clear();
        return RedirectToAction("Login");
    }
}
