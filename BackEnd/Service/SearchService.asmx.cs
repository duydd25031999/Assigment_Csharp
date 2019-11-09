using BackEnd.DAO;
using System.Collections.Generic;
using System.Web.Services;
using Entity;
using System.Text;

namespace BackEnd.Service
{
    /// <summary>
    /// Summary description for SearchService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SearchService : System.Web.Services.WebService
    {
        DictionaryDAO dictionaryDAO = new DictionaryDAO();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Definition> getListDefByString(int dicID, string search)
        {
            List<Definition> list = dictionaryDAO.getListDefByString(dicID, processSearchInput(search));
            return list;
        }

        [WebMethod]
        public List<Term> getListSuggestByString(int dicID, string search)
        {
            /*
             * When user is typing
             * Get list top 5 terms that term's content contains user's typing
             */
            List<Term> list = dictionaryDAO.getTop5TermByString(dicID, search);
            return list;
        }
        [WebMethod]
        public List<Definition> getListDefByTerm(Term term)
        {
            /*
             * When user choice a term in suggest
             * Get list definitions of this term
             */
            List<Definition> list = dictionaryDAO.getDefinitionByTerm(term);
            return list;
        }

        [WebMethod]
        public void setNoteToTerm(string note)
        {

        }

        string processSearchInput(string input)
        {  
            return input.Trim().ToLower();
        }
    }
}
