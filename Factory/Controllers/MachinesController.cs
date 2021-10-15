using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<MachineEngineer> model = _db.MachineEngineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(MachineEngineer category)
    {
      _db.MachineEngineers.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachineEngineer = _db.MachineEngineers
        .Include(category => category.JoinEntities)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(category => category.MachineEngineerId == id);
      return View(thisMachineEngineer);
    }

    public ActionResult Edit(int id)
    {
      var thisMachineEngineer = _db.MachineEngineers.FirstOrDefault(category => category.MachineEngineerId == id);
      return View(thisMachineEngineer);
    }

    [HttpPost]
    public ActionResult Edit(MachineEngineer category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMachineEngineer = _db.MachineEngineers.FirstOrDefault(category => category.MachineEngineerId == id);
      return View(thisMachineEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachineEngineer = _db.MachineEngineers.FirstOrDefault(category => category.MachineEngineerId == id);
      _db.MachineEngineers.Remove(thisMachineEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}