using AutoMapper;
using Demo1CoreCRUD.Interface;
using Demo1CoreCRUD.Models;
using Demo1CoreCRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo1CoreCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepo _homeRepo;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IHomeRepo homeRepo, IMapper mapper)
        {
            _logger = logger;
            _homeRepo = homeRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _homeRepo.GetAll();
            _logger.LogInformation($"{model.Count()} tasks retrieved.");
            return View(model);
        }

        public async Task<IActionResult> TaskComplete(int id)
        {   
            var task = await _homeRepo.GetById(id);
            if (task == null) return NotFound();
            task.Status = "Complete";
            bool saved = await _homeRepo.Update(task);
            if (saved) _logger.LogInformation($"Task '{task.Task}' has been completed");
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _homeRepo.GetById(id);            
            if (task == null) return NotFound();
            var model = _mapper.Map<EditTaskVM>(task);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditTaskVM editTaskVM)
        {
            if(!ModelState.IsValid) return View(editTaskVM);
            var model = _mapper.Map<ToDoList>(editTaskVM);
            bool saved = await _homeRepo.Update(model);
            if (saved) _logger.LogInformation($"Task '{editTaskVM.Name}' has been modified");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTaskVM createTaskVM)
        {
            if (!ModelState.IsValid) return View(createTaskVM);
            var map = _mapper.Map<ToDoList>(createTaskVM);
            bool saved = await _homeRepo.Add(map);
            if (saved) _logger.LogInformation($"A new task: '{createTaskVM.Name}' has been created");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _homeRepo.GetById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ToDoList toDoList)
        {
            if (!ModelState.IsValid) return View(toDoList);
            string msg = $"Task '{toDoList.Task}' has been deleted";
            bool saved = await _homeRepo.Delete(toDoList);
            if (saved) _logger.LogInformation(msg);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
