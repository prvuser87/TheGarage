﻿//namespace TheGarage.Services.Administration
//{
//    using System;
//    using System.Linq;
//    using System.Collections.Generic;

//    using TheGarage.Data;
//    using TheGarage.Data.Models;
//    using TheGarage.Services.Common.Administration;

//    public class ContentViewsAdministrationService  : BaseAdministrationService, IAdministrationService<ContentView>
//    {
//        public ContentViewsAdministrationService(ITheGarageDataa data)
//            : base(data)
//        {
//        }

//        public void Create(ContentView entity)
//        {
//            this.Data.ContentViews.Add(entity);
//            this.Data.SaveChanges();
//        }

//        public void Delete(object id)
//        {
//            this.Data.ContentViews.Delete(id);

//            this.Data.SaveChanges();
//        }

//        public void Update(ContentView entity)
//        {
//            this.Data.ContentViews.Update(entity);
//            this.Data.SaveChanges();
//        }

//        public IEnumerable<ContentView> Read()
//        {
//            return this.Data.ContentViews.All();
//        }

//        public ContentView Get(object id)
//        {
//            return this.Data.ContentViews.GetById(id);
//        }
//    }
//}
