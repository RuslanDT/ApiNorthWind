using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nortWind.Data;
using nortWind.Models;
using System.Xml.Linq;

namespace nortWind.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly NorthwindContext contexto;

        public ProductController(NorthwindContext context)
        {
            contexto = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return contexto.Products.OrderBy(p => p.ProductName);

        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> getAll()
        {
            var result = await contexto.Products.OrderBy(p => p.ProductName).ToListAsync();


            return Ok(result);

        }

        [HttpGet]
        [Route("GetNameAndPrice")]
        public IEnumerable<object> GetNameAndPrice()
        {
            IEnumerable<object> lista =
                from producto in contexto.Products
                select new
                {
                    Name = producto.ProductName,
                    Price = producto.UnitPrice,
                    //Category = producto.Category != null ? producto.Category.CategoryName : null
                };
            return lista;
        }

        [HttpGet]
        [Route("GetNameAndPrice2")]
        public IEnumerable<Product> GetNameAndPrice2()
        {
            IEnumerable<Product> listaP =
                from producto in contexto.Products
                select new Product()
                {
                    ProductName = producto.ProductName,
                    UnitPrice = producto.UnitPrice
                };
            return listaP;
        }
        [HttpGet]
        [Route("GetProductStatistics")]
        public IEnumerable<object> GetProductStatistics()
        {
            var result =
                from od in contexto.OrderDetails
                join o in contexto.Orders on od.OrderId equals o.OrderId
                join p in contexto.Products on od.ProductId equals p.ProductId
                where o.OrderDate.HasValue && o.OrderDate.Value.Year == 1996
                group od by new
                {
                    p.ProductName,
                    p.QuantityPerUnit,
                    p.UnitPrice
                } into g
                select new
                {
                    Articulo = g.Key.ProductName,
                    Unidades = g.Key.QuantityPerUnit,
                    PrecioUnitario = g.Key.UnitPrice,
                    VolumenDemandadoEn1996 = g.Sum(od => od.Quantity)
                };

            return result;
        }


        /*
            obtener el ombre del producto, categoria (nombre), 
            existencia de todos kos productos que estan que etsan activos con el uso del join 
        */
        [HttpGet]
        [Route("GetProductsActive")]
        public IEnumerable<object> GetProductsActive() {
            var result =
                from p in contexto.Products
                join c in contexto.Categories on p.CategoryId equals c.CategoryId
                where p.Discontinued == false
                select new
                {
                    name = p.ProductName,
                    category = c.CategoryName,
                    units = p.UnitsInStock
                };
            return result;
        }

        [HttpGet]
        [Route("GetProductsActive2")]
        public IEnumerable<object> GetProductsActive2()
        {
            var result = contexto.Products.
                Where(p => p.Discontinued == false).
                Join(contexto.Categories, (p) => p.CategoryId, (c) => c.CategoryId,
                    (p, c) => new {
                        name = p.ProductName,
                        category = c.CategoryName,
                        units = p.UnitsInStock
                    }
                );

            var result2 = contexto.Categories.
                Join(contexto.Products, (c) => c.CategoryId, (p) => p.CategoryId,
                    (c, p) => new {
                        name = p.ProductName,
                        category = c.CategoryName,
                        units = p.UnitsInStock,
                        activo = p.Discontinued
                    }
                ).
                Where(p => p.activo == false);
            return result2;
        }

        [HttpGet]
        [Route("GetProduct4Category")]
        public IEnumerable<object> GetProduct4Category()
        {
            /*var result = from p in contexto.Products
                        join c in contexto.Categories on p.CategoryId equals c.CategoryId
                        group p by c.CategoryName into g
                        select new
                        {
                            Category = g.Key,
                            Product = g.Count(),
                            Total = g.Sum(p => p.UnitsInStock * p.UnitPrice)
                        };
            */
            var result = contexto.Products.
                Join(contexto.Categories, p => p.CategoryId, c => c.CategoryId,
                    (p, c) => new { 
                        Product = p, Category = c 
                    }
                ).
                GroupBy(p => p.Category.CategoryName, (key, g) => new {
                    Category = key,
                    Product = g.Count(),
                    Total = g.Sum(p => p.Product.UnitsInStock * p.Product.UnitPrice)
                });

            return result;
        }


    }
}
