using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sana.webshop.web.Command;
using sana.webshop.web.Domain;
using sana.webshop.web.Handler;
using sana.webshop.web.Models;
using sana.webshop.web.Query;

namespace sana.webshop.web.Controllers
{
    public class ProductController : Controller
    {
        private static IProductHandler _handler;
        private static IProductQuery _query;
        private readonly IMapper _mapper;

        public ProductController(IProductHandler handler, IProductQuery query, IMapper mapper)
        {
            _handler = handler;
            _query = query;
            _mapper = mapper;
        }


        // GET: Product
        public ActionResult Index()
        {
            var products = _query.GetAll();

            return View(products);
        }


        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                CreateProduct command = new CreateProduct();
                command.IsInMemory = model.IsInMemory;
                command.Product = _mapper.Map<Product>(model);

                _handler.Handler(command);
                return RedirectToAction("Index");
            }

            return View();

        }


    }
}