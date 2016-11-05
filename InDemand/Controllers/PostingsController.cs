using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InDemand.Models;

namespace InDemand.Controllers
{
	public class PostingsController : Controller
	{
		private PostingDBContext db = new PostingDBContext();

		// GET: Postings
		public async Task<ActionResult> Index(bool? isConsumer, string location, string tags)
		{
			var postings = await db.Postings.ToListAsync();
			var query = postings.Select(p => p);

			if (isConsumer == null)
			{
				isConsumer = false;
			}

			query = query.Where(p => p.IsProvider != isConsumer);

			if (location != null && location != "")
			{
				query = query.Where(p => p.Location == location);
			}

			if (tags != null && tags != "")
			{
				var set = new HashSet<string>(tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
				query = query.Where(p => p.Tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Any(t => set.Contains(t)));
			}

			return View(query.ToList());
		}

		// GET: Postings/Details/5
		public async Task<ActionResult> Details(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Posting posting = await db.Postings.FindAsync(id);
			if (posting == null)
			{
				return HttpNotFound();
			}
			return View(posting);
		}

		// GET: Postings/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Postings/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "Id,IsProvider,Location,Title,Description,Tags")] Posting posting)
		{
			if (ModelState.IsValid)
			{
				posting.Id = Guid.NewGuid();
				db.Postings.Add(posting);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View(posting);
		}

		// GET: Postings/Edit/5
		public async Task<ActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Posting posting = await db.Postings.FindAsync(id);
			if (posting == null)
			{
				return HttpNotFound();
			}
			return View(posting);
		}

		// POST: Postings/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Id,IsProvider,Location,Title,Description,Tags")] Posting posting)
		{
			if (ModelState.IsValid)
			{
				db.Entry(posting).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(posting);
		}

		// GET: Postings/Delete/5
		public async Task<ActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Posting posting = await db.Postings.FindAsync(id);
			if (posting == null)
			{
				return HttpNotFound();
			}
			return View(posting);
		}

		// POST: Postings/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(Guid id)
		{
			Posting posting = await db.Postings.FindAsync(id);
			db.Postings.Remove(posting);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
