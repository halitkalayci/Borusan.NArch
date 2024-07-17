using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipeline.Auth
{
    // İşaretlemek => İlgili pipeline behavior'ı spesifik requestler için devreye almak.
    // İlgili behaviorda bilgi talep etmek.
    public interface ISecuredRequest
    {
        public string[] Roles { get; } //read-only
    }
}
