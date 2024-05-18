using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace ourProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DovizController : ControllerBase
    {
       

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var web = new HtmlWeb();
            var doc = web.Load("https://www.doviz.com/");
            HtmlNode rootNode = doc.DocumentNode;
            HtmlNode kurNode = rootNode.SelectSingleNode("//span[@data-socket-attr='s' and @data-socket-key='USD']");
            HtmlNode kurNodeEuro = rootNode.SelectSingleNode("//span[@data-socket-attr='s' and @data-socket-key='EUR']");
            HtmlNode kurNodeGold = rootNode.SelectSingleNode("//span[@data-socket-attr='s' and @data-socket-key='gram-altin']");
            HtmlNode kurNodexu = rootNode.SelectSingleNode("//span[@data-socket-attr='s' and @data-socket-key='XU100']");
            HtmlNode kurNodebtn = rootNode.SelectSingleNode("//span[@data-socket-attr='s' and @data-socket-key='bitcoin']");
            string kur = kurNode.InnerText;
            string kurxu = kurNodexu.InnerText;
            string kurEur = kurNodeEuro.InnerText;
            string kurAltin =kurNodeGold.InnerText;
            string kurbtc =kurNodebtn.InnerText;
            return Ok("Dolar: " + kur +"\n"+
                      "Euro: "+ kurEur +"\n"+
                      "Gram Altýn: "+ kurAltin  +"\n"+
                      "Borsa: " +kurxu+"\n"+
                      "Bitcoin: "+kurbtc);
        }
    }
}
