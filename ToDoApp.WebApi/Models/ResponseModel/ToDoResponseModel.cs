using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.WebApi.Models.ResponseModel
{
    public class ToDoResponseModel
    {
        public int Id { get; set; }

        public string? Task { get; set; }

        public bool? IsCompleted { get; set; }

        public string? CreatedUserId { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string? ModifiedUserId { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
