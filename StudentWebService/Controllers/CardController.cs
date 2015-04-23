using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CardWebService.Models;

namespace CardWebService.Controllers
{
    public class CardController : ApiController
    {
        private CardsContext db = new CardsContext();

        // GET api/Card
        public IEnumerable<Card> GetCards()
        {
            return db.Cards.AsEnumerable();
        }

        // GET api/Card/5
        public Card GetCard(int id)
        {
            Card Card = db.Cards.Find(id);
            if (Card == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Card;
        }

        // PUT api/Card/5
        public HttpResponseMessage PutCard(int id, Card Card)
        {
            if (ModelState.IsValid && id == Card.Id)
            {
                db.Entry(Card).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Card
        public HttpResponseMessage PostCard(Card Card)
        {
            if (ModelState.IsValid)
            {
                db.Cards.Add(Card);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Card);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Card.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Card/5
        public HttpResponseMessage DeleteCard(int id)
        {
            Card Card = db.Cards.Find(id);
            if (Card == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Cards.Remove(Card);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Card);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}