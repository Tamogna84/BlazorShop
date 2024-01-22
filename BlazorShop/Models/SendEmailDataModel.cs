using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Models
{
    public class SendEmailDataModel
    {
       
        [Required(ErrorMessage = "Заполните поле: \"Тема письма\"")]
        public string? subject { get; set; }

        [Required(ErrorMessage = "Заполните поле: \"Содержимое письма:\"")]
        public string? message { get; set; }

    }


}
