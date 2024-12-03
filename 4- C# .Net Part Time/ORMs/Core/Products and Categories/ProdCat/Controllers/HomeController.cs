using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProdCat.Models;

namespace ProdCat.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //PRODUCTS

    // View all products
    [HttpGet("")]
    public IActionResult Index()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllProducts = _context.Products.ToList()
        };
        return View(MyModel);
    }

    // Post create product
    [HttpPost("products/create")]
    public IActionResult AddProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            MyViewModel MyModel = new MyViewModel
            {
                AllProducts = _context.Products.ToList()
            };
            return View("Index", MyModel);
        }
    }


    //CATEGORIES

    // View all categories
    [HttpGet("categories")]
    public IActionResult Categories()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllCategories = _context.Categories.ToList()
        };
        return View(MyModel);
    }

    // Post create category
    [HttpPost("categories/create")]
    public IActionResult AddCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        else
        {
            MyViewModel MyModel = new MyViewModel
            {
                AllCategories = _context.Categories.ToList()
            };
            return View("Categories", MyModel);
        }
    }

    //VIEW ONE PRODUCT 
    // View One Product
    [HttpGet("products/{Id}")]
    public IActionResult OneProduct(int Id)
    {
        // get product by Id
        ViewBag.OneProduct = _context.Products.FirstOrDefault(i => i.ProductId == Id);
        // get list of all categories created
        List<Category> AllCategories = _context.Categories.OrderBy(n => n.Name).ToList();
        ViewBag.AllCategories = AllCategories;
        // Get the products with joined categories
        var ProdsAndCats = _context.Products
                                .Include(a => a.MyProducts)
                                .ThenInclude(a => a.Category)
                                .FirstOrDefault(p => p.ProductId == Id);
        ViewBag.ProdsAndCats = ProdsAndCats;
        // Create an empty list
        List<Category> JoinedCats = new List<Category>();
        // push all associated categories to list // this must be done to use "EXCEPT"
        foreach (var c in ProdsAndCats.MyProducts)
        {
            JoinedCats.Add(c.Category);
        }
        // compare using Except and filter out 'associated' categories
        List<Category> FilteredCats = AllCategories.Except(JoinedCats).ToList();
        ViewBag.FilteredCats = FilteredCats;
        return View();
    }

    //VIEW ONE CATEGORY
    // View One Category
    [HttpGet("categories/{Id}")]  
    public IActionResult OneCategory(int Id)
    {
        // get category by Id
        ViewBag.OneCategory = _context.Categories.FirstOrDefault( i => i.CategoryId == Id);
        // get list of all products created
        List<Product> AllProducts = _context.Products.OrderBy(n => n.Name).ToList();
        ViewBag.AllProducts = AllProducts;
        // Get the categories with joined products
        var CatsAndProds =_context.Categories
                                .Include(a => a.MyCategories)
                                .ThenInclude(a => a.Product)
                                .FirstOrDefault(p => p.CategoryId == Id);
        ViewBag.CatsAndProds = CatsAndProds;
        // Create an empty list
        List<Product> JoinedProds = new List<Product>();
        // push all associated products to list // this must be done to use "EXCEPT" function
        foreach (var c in CatsAndProds.MyCategories){
            JoinedProds.Add(c.Product);
        }
        // compare using Except and filter out 'associated' products
        List<Product> FilteredProds = AllProducts.Except(JoinedProds).ToList();
        ViewBag.FilteredProds = FilteredProds;
        return View();
    }



    ////   CREATE ASSOCIATIONS   ////

    // join categories action
    [HttpPost("productaddcat")] 
    public IActionResult productAddCat(Association newAssoc)
    {
            _context.Add(newAssoc);
            _context.SaveChanges();
            return RedirectToAction("OneProduct", new { Id = newAssoc.ProductId });
    }

    // join products action
    [HttpPost("catandprod")]
    public IActionResult catAddProd(Association newAssoc)
    {
        _context.Add(newAssoc);
        _context.SaveChanges();
        return RedirectToAction("OneCategory", new { Id = newAssoc.CategoryId });
    }

    ////   REMOVE ASSOCIATIONS   ////

    // remove association => return to category by Id
    [HttpPost("catandprod/{Id}/delete")] 
    public IActionResult removeProd(int Id)
    {
        Association ProdToRemove = _context.Associations.SingleOrDefault(p => p.AssociationId == Id);
        _context.Associations.Remove(ProdToRemove);
        _context.SaveChanges();
        return RedirectToAction("OneCategory", new {Id = ProdToRemove.CategoryId});
    }


    // remove association => return to product by Id
    [HttpPost("productaddcat/{Id}/delete")] 
    public IActionResult removeCat(int Id)
    {
        Association? CatToRemove = _context.Associations.SingleOrDefault(c => c.AssociationId == Id);
        _context.Associations.Remove(CatToRemove);
        _context.SaveChanges();
        return RedirectToAction("OneProduct", new {Id = CatToRemove.ProductId});
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
