using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaCUB_API.Data;
using PruebaCUB_API.Models;

namespace PruebaCUB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var usuarios = await _dataContext.Usuarios.FromSqlRaw("EXEC GetUsuarios").ToListAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsyncByIdAsync(int id)
        {
            var usuario = await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            return Ok(usuario);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(Usuario usuario)
        {
            try
            {
                var newUsuario = usuario;
                _dataContext.Usuarios.Add(newUsuario);
                await _dataContext.SaveChangesAsync();
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Usuario usuario)
        {
            try
            {
                var usuarioUpdate = usuario;
                _dataContext.Usuarios.Update(usuarioUpdate);
                await _dataContext.SaveChangesAsync();
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var usuarioDelete = await _dataContext.Usuarios.SingleOrDefaultAsync(u => u.Id == id);
                _dataContext.Usuarios.Remove(usuarioDelete);
                await _dataContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
