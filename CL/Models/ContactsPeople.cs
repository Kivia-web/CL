using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CL.Models
{
    public class ContactsPeople
    {
        public int Id { set; get; }
        [Required(ErrorMessage ="Имя не введено")]
        [StringLength(50,ErrorMessage ="Должно быть меньше 50 символов")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Фамилия не введена")]
        [StringLength(50, ErrorMessage = "Должно быть меньше 50 символов")]
        public string Surname { set; get; }
        [Required(ErrorMessage = "Отчество не введено")]
        [StringLength(50, ErrorMessage = "Должно быть меньше 50 символов")]
        public string Middlename { set; get; }
        [Required(ErrorMessage = "Номер телефона не введен")]
        [RegularExpression("((\\s?(8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10})+", ErrorMessage = "Не верный номер телефона")]
        public string PhoneNumber { set; get; }
        [Required(ErrorMessage = "Дата рождения не введена")]
        [RegularExpression("(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d", ErrorMessage = "Не верная дата рождения, введите в формате DD.MM.YYYY")]
        public string Birthdate { set; get; }
        [Required(ErrorMessage = "Организация не введена")]
        [StringLength(50, ErrorMessage = "Должно быть меньше 50 символов")]
        public string Organization { set; get; }
        [Required(ErrorMessage = "Должность не введена")]
        [StringLength(50, ErrorMessage = "Должно быть меньше 50 символов")]
        public string Post { set; get; }
        [Required(ErrorMessage = "E-mail не введен")]
        [RegularExpression("(\\s?[-\\w.]+@([A-z0-9][-A-z0-9]+\\.)+[A-z]{2,4})+", ErrorMessage = "Не верный E-mail")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Skype не введен")]
        [RegularExpression("(\\s?[a-zA-Z][a-zA-Z0-9_.,-]{5,31})+", ErrorMessage = "Не верный Skype")]
        public string Skype { set; get; }
        [Required(ErrorMessage = "Прочее не введено")]
        [StringLength(50, ErrorMessage = "Должно быть меньше 50 символов")]
        public string Other { set; get; }
    }
    //Создаются поля для базы данных с проверкой вводимых данных
}
