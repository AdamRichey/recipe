using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Plate.Controllers
{
    public class HomeController : Controller
    {
        private platecontext _context;
    
        public HomeController(platecontext context)
        {
            _context = context;
        }
//***********************************************************login register*******************************************
        [HttpPost]
        [Route("vlogin")]
        public IActionResult vlogin(string email, string password)
        {
                Person ReturnedValue = _context.Users.SingleOrDefault(User => User.Email == email);
                if(ReturnedValue == null)
                {
                    TempData["login"]="Invalid Username";
                    return RedirectToAction("index");
                }
                else if(ReturnedValue.Password != password)
                {
                    TempData["login"]="Invalid Password";
                    return RedirectToAction("index");
                }
                else
                {
                    HttpContext.Session.SetString("user",email);
                    return RedirectToAction("welcome");

                } 
        }

        [HttpPost]
        [Route("vregister")]
        
        public IActionResult vregister(Personvm Model, string first, string last, string email, string username, string password)
        {
            if(ModelState.IsValid)
            {
                Person NewPerson = new Person
                {
                    First=first,
                    Last=last,
                    Email=email,
                    Username=username,
                    Password=password,
                };
                HttpContext.Session.SetString("user",email);
                _context.Add(NewPerson);
                _context.SaveChanges();
                return RedirectToAction("welcome");
            }
            else{
                ViewBag.errors = ModelState.Values;
                return View("index");
            }         
            
        }
            [Route("logout")]
            public IActionResult logout()
            {
                HttpContext.Session.SetString("user", "null");
                return RedirectToAction("index");

            }

//*********************************************************pageviews***********************************************************

        [Route("")]
        public IActionResult Index()
        {
            ViewBag.login=TempData["login"];
            ViewBag.errors = "";
            return View("index");
        }

        [Route("welcome")]
        public IActionResult Welcome()
        {
            string a1 = HttpContext.Session.GetString("user");
            if(a1 == "null")
            {
                return RedirectToAction("index");
            }
            else{
                Person a3 = _context.Users.SingleOrDefault(user => user.Email == a1);
                ViewBag.name=a3.First;
                ViewBag.favorites = _context.Favorites.Include(Favorites => Favorites.Recipe).ThenInclude(Favorites => Favorites.Person).Where(Favorites => Favorites.Person == a3).Take(5);
                int a4 = _context.Recipes.Where(Recipes => Recipes.Person != a3).Count();
                Random rnd = new Random();
                int a5 = rnd.Next(0,a4);
                if(a4 == 0){
                    ViewBag.Random = "Not Enough Recipes On File";
                }
                else{
                    ViewBag.Random = _context.Recipes.SingleOrDefault(Recipes => Recipes.id == a5);
                }
                return RedirectToAction("profile");
            }
        }

        [Route("cart")]
        public IActionResult Cart()
        {
            return View("cart");
        }


//**********************************************************New Recipe*************************************************

        [Route("create")]
        public IActionResult Create()
        {
            return View("create");
        }

        [HttpPost]
        [Route("vcreate")]
        public IActionResult vcreate(Recipes model, string name, string serves, string description)
        {
            string a1 = HttpContext.Session.GetString("user");
            Person a3 = _context.Users.SingleOrDefault(user => user.Email == a1);

            if(ModelState.IsValid)
            {
                Recipes NewRecipe = new Recipes
                {
                    Name=name,
                    Serves=serves,
                    Description=description,
                    Directions="  ",
                    Start=DateTime.Now,
                    Personid=a3.id,
                    Person=a3,
                };
                HttpContext.Session.SetString("recipe",description);
                _context.Add(NewRecipe);
                _context.SaveChanges();
                return RedirectToAction("Ingredients");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("create");
            }
        }
        
        [Route("ingredients")]
        public IActionResult Ingredients()
        {
            string a1 = HttpContext.Session.GetString("recipe");
            Recipes a2 =_context.Recipes.SingleOrDefault(Recipes => Recipes.Description == a1);
            List<Ingredients> a3 = _context.Ingredients.Where(ingredients => ingredients.Recipe == a2).ToList(); 
            ViewBag.recipename=a2.Name; 
            ViewBag.recipedescription=a2.Description;
            ViewBag.ingredient=a3; 
            return View("Ingredients");
        }
        [HttpPost]
        [Route("vingredients")]
        public IActionResult VIngredients(string iname, string amount, string comment)
        {
            string a1 = HttpContext.Session.GetString("recipe");
            Recipes a2 =_context.Recipes.SingleOrDefault(Recipes => Recipes.Description == a1);
            if(ModelState.IsValid)
            {
                Ingredients NewIngredient = new Ingredients
                {
                    Name=iname,
                    Amount=amount,
                    Comment=comment,
                    Recipeid=a2.id,
                    Recipe=a2,
                };
                _context.Add(NewIngredient);
                _context.SaveChanges();
                return RedirectToAction("Ingredients");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("ingredients");
            }
        }
        [HttpPost]
        [Route("directions")]
        public IActionResult Directions()
        {
            string a1 = HttpContext.Session.GetString("recipe");
            Recipes a2 =_context.Recipes.SingleOrDefault(Recipes => Recipes.Description == a1);
            ViewBag.recipename=a2.Name; 
            return View("directions");
        }
        [HttpPost]
        [Route("complete")]
        public IActionResult Complete(string directions)
        {
            string p1 = HttpContext.Session.GetString("user");
            Person p2 = _context.Users.SingleOrDefault(user => user.Email == p1);
            string r1 = HttpContext.Session.GetString("recipe");
            Recipes r2 =_context.Recipes.SingleOrDefault(Recipes => Recipes.Description == r1);
            r2.Directions=directions;
            _context.SaveChanges();
            Favorites NewFavorite = new Favorites
            {
                Personid=p2.id,
                Person=p2,
                Recipeid=r2.id,
                Recipe=r2,
                };
            _context.Add(NewFavorite);
            _context.SaveChanges();
            return Redirect("welcome");
        }


//*************************************************************Profile Page***************************************************
        [Route("profile")]
        public IActionResult Profile()
        {
            string a1 = HttpContext.Session.GetString("user");
            Person a2 = _context.Users.SingleOrDefault(user => user.Email == a1);
            List<Recipes> a3 = _context.Recipes.Where(recipes => recipes.Person == a2).ToList();
            ViewBag.recipes = a3;
            ViewBag.name=a2.First;
            ViewBag.favorites = _context.Favorites.Include(Favorites => Favorites.Recipe).ThenInclude(Favorites => Favorites.Person).Where(Favorites => Favorites.Person == a2).Take(5);
            return View("profile");
        }

//****************************************************************All Recipes*************************************************************
        [Route("browse")]
        public IActionResult Browse()
        {
            string a1 = HttpContext.Session.GetString("user");
            Person a2 = _context.Users.SingleOrDefault(user => user.Email == a1);
            //List<Recipes> a3 = _context.Recipes.Where(recipes => recipes.Person != a2).ToList();
            //ViewBag.recipes = a3;
            IList<Recipes> recipes = _context.Recipes.Include(Recipes => Recipes.Person).Where(Recipes => Recipes.Person != a2).ToList();
            ViewBag.recipes = recipes;
            return View("browse");
        }


//***************************************************************All Users **************************************************************
        [Route("connect")]
        public IActionResult Connect()
        {
            string a1 = HttpContext.Session.GetString("user");
            ViewBag.person = _context.Users.Where(recipes => recipes.Email != a1);
            return View("connect");
        }
//*****************************************************************Favorites********************************************************************* *//

        [Route("favorites")]
        public IActionResult Favorites()
        {
            string a1 = HttpContext.Session.GetString("user");
            Person a3 = _context.Users.SingleOrDefault(user => user.Email == a1);
            ViewBag.favorites = _context.Favorites.Include(Favorites => Favorites.Recipe).ThenInclude(Favorites => Favorites.Person).Where(Favorites => Favorites.Person == a3).Take(5);
            return View("favorites");
        }
        [HttpPost]
        [Route("favorites/add/{id}")]
        public IActionResult AddFavorite(int id)
        {
            string a1 = HttpContext.Session.GetString("user");
            Person a3 = _context.Users.SingleOrDefault(user => user.Email == a1);
            int a4 = a3.id;
            Recipes r1 =_context.Recipes.SingleOrDefault(Recipes => Recipes.id == id);
            Favorites NewFavorite = new Favorites{
                Personid = a4,
                Recipeid = id,
                Person = a3,
                Recipe = r1,
            };
            _context.Add(NewFavorite);
            _context.SaveChanges();
            return RedirectToAction("Favorites");
        }
//**********************************************************Recipe Info *************************************** *//
        [Route("recipe/{id}")]
        public IActionResult RecipeDetail(int id)
        {
            Recipes r1 =_context.Recipes.SingleOrDefault(Recipes => Recipes.id == id);
            IList<Ingredients> ingredients = _context.Ingredients.Include(Ingredients => Ingredients.Recipe).Where(Ingredients => Ingredients.Recipe == r1).ToList();
            ViewBag.Ingredient = ingredients;
            ViewBag.recipe = r1;
            ViewBag.Comment =_context.Comments.Include(Comments => Comments.Person).ToList();
            return View("recipeid");
        }
//*************************************************************comments *********************************** *//
        [HttpPost]
        [Route("comment/{id}")]
        public IActionResult Comment(int id, string comment)
        {
            Recipes r1 =_context.Recipes.SingleOrDefault(Recipes => Recipes.id == id);
            string a1 = HttpContext.Session.GetString("user");
            Person a3 = _context.Users.SingleOrDefault(user => user.Email == a1);
            Comments NewComment = new Comments{
                Recipeid = id,
                Comment = comment,
                Recipe = r1,
                Person =a3,
            };
            _context.Add(NewComment);
            _context.SaveChanges();
            return RedirectToAction("RecipeDetail");
        }
//********************************************************Deleting*************************************************
        [Route("rdelete/{id}")]
        public IActionResult rdelete(int id)
        {
            Recipes r1 =_context.Recipes.SingleOrDefault(Recipes => Recipes.id == id);
            _context.Remove(r1);
            _context.SaveChanges();
            return RedirectToAction("profile");
        }

        [Route("fdelete/{id}")]
        public IActionResult fdelete(int id)
        {
            Favorites r1 =_context.Favorites.SingleOrDefault(Favorites => Favorites.id == id);
            _context.Remove(r1);
            _context.SaveChanges();
            return RedirectToAction("favorites");
        }
//*****************************************************************SChedule************************************** */
        [Route("schedule")]
        public IActionResult Schedule()
        {
            string a1 = HttpContext.Session.GetString("user");
            Person a3 = _context.Users.SingleOrDefault(user => user.Email == a1);
            ViewBag.favorites = _context.Favorites.Include(Favorites => Favorites.Recipe).ThenInclude(Favorites => Favorites.Person).Where(Favorites => Favorites.Person == a3).Take(5);
            ViewBag.recipes = _context.Recipes.Include(Recipes => Recipes.Person).Where(Recipes => Recipes.Person != a3).ToList();
            return View("schedule");

        }

        [Route("sadd")]
        public IActionResult sadd(int id)
        {
            string a1 = HttpContext.Session.GetString("user");
            Person a3 = _context.Users.SingleOrDefault(user => user.Email == a1);
            Recipes a4 = _context.Recipes.SingleOrDefault(Recipes => Recipes.id == id);
//string a = "25";

//int b = atoi(a.c_str());
            @ViewBag.Recipe = id;
            @ViewBag.Name = a3;
            return View("welcome");
        }
    }
}



