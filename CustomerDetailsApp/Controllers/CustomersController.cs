using CustomerDetailsApp.DataAccess;
using CustomerDetailsApp.Handlers;
using CustomerDetailsApp.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDetailsApp.Controllers
{
    public class CustomersController(ICustomerRepository repo, IValidator<FieldsModel> validator) : Controller
    {

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var handler = new IndexQueryHandler(repo);
            var model = await handler.Handle();
            return View(model);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(DetailsQuery query)
        {
            if (!await repo.CustomerExists(query.Id))
            {
                return NotFound();
            }

            var handler = new DetailsQueryHandler(repo);
            var model = await handler.Handle(query);
            return View(model);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            var handler = new CreateQueryHandler();
            var model = handler.Handle();
            return View(model);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateModel model)
        {
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(model);

            if (ModelState.IsValid && validationResult.IsValid)
            {
                var handler = new CreateModelHandler(repo);
                await handler.Handle(model);
                return RedirectToAction(nameof(Index));
            }

            validationResult.AddToModelState(this.ModelState);

            return View(model);
        }

        // GET: Customers/Edit/5
        //[Route("Customers/Edit/{Id:int}")]
        public async Task<IActionResult> Edit(EditQuery query)
        {
            if (!await repo.CustomerExists(query.Id))
            {
                return NotFound();
            }

            var handler = new EditQueryHandler(repo);
            var model = await handler.Handle(query);
            return View(model);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditModel model)
        {
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(model);

            if (ModelState.IsValid && validationResult.IsValid)
            {
                var handler = new EditModelHandler(repo);
                var result = await handler.Handle(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            validationResult.AddToModelState(this.ModelState);

            return View(model);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(DeleteQuery query)
        {
            if (!await repo.CustomerExists(query.Id))
            {
                return NotFound();
            }

            var handler = new DeleteQueryHandler(repo);
            var result = await handler.Handle(query);

            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
