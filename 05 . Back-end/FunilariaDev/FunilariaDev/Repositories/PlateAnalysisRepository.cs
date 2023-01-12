using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using FunilariaDev.Interfaces;
using FunilariaDev.Repositories;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace FunilariaDev.Repositories
{
    public class PlateAnalysisRepository : IPlateAnalysisRepository
    {
            public string PlateValue { get; set; }

        //To use the AI ​​method it is necessary to put the credentials in PowerShell or Cmd
        public string Analyze(int idUser)
        {

            UserRepository userImg = new UserRepository();

            var imagePath = userImg.FindImageWithId(idUser);

            if(imagePath.ImagePlate != null)
            {
                var client = ImageAnnotatorClient.Create();
                Image imagePlate = Image.FromFile($"Resources/Images/{imagePath.ImagePlate}");

                var response = client.DetectText(imagePlate);

                foreach (var responsePlate in response)
                {
                    if (responsePlate.Description != null)
                    {
                        
                            PlateValue = responsePlate.Description;
                            UserRepository userUpdate = new UserRepository();

                            userUpdate.UpdatePlate(idUser, PlateValue);
                       

                    }
                }

                /* TextAnnotation text = client.DetectDocumentText(imagePlate);
                 foreach (var page in text.Pages)
                 {
                     foreach (var block in page.Blocks )
                     {
                         string box = string.Join(" - ", block.BoundingBox.Vertices.Select(v => $"({v.X}, {v.Y})"));
                         PlateValue = $"Block {block.BlockType} at {box}";
                         UserRepository userUpdate = new UserRepository();
                         userUpdate.UpdatePlate(idUser, PlateValue);
                     }
                 }
                */




            }

            return PlateValue;
        }

        public string DeleteImage(int idUser)
        {
            

            UserRepository FindImage = new UserRepository();

            var findedImage = FindImage.FindForId(idUser);

            if(findedImage.ImagePlate != null)
            {
                System.IO.File.Delete($"Resources/Images/{findedImage.ImagePlate}");
            }

            return "";

        }
    }
}
