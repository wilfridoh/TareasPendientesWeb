using Microsoft.AspNetCore.Mvc;
using TareasPendientesWeb.Models;
using TareasPendientesWeb.Service;

namespace TareasPendientesWeb.Controllers
{
    public class TareasController : Controller
    {

        private readonly TareasPendientesService _tareasPendientesService;

        public TareasController()
        {
            var httpClient = new HttpClient();
            _tareasPendientesService = new TareasPendientesService(httpClient);
        }

        // GET: Tareas
        public async Task<ActionResult> Index()
        {
            IEnumerable<TareasPendientes> tareas = await _tareasPendientesService.GetTareasPendientesAsync();
            return View(tareas);
        }

        // GET: Tareas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            TareasPendientes tarea = await _tareasPendientesService.GetTareaPendienteAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        // GET: Tareas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tareas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TareasPendientes tareasPendientes)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = await _tareasPendientesService.CreateTareaPendienteAsync(tareasPendientes);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(tareasPendientes);
        }


        // GET: Tareas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            TareasPendientes tarea = await _tareasPendientesService.GetTareaPendienteAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        // POST: Tareas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TareasPendientes tareasPendientes)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = await _tareasPendientesService.UpdateTareasPendientesAsync(id, tareasPendientes);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(tareasPendientes);
        }

        // GET: Tareas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            TareasPendientes tarea = await _tareasPendientesService.GetTareaPendienteAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bool isSuccess = await _tareasPendientesService.DeleteTareasPendientesAsync(id);
            if (isSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }

}
