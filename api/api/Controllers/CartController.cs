﻿using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addCart")]
        public async Task<IActionResult> AddCart([FromBody] CartDto cartDto)
        {
            var userIdString = User.FindFirst("UserId")?.Value;
            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized("Bạn cần đăng nhập để mua hàng");
            }
            int userId = int.Parse(userIdString);
            var existingCart = await _context.carts
                .Where(
                    p=>p.ProductId==cartDto.ProductId 
                    && p.UserId== userId
                    && p.Size==cartDto.Size
                    && p.Color==cartDto.Color
                ).SingleOrDefaultAsync();
            if (existingCart != null)
            {
                existingCart.Quantity += cartDto.Quantity ?? 1;
                existingCart.TotalAmount += cartDto.TotalAmount;
                _context.carts.Update(existingCart);
            }
            else
            {
                var newCart = new Cart()
                {
                    UserId = userId,
                    ProductId = cartDto.ProductId,
                    Quantity = cartDto.Quantity ?? 1,
                    Size = cartDto.Size,
                    Color = cartDto.Color,
                    TotalAmount = cartDto.TotalAmount
                };
                _context.carts.Add(newCart);
            }
            await _context.SaveChangesAsync();

            return Ok("Add to cart success");
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var cart = await _context.carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound(new { message = "Cart item not found" });
            }
            _context.carts.Remove(cart);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Delete success" });
        }
       
    }
}
