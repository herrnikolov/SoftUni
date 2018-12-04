using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            //TODO: Implement me ...
            using (var db = new ShoppingListDbContext())
            {
                var products = db.Products.ToList();

                return View(products);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            //TODO: Implement me ...
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            //TODO: Implement me ...
            using (var db = new ShoppingListDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            //TODO: Implement me ...
            using (var db = new ShoppingListDbContext())
            {
                var product = db.Products.Find(id);
                if (product != null)
                {
                    return View(product);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product product)
        {
            //TODO: Implement me ...
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            using (var db = new ShoppingListDbContext())
            {
                var productFromDb = db.Products.Find(product.Id);
                if (productFromDb != null)
                {
                    productFromDb.Priority = product.Priority;
                    productFromDb.Name = product.Name;
                    productFromDb.Quantity = product.Quantity;
                    productFromDb.Status = product.Status;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}