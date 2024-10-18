using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.Model;

namespace TaskSchedulerApp.Repository
{
    // IDealRepository - интерфейс сервиса для выполнения операций с сущностями Deal
    public interface IDealRepository
    {
        // добавление новой записи
        public Deal Add(Deal deal);
        // получение записи по id
        public Deal? GetById(int id);
        // получение одного списка дел (всех записей с одинаковым вторичным ключём)
        public List<Deal> ListAllByToDoList(string title);
        // удаление записи по id
        public Deal? DeleteById(int id);
        // обновление записи
        public Deal? Update(Deal deal);
        
    }
}
