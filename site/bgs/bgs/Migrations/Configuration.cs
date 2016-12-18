namespace bgs.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BgsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BgsContext context)
        {
            /*
             * Persons.
             */
            Person admin = new Person
            {
                PersonId = 1,
                FirstName = "Adrian",
                LastName = "Leon",
                Address = "Gåsevænget 13",
                Zip = "4812",
                City = "Stubbekøbning",
                BirthDay = new System.DateTime(1932, 6, 9)
            };
            admin.Credential = new Credential
            {
                UserName = "admin",
                UserPass = "admin"
            };
            admin.Roles.Add(Role.Administrator);
            context.Persons.AddOrUpdate(admin);

            Person customer = new Person
            {
                PersonId = 2,
                FirstName = "Robert",
                LastName = "Englund",
                Address = "Elm Street 669",
                Zip = "48312",
                City = "Springwood",
                BirthDay = new System.DateTime(1932, 6, 9)
            };
            customer.Roles.Add(Role.Customer);
            context.Persons.AddOrUpdate(customer);
            context.SaveChanges();

            /*
             * Product categories.
             */
            Category Sleeves = new Category
            {
                CategoryId = 1,
                CategoryCode = "CA-01",
                CategoryText = "Sleeves"
            };
            context.ProductCategories.AddOrUpdate(Sleeves);
            context.SaveChanges();

            /*
             * Sleeve sizes.
             */
            #region Large
            SleeveSize sizeLarge = new SleeveSize
            {
                ProductSizeText = "Large",
                DisplayDim = new Dimension
                {
                    Length = 225,
                    Width = 95,
                    Height = 101
                },
                FitCardDim = new Dimension
                {
                    Width = 59,
                    Height = 92
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 62,
                    Height = 96
                },
                NGSleeveDim = new Dimension
                {
                    Width = 62,
                    Height = 96
                },
                NGBoxDim = new Dimension
                {
                    Width = 65,
                    Height = 98,
                    Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 287,
                    Width = 227,
                    Height = 204
                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 87,
                    Magenta = 55,
                    Yellow = 0,
                    KeyColor = 0
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeLarge);
            #endregion

            #region Medium
            SleeveSize sizeMedium = new SleeveSize
            {
                ProductSizeText = "Medium",
                DisplayDim = new Dimension
                {
                    Length = 225,
                    Width = 90,
                    Height = 98
                },
                FitCardDim = new Dimension
                {
                    Width = 57,
                    Height = 89
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 59,
                    Height = 93
                },
                NGSleeveDim = new Dimension
                {
                    Width = 59,
                    Height = 93
                },
                NGBoxDim = new Dimension
                {
                    Width = 62,
                    Height = 95,
                    Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 272,
                    Width = 227,
                    Height = 198
                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 75,
                    Magenta = 0,
                    Yellow = 100,
                    KeyColor = 0
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeMedium);
            #endregion

            #region Small
            SleeveSize sizeSmall = new SleeveSize
            {
                ProductSizeText = "Small",
                DisplayDim = new Dimension
                {
                    Length = 225,
                    Width = 75,
                    Height = 77
                },
                FitCardDim = new Dimension
                {
                    Width = 44,
                    Height = 68
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 46,
                    Height = 72
                },
                NGSleeveDim = new Dimension
                {
                    Width = 62,
                    Height = 96
                },
                NGBoxDim = new Dimension
                {
                    Width = 49,
                    Height = 74,
                    Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 227,
                    Width = 227,
                    Height = 156
                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 0,
                    Magenta = 100,
                    Yellow = 100,
                    KeyColor = 0
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeSmall);
            #endregion

            #region Mini
            SleeveSize sizeMini = new SleeveSize
            {
                ProductSizeText = "Mini",
                DisplayDim = new Dimension
                {
                    Length = 225,
                    Width = 75,
                    Height = 72
                },
                FitCardDim = new Dimension
                {
                    Width = 41,
                    Height = 63
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 44,
                    Height = 67
                },
                NGSleeveDim = new Dimension
                {
                    Width = 44,
                    Height = 67
                },
                NGBoxDim = new Dimension
                {
                    Width = 47,
                    Height = 69,
                    Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 227,
                    Width = 227,
                    Height = 146
                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 0,
                    Magenta = 8,
                    Yellow = 100,
                    KeyColor = 0
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeMini);
            #endregion

            #region Standard
            SleeveSize sizeStandard = new SleeveSize
            {
                ProductSizeText = "Standard",
                DisplayDim = new Dimension
                {
                    Length = 225,
                    Width = 90,
                    Height = 105
                },
                FitCardDim = new Dimension
                {
                    Width = 63,
                    Height = 88
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 66.5m,
                    Height = 94
                },
                NGSleeveDim = new Dimension
                {
                    Width = 66.5m,
                    Height = 92.5m
                },
                NGBoxDim = new Dimension
                {
                    Width = 69.5m,
                    Height = 94.5m,
                    Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 272,
                    Width = 227,
                    Height = 212
                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 51,
                    Magenta = 41,
                    Yellow = 38,
                    KeyColor = 3
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeStandard);
            #endregion

            #region ExtraLarge
            SleeveSize sizeExtraLarge = new SleeveSize
            {
                ProductSizeText = "Extra Large",
                DisplayDim = new Dimension
                {
                    Length = 225,
                    Width = 93,
                    Height = 120
                },
                FitCardDim = new Dimension
                {
                    Width = 65,
                    Height = 100
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 68,
                    Height = 104
                },
                NGSleeveDim = new Dimension
                {
                    Width = 68,
                    Height = 104
                },
                NGBoxDim = new Dimension
                {
                    Width = 71,
                    Height = 106,
                    Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 281,
                    Width = 227,
                    Height = 242
                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 65,
                    Magenta = 90,
                    Yellow = 0,
                    KeyColor = 0
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeExtraLarge);
            #endregion

            #region Oversize
            SleeveSize sizeOversize = new SleeveSize
            {
                ProductSizeText = "Oversize",
                DisplayDim = new Dimension
                {
                    Length = 225,
                    Width = 115,
                    Height = 135
                },
                FitCardDim = new Dimension
                {
                    Width = 79,
                    Height = 120
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 82,
                    Height = 124
                },
                NGSleeveDim = new Dimension
                {
                    Width = 82,
                    Height = 124
                },
                NGBoxDim = new Dimension
                {
                    Width = 85,
                    Height = 126,
                    Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 347,
                    Width = 227,
                    Height = 272

                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 36,
                    Magenta = 57,
                    Yellow = 84,
                    KeyColor = 23
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeOversize);
            #endregion

            #region Square
            SleeveSize sizeSquare = new SleeveSize
            {
                ProductSizeText = "Square",
                DisplayDim = new Dimension
                {
                    Length = 225,
                    Width = 104,
                    Height = 78
                },
                FitCardDim = new Dimension
                {
                    Width = 69,
                    Height = 69
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 72,
                    Height = 73
                },
                NGSleeveDim = new Dimension
                {
                    Width = 72,
                    Height = 73
                },
                NGBoxDim = new Dimension
                {
                    Width = 75,
                    Height = 75,
                    Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 314,
                    Width = 227,
                    Height = 158
                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 0,
                    Magenta = 50,
                    Yellow = 98,
                    KeyColor = 0
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeSquare);
            #endregion

            #region Tarot
            SleeveSize sizeTarot = new SleeveSize
            {
                ProductSizeText = "Tarot",
                DisplayDim = new Dimension
                {
                    Length = 225,
                    Width = 105,
                    Height = 135
                },
                FitCardDim = new Dimension
                {
                    Width = 70,
                    Height = 120
                },
                StandardSleeveDim = new Dimension
                {
                    Width = 72,
                    Height = 124
                },
                NGSleeveDim = new Dimension
                {
                    Width = 72,
                    Height = 124
                },
                NGBoxDim = new Dimension
                {
                    Width = 75,
                    Height = 126,
                    Depth = 27
                },
                OuterCartonDim = new Dimension
                {
                    Length = 317,
                    Width = 227,
                    Height = 272
                },
                ProductSizeColorCode = new CMYK
                {
                    Cyan = 90,
                    Magenta = 30,
                    Yellow = 95,
                    KeyColor = 30
                }
            };
            context.SleeveSizes.AddOrUpdate(sizeTarot);
            #endregion

            context.SaveChanges();

            /*
             * Products. 
             */
            Product prdOversize = new Product
            {
                ProductId = 10408,
                ProductCode = "AT-10408",
                ProductName = "Board Game Sleeves - Oversize",
                Price = 20M,
                CategoryId = Sleeves.CategoryId,
                Weight = 0,
                ImageUrl = "/Content/Images/Products/Sleeves/at-10408-board-game-sleeves-oversize-e0.jpg",
                ProductSizeId = sizeOversize.ProductSizeId
            };
            context.Products.AddOrUpdate(prdOversize);

            Product prdExtraLarge = new Product
            {
                ProductId = 10407,
                ProductCode = "AT-10407",
                ProductName = "Board Game Sleeves - Extra Large",
                Price = 20M,
                CategoryId = Sleeves.CategoryId,
                ImageUrl = "/Content/Images/Products/Sleeves/board-game-sleeves-extra-large-1024-d4.jpg",
                ProductSizeId = sizeExtraLarge.ProductSizeId
            };
            context.Products.AddOrUpdate(prdExtraLarge);

            Product prdLarge = new Product
            {
                ProductId = 10402,
                ProductCode = "AT-10402",
                ProductName = "Board Game Sleeves - Large",
                Price = 18M,
                CategoryId = Sleeves.CategoryId,
                ImageUrl = "/Content/Images/Products/Sleeves/board-game-sleeves-large-1024-14.jpg",
                ProductSizeId = sizeLarge.ProductSizeId
            };
            context.Products.AddOrUpdate(prdLarge);

            Product prdStandard = new Product
            {
                ProductId = 10406,
                ProductCode = "AT-10406",
                ProductName = "Board Game Sleeves - Standard",
                Price = 16M,
                CategoryId = Sleeves.CategoryId,
                ImageUrl = "/Content/Images/Products/Sleeves/at-10406-board-game-sleeves-standard-1a.jpg",
                ProductSizeId = sizeStandard.ProductSizeId
            };
            context.Products.AddOrUpdate(prdStandard);

            Product prdMedium = new Product
            {
                ProductId = 10403,
                ProductCode = "AT-10403",
                ProductName = "Board Game Sleeves - Medium",
                Price = 14M,
                CategoryId = Sleeves.CategoryId,
                ImageUrl = "/Content/Images/Products/Sleeves/at-10403-board-game-sleeves-medium-68.jpg",
                ProductSizeId = sizeMedium.ProductSizeId
            };
            context.Products.AddOrUpdate(prdMedium);

            Product prdSmall = new Product
            {
                ProductId = 10404,
                ProductCode = "AT-10404",
                ProductName = "Board Game Sleeves - Small",
                Price = 12M,
                CategoryId = Sleeves.CategoryId,
                ImageUrl = "/Content/Images/Products/Sleeves/at-10404-board-game-sleeves-small-b1.jpg",
                ProductSizeId = sizeSmall.ProductSizeId
            };
            context.Products.AddOrUpdate(prdSmall);

            Product prdMini = new Product
            {
                ProductId = 10405,
                ProductCode = "AT-10405",
                ProductName = "Board Game Sleeves - Mini",
                Price = 10M,
                CategoryId = Sleeves.CategoryId,
                ImageUrl = "/Content/Images/Products/Sleeves/at-10405-board-game-sleeves-mini-4e.jpg",
                ProductSizeId = sizeMini.ProductSizeId
            };
            context.Products.AddOrUpdate(prdMini);

            Product prdSquare = new Product
            {
                ProductId = 10409,
                ProductCode = "AT-10409",
                ProductName = "Board Game Sleeves - Square",
                Price = 10M,
                CategoryId = Sleeves.CategoryId,
                ImageUrl = "/Content/Images/Products/Sleeves/at-10409-board-game-sleeves-square-f2.jpg",
                ProductSizeId = sizeSquare.ProductSizeId
            };
            context.Products.AddOrUpdate(prdSquare);
            /*
            Product prdTarot = new Product
            {
                ProductId = 10410,
                ProductCode = "AT-10410",
                ProductName = "Board Game Sleeves - Tarot",
                Price = 22M,
                CategoryId = Sleeves.CategoryId,
                ImageUrl = "/Content/Images/Products/Sleeves/board-game-sleeves-extra-large-1024-d4.jpg",
                ProductSizeId = sizeTarot.ProductSizeId
            };
            context.Products.AddOrUpdate(prdTarot);
            */

            context.SaveChanges();


            /*
             * Games.
             */
            Game acquire = new Game
            {
                GameId = 1,
                GameCode = "G-001",
                GameName = "Acquire"
            };
            context.Games.AddOrUpdate(acquire);

            Game arkhamHorror = new Game
            {
                GameId = 2,
                GameCode = "G-002",
                GameName = "Arkham Horror"
            };
            context.Games.AddOrUpdate(arkhamHorror);
            context.SaveChanges();

            /*
             * Products and Game fit.
             */
            ProductFitGame acquireSleeve = new ProductFitGame
            {
                GameId = acquire.GameId,
                ProductId = prdMedium.ProductId,
                Comment = ""
            };
            context.ProductGames.AddOrUpdate(acquireSleeve);
            acquire.ProductsFit.Add(acquireSleeve);
            prdMedium.FitsGames.Add(acquireSleeve);

            ProductFitGame arkhamHorrorSleeve = new ProductFitGame
            {
                GameId = arkhamHorror.GameId,
                ProductId = prdMedium.ProductId,
                Comment = "Big cards"
            };
            context.ProductGames.AddOrUpdate(arkhamHorrorSleeve);
            arkhamHorror.ProductsFit.Add(arkhamHorrorSleeve);
            prdMedium.FitsGames.Add(arkhamHorrorSleeve);
            context.SaveChanges();


            //OrderItem firstOrderItem = new OrderItem(prdTarot, 1);


            Order firstOrder = new Order(DateTime.Now);
            firstOrder.PersonId = customer.PersonId;
            firstOrder.AddItem(prdStandard, 1);
            //firstOrder.OrderItems.Add(firstOrderItem);
            context.Orders.AddOrUpdate(firstOrder);


            /**
             * Cart
             */

        }
    }
}
