using System.Linq;
using System.Web.Mvc;
using Lab1.Infrastucture;
using Lab1.Models;
using Lab1.Models.ViewModels;

namespace Lab1.Controllers
{
    public class BankomatController : Controller
    {
        private readonly UserContext _db = new UserContext();
        private static Card currentCard;

        // GET: Bankomat
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Card());
        }

        [HttpPost]
        public ActionResult Index(Card card)
        {
            if (ModelState.IsValid)
            {
                var cardFromDb = _db.Set<ClientCard>().FirstOrDefault(x => x.ClientCardNumber == card.CardNumber);
                if (cardFromDb == null)
                {
                    ModelState.AddModelError("", "Incorrect card number!");
                }
                else
                {
                    if (card.AttemptionsCount == 1)
                    {
                        ModelState.AddModelError("", "Your card will be blocked! You have the last attemption!");
                        card = new Card();
                    }
                    else if (cardFromDb.PinCode != card.PinCode)
                    {
                        ModelState.AddModelError("",
                            $"Incorrect pin code! You have {card.AttemptionsCount} attemptions!");
                        card.AttemptionsCount--;
                    }
                    else
                    {
                        currentCard = card;
                        return RedirectToAction("Menu");
                    }
                }
            }
            return View(card);
        }

        [HttpGet]
        public ActionResult Menu()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AfterOperationMenu()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetMoney()
        {
            if (currentCard == null)
            {
                return View("Index", new Card());
            }

            return View("RequestedMoney");
        }

        [HttpPost]
        public ActionResult GetMoney(RequestedMoney model)
        {
            if (currentCard == null)
            {
                return View("Index", new Card());
            }
            if (ModelState.IsValid)
            {
                //Decrease balance in db, check balance
                currentCard = null;
                return View("GetMoneySuccessMessage");
            }
          
            return View("RequestedMoney", model);
        }

        [HttpGet]
        public ActionResult Balance()
        {
            if (currentCard == null)
            {
                return View("Index", new Card());
            }
            //Get balance from db
            currentCard = null;
            return View(1);
        }

        [HttpGet]
        public ActionResult GetCardBack()
        {
            return View("Index", new Card());
        }


    }
}