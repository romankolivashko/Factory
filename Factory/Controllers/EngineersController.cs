using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineers.OrderBy(engineer => engineer.Arrived).ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    public ActionResult Details(int id)
    {
      var thisSurvivor = _db.Engineers
        .Include(engineer => engineer.JoinEntities)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.SurvivorId == id);
      return View(thisSurvivor);
    }

    [HttpPost]
    public ActionResult Create(Survivor engineer, int MachineId)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      if (MachineId != 0)
      {
        _db.MachineSurvivor.Add(new MachineSurvivor() { MachineId = MachineId, SurvivorId = engineer.SurvivorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisSurvivor = _db.Engineers.FirstOrDefault(engineer => engineer.SurvivorId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisSurvivor);
    }

    [HttpPost]
    public ActionResult Edit(Survivor engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.MachineSurvivor.Add(new MachineSurvivor() { MachineId = MachineId, SurvivorId = engineer.SurvivorId });
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisSurvivor = _db.Engineers.FirstOrDefault(engineer => engineer.SurvivorId == id);
        return View(thisSurvivor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisSurvivor = _db.Engineers.FirstOrDefault(engineer => engineer.SurvivorId == id);
        _db.Engineers.Remove(thisSurvivor);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      var thisSurvivor = _db.Engineers.FirstOrDefault(engineer => engineer.SurvivorId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisSurvivor);
    }

    [HttpPost]
    public ActionResult AddMachine(Survivor engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.MachineSurvivor.Add(new MachineSurvivor() { MachineId = MachineId, SurvivorId = engineer.SurvivorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var joinEntry = _db.MachineSurvivor.FirstOrDefault(entry => entry.MachineSurvivorId == joinId);
      _db.MachineSurvivor.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}