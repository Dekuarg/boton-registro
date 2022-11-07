using Microsoft.AspNetCore.Mvc;
using probandoboton.Models;
using probandoboton.Encriptacion;
namespace probandoboton.Controllers
{
    public class AccessController : Controller
    {
        private readonly ApplicationUser _auc;

        public AccessController(ApplicationUser auc)
        {
            _auc = auc;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
    
        public IActionResult Create([FromBody] User uc)
        {
            bool success = false;
            if (!string.IsNullOrEmpty(uc.Clave))
            {
                success = true; 
              uc.Clave = Encriptados.ConvertSha256(uc.Clave); 
            }
            else
            {
                return Ok("No se pudo crear la clave");
            }
            
            _auc.Add(uc);
            _auc.SaveChanges();
            return Ok(success ? "OK" : "ERROR");
            
            
        }

        [HttpPost]

        public IActionResult login([FromBody] UserEntity uc)
        {
            bool success = false;
            if (!string.IsNullOrEmpty(uc.Clave))
            {
                success = true;
                uc.Clave = Encriptados.ConvertSha256(uc.Clave);
            }
            var usuario = _auc.test.Where(s => s.Usuario == uc.Usuario && s.Clave == uc.Clave);

            if (usuario.Any())
            {
               return Ok("buenmo");
            }
            else
            {
                return Ok("oooooo");
            }
            



        }


        [HttpGet]

        public IActionResult Getlogin([FromBody] UserEntity uc)
        {
            bool success = false;
            if (!string.IsNullOrEmpty(uc.Clave))
            {
                success = true;
                uc.Clave = Encriptados.ConvertSha256(uc.Clave);
            }
            var usuario = _auc.test.Where(s => s.Usuario == uc.Usuario && s.Clave == uc.Clave);

            if (usuario.Any())
            {
                return Ok("buenmo");
            }
            else
            {
                return Ok("oooooo");
            }




        }

    }
}
