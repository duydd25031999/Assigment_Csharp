using BackEnd.DAO;
using System.Collections.Generic;
using System.Web.Services;
using Entity;

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
            List<Definition> list = dictionaryDAO.getListDefByString(dicID, search);
            int a = 0;
            return list;
        }
    }
}
