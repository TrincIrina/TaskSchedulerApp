﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.Model;

namespace TaskSchedulerApp.Repository
{
    // IItemRepository - интерфейс сервиса для выполнения операций с сущностями Item
    public interface IItemRepository
    {
        // добавление новой записи
        public Item Add(Item item);
        // получение записи по id
        public Item? GetById(int id);
        // получение одного чек-листа (всех записей с одинаковым вторичным ключём)
        public List<Item> ListAllByDeal(int DealId);
        // удаление записи по id
        public Item? DeleteById(int id);
        // обновление записи
        public Item? Update(Item item);
    }
}
