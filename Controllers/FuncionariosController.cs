using GerenciamentoLojaMVC.Data;
using GerenciamentoLojaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GerenciamentoLojaMVC.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FuncionariosController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<FuncionariosModel> funcionarios = _db.Funcionarios;
            return View(funcionarios);
        }
            
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Cadastrar(FuncionariosModel funcionarios)
        {
            if (ModelState.IsValid)
            {
                _db.Funcionarios.Add(funcionarios);
                _db.SaveChanges();

               TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FuncionariosModel funcionarios = _db.Funcionarios.FirstOrDefault(x => x.FuncionarioId == id);

            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        [HttpPost]
        public IActionResult Editar(FuncionariosModel funcionarios)
        {
            if (ModelState.IsValid)
            {
                _db.Funcionarios.Update(funcionarios);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }

            return View(funcionarios);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FuncionariosModel funcionarios = _db.Funcionarios.FirstOrDefault(x => x.FuncionarioId==id);

            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        [HttpPost]
        public IActionResult Excluir(FuncionariosModel funcionarios)
        {
            if (ModelState.IsValid)
            {
                _db.Funcionarios.Remove(funcionarios);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";

                return RedirectToAction("Index");
            }

            return View(funcionarios);
        }

    }
}
