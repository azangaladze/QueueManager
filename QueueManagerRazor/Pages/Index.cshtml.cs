using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QueueManagerRazor.Pages
{
    public class IndexModel : PageModel
    {
        public readonly IRepository _repository;

        public IndexModel(IRepository repository)
        {
            _repository = repository;
            
        }

        public void OnPostAddToQueue()
        {
            _repository.EnqueueToQueue();
        }

        public void OnPostTeller1Click()
        {
            if (_repository.ShowQueue().Count != 0)
            {
                ViewData["Next1"] = ServeNextCustomer(1);
            }
        }
        public void OnPostTeller2Click()
        {
            if (_repository.ShowQueue().Count != 0)
            {
                ViewData["Next2"] = ServeNextCustomer(2);
            }
        }

        public void OnPostTeller3Click()
        {
            if (_repository.ShowQueue().Count != 0)
            {
                ViewData["Next3"] = ServeNextCustomer(3);
            }
        }

        public int ServeNextCustomer(int tellerNumber)
        {
            int tokenNumberToBeServed = 0;
            if (_repository.ShowQueue().Count > 0)
            {
                tokenNumberToBeServed = _repository.DequeueFromQueue();
                ViewData["TokenToServe"] = tokenNumberToBeServed;
            }
            ViewData["TellerNumber"] = tellerNumber;
            return tokenNumberToBeServed;
        }

        public void OnGet()
        {
           
        }
    }
}