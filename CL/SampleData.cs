using CL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL
{
    //Занесение некоторых конатктов в базу данных (Необязательно)
    public class SampleData
    {
        public static void Initialize(ContactsContext context)
        {
  
                if (!context.ContactsPeople.Any())
            {
                context.ContactsPeople.AddRange(
                    new ContactsPeople
                    {
                        Name = "Иван",
                        Surname = "Иванов",
                        Middlename = "Иванович",
                        PhoneNumber = "+79525548765",
                        Birthdate = "23.06.1998",
                        Organization = "ЦВТ",
                        Post = "Программист",
                        Email = "blabla@mail.ru",
                        Skype = "blabla",
                        Other = "-"
                    },
                    new ContactsPeople
                    {
                        Name = "Григорий",
                        Surname = "Григоров",
                        Middlename = "Григорьевич",
                        PhoneNumber = "+79226753597",
                        Birthdate = "18.03.1996",
                        Organization = "Ростелеком",
                        Post = "Охранник",
                        Email = "tgtg@mail.ru",
                        Skype = "tgtgtg",
                        Other = "-"
                    },
                    new ContactsPeople
                    {
                        Name = "Алексей",
                        Surname = "Алексеев",
                        Middlename = "Алексеевич",
                        PhoneNumber = "+79536497854",
                        Birthdate = "21.07.1997",
                        Organization = "Магнит",
                        Post = "Кассир",
                        Email = "yepyep@mail.ru",
                        Skype = "yepyep",
                        Other = "-"
                    },
                    new ContactsPeople
                    {
                        Name = "Лена",
                        Surname = "Унылова",
                        Middlename = "Алексеевна",
                        PhoneNumber = "+79057836524",
                        Birthdate = "05.09.1995",
                        Organization = "ИжГТу",
                        Post = "Преподаватель",
                        Email = "tytytyty@mail.ru",
                        Skype = "tytytyty",
                        Other = "-"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
