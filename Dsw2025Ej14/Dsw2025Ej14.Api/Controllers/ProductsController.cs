using Microsoft.AspNetCore.Mvc;
using Dsw2025Ej14.Api.Data;
using Dsw2025Ej14.Api.Domain;

namespace Dsw2025Ej14.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly PersistenciaEnMemoria _persistencia;

        public ProductsController(PersistenciaEnMemoria persistencia)
        {
            _persistencia = persistencia;
        }

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetActiveProducts()
        {
            var products = _persistencia.GetActiveProducts();

            if (products == null || !products.Any())
                return NoContent();

            return Ok(products);
        }

        // GET: api/products/{sku}
        [HttpGet("{sku}")]
        public ActionResult<Product> GetBySku(string sku)
        {
            var product = _persistencia.GetProductBySku(sku);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
