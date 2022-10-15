using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PillowComp.Data;


namespace PillowComp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PillowCompContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PillowCompContext>>()))
            {
                //Look for any pillows.
                if (context.Pillow.Any())
                {
                    return; //DB has been seeded
                }
                context.Pillow.AddRange(
                    new Pillow
                    {
                        Name = "Cushion",
                        ManufactureDate = DateTime.Parse("1989-3-11"),
                        Colour = "Green",
                        Size = "Small",
                        Price = 11.99M
                    },

                       new Pillow
                       {
                           Name = "Bamboo",
                           ManufactureDate = DateTime.Parse("1988-2-12"),
                           Colour = "Golden",
                           Size = "Small",
                           Price = 8.99M
                       },

                          new Pillow
                          {
                              Name = "Round Throw",
                              ManufactureDate = DateTime.Parse("1987-2-12"),
                              Colour = "Royal Blue",
                              Size = "Big",
                              Price = 12.99M
                          },

                             new Pillow
                             {
                                 Name = "Feather",
                                 ManufactureDate = DateTime.Parse("1989-2-12"),
                                 Colour = "White",
                                 Size = "Small",
                                 Price = 8.99M
                             },

                                new Pillow
                                {
                                    Name = "Super Soft",
                                    ManufactureDate = DateTime.Parse("1986-2-12"),
                                    Colour = "Blue",
                                    Size = "Small",
                                    Price = 10.99M
                                },

                                   new Pillow
                                   {
                                       Name = "Neck Relief",
                                       ManufactureDate = DateTime.Parse("1989-2-12"),
                                       Colour = "Purple",
                                       Size = "Small",
                                       Price = 8.99M
                                   },

                                      new Pillow
                                      {
                                          Name = "Body Relax",
                                          ManufactureDate = DateTime.Parse("1988-2-12"),
                                          Colour = "Yellow",
                                          Size = "Big",
                                          Price = 15.99M
                                      },

                                         new Pillow
                                         {
                                             Name = "Memory foam",
                                             ManufactureDate = DateTime.Parse("1980-2-12"),
                                             Colour = "White",
                                             Size = "Big",
                                             Price = 15.99M
                                         },

                                            new Pillow
                                            {
                                                Name = "Round Velvet",
                                                ManufactureDate = DateTime.Parse("1989-2-12"),
                                                Colour = "Golden",
                                                Size = "Small",
                                                Price = 7.99M
                                            },

                                               new Pillow
                                               {
                                                   Name = "Pancake Pillow",
                                                   ManufactureDate = DateTime.Parse("1980-2-12"),
                                                   Colour = "Blue",
                                                   Size = "Small",
                                                   Price = 15.99M
                                               }
                                         );

            }
                




            }
        }
    }

