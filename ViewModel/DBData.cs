﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    internal class DBData
    {
        public static List<PartnerWithDiscount> GetPartners()
        {
            using (DbAppContext ctx = new DbAppContext())
            {

                var partners = ctx.Partners
                    .Include(p => p.PartnerTypeEntity)
                    .Include(p => p.PartnerProductsEntities)
                    .ToList();

                return partners.Select(p => new PartnerWithDiscount(p)).ToList();
            }
        }

        public static List<MaterialType> GetMaterialTypes()
        {
            using (DbAppContext ctx = new DbAppContext()) 
            {
                var materialTypes = ctx.MaterialTypes;

                return materialTypes.ToList();
            }
        }
       

        public static void AddPartner(Partner partner)
        {

            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Partners.Add(partner);
                ctx.SaveChanges();
            }
        }

        public static void UpdatePartner(Partner partner)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                var existingPartner = ctx.Partners.Find(partner.PartnerId);
                if (existingPartner != null)
                {
                    ctx.Entry(existingPartner).CurrentValues.SetValues(partner);
                    ctx.SaveChanges();
                }
            }
        }

        public static int GetPartnerId(string partnerName)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.PartnerTypes.First(t => t.TypeName == partnerName).PartnerTypeId;
            }
        }

        public static Partner GetPartnerByName(string partnerName)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Partners.First(p => p.CompanyName == partnerName);
            }
        }

        public static List<PartnerProducts> GetPartnerProducts()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.PartnerProducts
                    .Include(p => p.PartnerEntity)
                    .ToList();
            }
        }

        public static List<ProductType> GetProductTypes()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                var productTypes = ctx.ProductTypes;

                return productTypes.ToList();
            }
        }
    }
}
