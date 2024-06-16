using System;
using Microsoft.EntityFrameworkCore;
using PISSolution.Models;

public static class DataSeeder
{


    public static void SeedProperties(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Property>().HasData(
            new Property
            {
                ID = new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0"),
                PropertyName = "Luxury Villa",
                Address = "123 San Pawl Street",
                Price = 2500000.00M,
                DateOfRegistration = new DateTime(2021, 1, 15)
            },
            new Property
            {
                ID = new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0"),
                PropertyName = "Mercury Apartment",
                Address = "123 Triq il-Hadd",
                Price = 800000.00M,
                DateOfRegistration = new DateTime(2020, 5, 22)
            },
            new Property
            {
                ID = new Guid("1a7c565e-5291-4a9f-8b19-7e2e2c1b9f0e"),
                PropertyName = "Country House",
                Address = "99 Problems Street",
                Price = 600000.00M,
                DateOfRegistration = new DateTime(2019, 3, 10)
            }
        );

    }

    public static void SeedPriceHistories(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<PriceHistory>().HasData(
            new PriceHistory
            {
                ID = Guid.NewGuid(),
                PropertyID = new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0"),
                Price = 2400000.00M,
                Date = new DateTime(2022, 1, 10)
            }
            , new PriceHistory
            {
                ID = Guid.NewGuid(),
                PropertyID = new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0"),
                Price = 2300000.00M,
                Date = new DateTime(2021, 1, 10)
            },
             new PriceHistory
             {
                 ID = Guid.NewGuid(),
                 PropertyID = new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0"),
                 Price = 2100000.00M,
                 Date = new DateTime(2020, 1, 10)
             },
            new PriceHistory
            {
                ID = Guid.NewGuid(),
                PropertyID = new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0"),
                Price = 750000.00M,
                Date = new DateTime(2021, 6, 15)
            }, new PriceHistory
            {
                ID = Guid.NewGuid(),
                PropertyID = new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0"),
                Price = 450000.00M,
                Date = new DateTime(2020, 6, 15)
            }, new PriceHistory
            {
                ID = Guid.NewGuid(),
                PropertyID = new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0"),
                Price = 350000.00M,
                Date = new DateTime(2019, 6, 15)
            },
            new PriceHistory
            {
                ID = Guid.NewGuid(),
                PropertyID = new Guid("1a7c565e-5291-4a9f-8b19-7e2e2c1b9f0e"),
                Price = 580000.00M,
                Date = new DateTime(2020, 4, 20)
            }
        );

    }

    public static void SeedOwnerships(ModelBuilder modelBuilder)
    {
        // con 1 d5b6b5de-c589-4702-8d6f-94b5a3a7c8c0
        // con 2 a9b2b5de-3382-4c9a-bf68-6a0a3c8a8d2f
        // con 3 fc3f5c7e-0981-4855-8f6d-85b8c7b2e3d2
        //prop 1: e0a63457-6a49-49b9-b28b-82d6d0a8e9c0
        //prop 2: 67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0
        //prop 3: 1a7c565e-5291-4a9f-8b19-7e2e2c1b9f0e


        modelBuilder.Entity<Ownership>().HasData(
            new Ownership
            {
                ID = Guid.NewGuid(),
                PropertyID = new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0"),
                ContactID = new Guid("d5b6b5de-c589-4702-8d6f-94b5a3a7c8c0"),
                EffectiveFrom = new DateTime(2021, 1, 15),
                EffectiveTill = null,
                AcquisitionPrice = 2600000.00M
            },
             new Ownership
             {
                 ID = Guid.NewGuid(),
                 PropertyID = new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0"),
                 ContactID = new Guid("a9b2b5de-3382-4c9a-bf68-6a0a3c8a8d2f"),
                 EffectiveFrom = new DateTime(2020, 1, 15),
                 EffectiveTill = new DateTime(2021, 1, 14),
                 AcquisitionPrice = 2000000.00M
             },
              new Ownership
              {
                  ID = Guid.NewGuid(),
                  PropertyID = new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0"),
                  ContactID = new Guid("fc3f5c7e-0981-4855-8f6d-85b8c7b2e3d2"),
                  EffectiveFrom = new DateTime(2019, 1, 15),
                  EffectiveTill = new DateTime(2020, 1, 14),
                  AcquisitionPrice = 1900000.00M
              }
            , new Ownership
            {
                ID = Guid.NewGuid(),
                PropertyID = new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0"),
                ContactID = new Guid("8E64FF31-F402-448D-9740-26CB97DF4E2D"),
                EffectiveFrom = new DateTime(2020, 5, 22),
                EffectiveTill = null,
                AcquisitionPrice = 880000.00M
            },
            new Ownership
            {
                ID = Guid.NewGuid(),
                PropertyID = new Guid("1a7c565e-5291-4a9f-8b19-7e2e2c1b9f0e"),
                ContactID = new Guid("fc3f5c7e-0981-4855-8f6d-85b8c7b2e3d2"),
                EffectiveFrom = new DateTime(2019, 3, 10),
                EffectiveTill = null,
                AcquisitionPrice = 980000.00M
            }
        );

    }

    public static void SeedContacts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().HasData(
               new Contact
               {
                   ID = new Guid("d5b6b5de-c589-4702-8d6f-94b5a3a7c8c0"),
                   FirstName = "Sarah",
                   LastName = "Scerri",
                   PhoneNumber = "79312888",
                   Email = "sarah.scerri@gmail.com"
               },
               new Contact
               {
                   ID = new Guid("a9b2b5de-3382-4c9a-bf68-6a0a3c8a8d2f"),
                   FirstName = "Emily",
                   LastName = "Scerri",
                   PhoneNumber = "79312999",
                   Email = "emily.scerri@gmail.com"
               },
               new Contact
               {
                   ID = new Guid("fc3f5c7e-0981-4855-8f6d-85b8c7b2e3d2"),
                   FirstName = "Michael",
                   LastName = "Grech",
                   PhoneNumber = "99312951",
                   Email = "michael.grech@gmail.com"
               },
               new Contact
               {
                   ID = new Guid("8E64FF31-F402-448D-9740-26CB97DF4E2D"),
                   FirstName = "Brandon",
                   LastName = "Grech",
                   PhoneNumber = "79312905",
                   Email = "Brandon.Grech@gmail.com"
               }

           
           );
    }

}
