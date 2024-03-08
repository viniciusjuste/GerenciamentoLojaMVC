using GerenciamentoLojaMVC.Data;
using GerenciamentoLojaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoLojaMVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly  ApplicationDbContext _db;
        public ProdutosController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ProdutosModel> produtos = _db.Produtos;
            return View(produtos);
        }

        [HttpGet]
         public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ProdutosModel produtos)
        {
            if (ModelState.IsValid) 
            {
                _db.Produtos.Add(produtos);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
      
            ProdutosModel produtos = _db.Produtos.FirstOrDefault(x => x.ProdutoId == id);
          
            if (produtos == null)
            {
                return NotFound();
            }
            
            return View(produtos);
        }

        [HttpPost]
        public IActionResult Editar(ProdutosModel produtos)
        {
            if (ModelState.IsValid)
            {
                _db.Produtos.Update(produtos);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";
                return RedirectToAction("Index");
            }

            return View(produtos);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            ProdutosModel produtos = _db.Produtos.FirstOrDefault(x => x.ProdutoId == id);

            if (produtos == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        [HttpPost]
        public IActionResult Excluir(ProdutosModel produtos)
        {
            if (ModelState.IsValid)
            {
                _db.Produtos.Remove(produtos);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";
                return RedirectToAction("Index");
            }

            return View(produtos);
        }
    }
}
