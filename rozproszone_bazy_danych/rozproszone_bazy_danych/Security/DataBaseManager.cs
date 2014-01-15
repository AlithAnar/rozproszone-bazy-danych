using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rozproszone_bazy_danych.Models;
using rozproszone_bazy_danych.Security;
using System.Web.Security;

namespace rozproszone_bazy_danych.Security
{
    public class DataBaseManager
    {
        int currentBase;
        SettlementEntities dbCS;
        SettlementS1Entities dbS1;

        public DataBaseManager()
        {
            dbCS = new SettlementEntities();
            dbS1 = new SettlementS1Entities();
        }

        public bool IsInRole(String userName, String role)
        {
            currentBase = GetUserServer(userName);
            int temp;
            if (userName != "")
            {
                if (currentBase == 1)
                {
                    if (role == "Admin")
                        temp = 1;
                    else temp = 0;
                    if (dbS1.Users.Where(item => item.UserName == userName).FirstOrDefault().UserRole == temp)
                        return true;
                    else return false;
                }
                else
                {
                    if (role == "Admin")
                        temp = 1;
                    else temp = 0;
                    if (dbCS.Users.Where(item => item.UserName == userName).FirstOrDefault().UserRole == temp)
                        return true;
                    else return false;
                }
            }
            else return false;
        }
        private int GetUserServer(String userName)
        {
            if (userName != "")
            {
                if (dbCS.Users.Where(item => item.UserName == userName).FirstOrDefault().City.Province.name == "Dolnośląskie")
                    return 1;
                else
                    return 0;
            }
            else return 0;
        }

        public List<Settlement> GetSettlements(String userName)
        {
            currentBase = GetUserServer(userName);
            if (currentBase == 1)
            {
                return dbS1.Settlement.Where(item => item.Users.UserName == userName).ToList();
            }
            else
            {
                return dbCS.Settlement.Where(item => item.Users.UserName == userName).ToList();
            }
        }

        public Settlement GetSettlement(int id, String userName)
        {
            currentBase = GetUserServer(userName);
            if (currentBase == 1)
            {
                return dbS1.Settlement.Find(id);
            }
            else
            {
                return dbCS.Settlement.Find(id);
            }
        }

        public int GetUserId(String userName)
        {
            currentBase = GetUserServer(userName);
            if (currentBase == 1)
            {
                return dbS1.Users.Where(item => item.UserName == userName).FirstOrDefault().Id;
            }
            else
            {
                return dbCS.Users.Where(item => item.UserName == userName).FirstOrDefault().Id;
            }
        }

        public List<Province> GetProvinces()
        {
            if (currentBase == 1)
            {
                List<Province> temp = dbS1.Province.ToList();
                return temp;
            }
            else
            {
                List<Province> temp = dbS1.Province.ToList();
                return temp;
            }
        }

        public IQueryable<Users> GetUsers()
        {
            if (currentBase == 1)
            {
                return dbS1.Users;
            }
            else
            {
                return dbCS.Users;
            }
        }

        public void AddSettlement(Settlement settlement, String userName)
        {
            currentBase = GetUserServer(userName);
            if (currentBase == 1)
            {
                dbS1.Settlement.Add(settlement);
                dbS1.SaveChanges();
            }
            else
            {
                dbCS.Settlement.Add(settlement);
                dbCS.SaveChanges();
            }
        }

        public void EditSettlement(Settlement settlement, String userName)
        {
            currentBase = GetUserServer(userName);
            if (currentBase == 1)
            {
                dbS1.Entry(settlement).State = EntityState.Modified;
                dbS1.SaveChanges();
            }
            else
            {
                dbCS.Entry(settlement).State = EntityState.Modified;
                dbCS.SaveChanges();
            }
        }

        public void RemoveSettlement(int id, String userName)
        {
            currentBase = GetUserServer(userName);
            if (currentBase == 1)
            {
                Settlement settlement = GetSettlement(id, userName);
                dbS1.Settlement.Remove(settlement);
                dbS1.SaveChanges();
            }
            else
            {
                Settlement settlement = GetSettlement(id, userName);
                dbCS.Settlement.Remove(settlement);
                dbCS.SaveChanges();
            }

        }

        public void Dispose()
        {
            dbS1.Dispose();
            dbCS.Dispose();
        }

        public Users GetUser(String userName)
        {
            if (currentBase == 1)
            {
                return dbS1.Users.Where(item => item.UserName == userName).FirstOrDefault();
            }
            else
            {
                return dbCS.Users.Where(item => item.UserName == userName).FirstOrDefault();
            }
        }

        public Users GetUser(int id)
        {
            if (currentBase == 1)
            {
                return dbS1.Users.Where(item => item.Id == id).FirstOrDefault();
            }
            else
            {
                return dbCS.Users.Where(item => item.Id == id).FirstOrDefault();
            }
        }

        public void CreateUser(Users user)
        {
            if (currentBase == 1)
            {
                var crypto = new SimpleCrypto.PBKDF2();

                var encrypted = crypto.Compute(user.Password);

                var newuser = dbS1.Users.Create();
                newuser.UserName = user.UserName;
                newuser.Password = encrypted;
                newuser.PasswordSalt = crypto.Salt;
                newuser.Phone = user.Phone;
                newuser.Pesel = user.Pesel;
                newuser.Mail = user.Mail;
                newuser.Last_energy_usage = 0;
                newuser.FirstName = user.FirstName;
                newuser.SureName = user.SureName;
                newuser.City_Id = user.City_Id;
                dbS1.Users.Add(newuser);
                dbS1.SaveChanges();
            }
            else
            {
                var crypto = new SimpleCrypto.PBKDF2();

                var encrypted = crypto.Compute(user.Password);

                var newuser = dbCS.Users.Create();
                newuser.UserName = user.UserName;
                newuser.Password = encrypted;
                newuser.PasswordSalt = crypto.Salt;
                newuser.Phone = user.Phone;
                newuser.Pesel = user.Pesel;
                newuser.Mail = user.Mail;
                newuser.Last_energy_usage = 0;
                newuser.FirstName = user.FirstName;
                newuser.SureName = user.SureName;
                newuser.City_Id = user.City_Id;
                dbCS.Users.Add(newuser);
                dbCS.SaveChanges();
            }
        }

        public IQueryable<City> GetCities(int provinceId)
        {
            if (currentBase == 1)
            {
                return dbS1.City.Where(item => item.Province_Id == provinceId);
            }
            else
            {
                return dbCS.City.Where(item => item.Province_Id == provinceId);
            }
        }

        public City GetCity(int cityId)
            {
            if (currentBase == 1)
                {
                return dbS1.City.FirstOrDefault(item => item.Id == cityId);
                }
            else
                {
                return dbCS.City.FirstOrDefault(item => item.Id == cityId);
                }
            }

        public void EditUser(Users user)
        {
            currentBase = GetUserServer(user.UserName);
            if (currentBase == 1)
            {
                dbS1.Entry(user).State = EntityState.Modified;
                dbS1.SaveChanges();
            }
            else
            {
                dbCS.Entry(user).State = EntityState.Modified;
                dbCS.SaveChanges();
            }
        }

        public void RemoveUser(int id, String userName)
        {
            currentBase = GetUserServer(userName);
            if (currentBase == 1)
            {
                Users users = dbS1.Users.Find(id);
                dbS1.Users.Remove(users);
                dbS1.SaveChanges();
            }
            else
            {
                Users users = dbCS.Users.Find(id);
                dbCS.Users.Remove(users);
                dbCS.SaveChanges();
            }

        }

        public IQueryable<Settlement> GetAllSettlements()
        {
            return dbCS.Settlement;
        }

    }
}