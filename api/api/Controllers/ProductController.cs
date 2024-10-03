using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context=context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] ProductDto productDto)
        {
            if (string.IsNullOrEmpty(productDto.Name))
            {
                return BadRequest("Tên sản phẩm không được để trống");
            }
            if (productDto.CategoryId==null || productDto.CategoryId<=0)
            {
                return BadRequest("Vui lòng chọn thể loại sản phẩm");
            }
            if (productDto.Price == null || productDto.Price <= 0)
            {
                return BadRequest("Vui lòng nhập giá sản phẩm");
            }
            if (string.IsNullOrEmpty(productDto.Image))
            {
                return BadRequest("Vui lòng chọn ảnh cho sản phẩm");
            }

            var newProduct = new Product
            {
                Name = productDto.Name,
                CategoryId = productDto.CategoryId,
                Price = productDto.Price,
                Image = productDto.Image,
                Description = productDto.Description,
                Sell = 0,
                CreatedDate = DateTime.UtcNow
            };
            if (productDto.Discounted.HasValue && productDto.Discounted > 0)
            {
                newProduct.Discounted = productDto.Discounted;
                newProduct.DiscountedPrice = newProduct.Price - (newProduct.Price * (productDto.Discounted.Value / 100));
            }
            else
            {
                newProduct.Discounted = null; 
                newProduct.DiscountedPrice = null; 
            }
            _context.products.Add(newProduct);
            await _context.SaveChangesAsync();
            return Ok("Thêm mới thành công");
        }
        [HttpGet("getByPage")]
        public async Task<IActionResult> getByPage(int page=1,int limit=5)
        {
            var products=await _context.products
                .Skip((page - 1) * limit)
                .Take(limit).ToListAsync();
            var productDtos = products.Select(product => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Image= product.Image,
                Description = product.Description,
                Price = product.Price,
                Discounted = product.Discounted,
                FinalPrice = product.GetFinalPrice() 
            }).ToList();
            return Ok(productDtos);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var products = await _context.products.ToListAsync();
            var productDtos = products.Select(product => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
                Price = product.Price,
                Discounted = product.Discounted,
                FinalPrice = product.GetFinalPrice()
            }).ToList();
            return Ok(productDtos);
        }
        [HttpGet("getNew")]
        public async Task<IActionResult> getNew()
        {
            var products = await _context.products
                .OrderByDescending(p => p.CreatedDate)
                .Take(4) 
                .ToListAsync();
            var productDtos = products.Select(product => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
                Price = product.Price,
                Discounted = product.Discounted,
                FinalPrice = product.GetFinalPrice()
            }).ToList();
            return Ok(productDtos);
        }
        [HttpGet("getDiscount")]
        public async Task<IActionResult> getDiscount()
        {
            var products = await _context.products
                .Where(p => p.Discounted.HasValue && p.Discounted > 0) 
                .OrderByDescending(p => p.CreatedDate)
                .Take(12)
                .ToListAsync();
            var productDtos = products.Select(product => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
                Price = product.Price,
                Discounted = product.Discounted,
                FinalPrice = product.GetFinalPrice()
            }).ToList();
            return Ok(productDtos);
        }

        [HttpGet("getOne/{id}")]
        public async Task<IActionResult> getOne(int id)
        {
            var product=await _context.products
                .Include(p=>p.Category)
                .Include(c=>c.ProductImages)
                .Include(c=>c.ProductSizes)
                .ThenInclude(pc => pc.Size)
                .Include(c=>c.ProductColors)
                .ThenInclude(pc => pc.Color)
                .FirstOrDefaultAsync(x=>x.ProductId==id);
            return Ok(product);
        }
        [HttpGet("getByCategory/{categoryId}")]
        public async Task<IActionResult> getByCategory(int categoryId,int page=1,int limit=4, string? sort = null, int? maxPrice = null, int? minPrice = null, string? size = null, string? color = null)
        {
            var query = _context.products.AsQueryable().Where(p => p.CategoryId == categoryId);
            if(minPrice.HasValue)
            {
                query=query.Where(p=>p.Price>=minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }
            if (!string.IsNullOrEmpty(size))
            {
                query = query.Where(p => p.ProductSizes.Any(ps => ps.Size.Name == size));
            }
            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(p => p.ProductColors.Any(pc=>pc.Color.Name == color)); 
            }
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "price_asc":
                        query = query.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        query = query.OrderByDescending(p => p.Price);
                        break;
                    case "new":
                        query = query.OrderByDescending(p => p.CreatedDate); ;
                        break;
                    default:
                        break;
                }
            }
            var products = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            // Lấy thông tin category
            var category = await _context.categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);

            // Chuyển đổi dữ liệu sản phẩm thành DTO
            var productDtos = products.Select(product => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
                Price = product.Price,
                Discounted = product.Discounted,
                FinalPrice = product.GetFinalPrice()
            }).ToList();
            return Ok(new{category=category, product=productDtos});
        }

        [HttpGet("search")]
        public async Task<IActionResult> search(string? q,int page=1,int limit=8)
        {
            var query = _context.products.AsQueryable();

            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(p => p.Name.Contains(q));
            }
            int totalItems = await query.CountAsync();
            var products = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
            var productDtos = products.Select(product => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
                Price = product.Price,
                Discounted = product.Discounted,
                FinalPrice = product.GetFinalPrice()
            }).ToList();
            return Ok(new
            {
                total = totalItems,
                products = productDtos
            });
        }
    }
}
