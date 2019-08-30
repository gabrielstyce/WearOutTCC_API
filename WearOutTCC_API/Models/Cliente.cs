using System.Collections.Generic;

namespace WearOutTCC_API.Models
{
    public class Cliente : User
    {
        public List<Negociacao> Negociacoes { get; set; }

        public Cliente()
        {

        }
    }
}
