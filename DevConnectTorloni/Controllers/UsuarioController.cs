
using System.Threading.Tasks;
using DevConnectTorloni.Contexts;
using DevConnectTorloni.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace DevConnectTorloni.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DevConnectContext _context;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, DevConnectContext context)
        {
            _logger = logger;
            _context = context;
        }

        //listar
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.UsuarioNovoCadastrado = "";
            TempData["UsuarioNovoCadastrado"] = "";
            return View();
        }
        //cadastrar
        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form)
        {
            //System.Console.WriteLine($"{form["NomeCompleto"]}");
            //System.Console.WriteLine($"{form.Files[0].FileName}");

            Usuario novoUsuario = new Usuario
            {
                NomeCompleto = form["NomeCompleto"].ToString(),
                NomeUsuario = form["NomeUsuario"].ToString(),
                Email = form["Email"].ToString(),
                Senha = form["Senha"].ToString()

            };

            if (form.Files.Count > 0)
            {

                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(folder))
                {

                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                   await file.CopyToAsync(stream);

                }

                novoUsuario.FotoPerfilUrl = file.FileName;

            }
            else
            {
                novoUsuario.FotoPerfilUrl = "";
            }

            try
            {
                _context.Usuario.Add(novoUsuario);

                await _context.SaveChangesAsync();

                TempData["UsuarioNovoCadastrado"] = "Cadastrado";
                ViewBag.UsuarioNovoCadastrado = "";

                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception e)
            {
                ViewBag.UsuarioNovoCadastrado = "Nao cadastrado";
                TempData["UsuarioNovoCadastrado"] = "";
                return View();
            }


        }

        public IActionResult Perfil()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}