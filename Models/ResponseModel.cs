using System.Collections;
using System.Collections.Generic;

namespace HWRESTAPIS.Models {
    public class ResponseModel {

        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public IList Obj { get; set; } = new ArrayList();

    }
}
