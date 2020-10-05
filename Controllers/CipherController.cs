
using System.Linq;
using cipherNg.Services;
using Microsoft.AspNetCore.Mvc;

namespace CipherNg.Controllers
{
    [ApiController]
    [Route("api/cipher")]
    public class CipherController: Controller
    {
        IEncoder coder;
        public CipherController(IEncoder coder)
        {
            this.coder = coder;
        }

        [HttpGet]
        public string Get(string strForCipher)
        {
            return coder.MakeEncode(strForCipher);
        }
    }

}