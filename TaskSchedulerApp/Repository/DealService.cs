using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.Model;

namespace TaskSchedulerApp.Repository
{
    // DealService - сервис для выполнения операций с сущностями Deal
    public class DealService : IDealRepository
    {
        // добавление новой записи
        public Deal Add(Deal deal)
        {
            using ApplicationDbContext db = new();
            db.Deals.Add(deal);
            db.SaveChanges();
            return deal;
        }
        // получение записи по id
        public Deal? GetById(int id)
        {
            using ApplicationDbContext db = new();
            return db.Deals.FirstOrDefault(deal => deal.Id == id);
        }
        // получение одного списка дел (всех записей с одинаковым вторичным ключём)
        public List<Deal> ListAllByToDoList(string title)
        {
            using ApplicationDbContext db = new();
            ToDoList? toDoList = db.ToDoLists.FirstOrDefault(tl => tl.Title == title);
            if (toDoList == null)
            {
                return [];
            }
            List<Deal> deals = db.Deals.Where(d => d.ToDoListId == toDoList.Id).ToList();
            return deals;
        }
        // удаление записи по id
        public Deal? DeleteById(int id)
        {
            Deal? deletedDeal = GetById(id);
            if (deletedDeal != null)
            {
                using ApplicationDbContext db = new();                
                db.Deals.Remove(deletedDeal);
                db.SaveChanges();
            }
            return deletedDeal;
        }

        // обновление записи
        public Deal? Update(Deal deal)
        {
            using ApplicationDbContext db = new();
            Deal? updatedDeal = db.Deals.FirstOrDefault(d => d.Id == deal.Id);
            if (updatedDeal != null)
            {
                updatedDeal.Name = deal.Name;
                updatedDeal.Priority = deal.Priority;
                updatedDeal.DateCreation = deal.DateCreation;
                updatedDeal.Deadline = deal.Deadline;
                updatedDeal.ToDoListId = deal.ToDoListId;
                db.SaveChanges();
            }
            return updatedDeal;
        }
        
    }
}
